pragma solidity ^0.5.0;

import "./OraService.sol";
import "./Assets.sol";
import "./OpenRequests.sol";
import "./History.sol";

contract Main {
    address constant ADMIN_ADDRESS = 0xb8B76e5A4AebBe98D09b5dEb92A9505A6df8f1fb; //ADMIN Account which the Internal API uses
    address constant BRIDGE_ADDRESS =
        0x6f485C8BF6fc43eA212E93BBF8ce046C7f1cb475; // Ethereum-Bridge Account address
    mapping(address => Request) private requestDictionary; // Requests and its information List

    // History Transaction Record Content
    struct Record {
        uint256 timestamp;
        bytes32 data;
    }

    // Transaction Status defined as an ENUM
    enum TransactionStatus {
        OPEN,
        REQUESTED,
        ACKNOWLEDGED,
        PAID,
        REJECTED
    }

    // Request Structure
    struct Request {
        address reqAddress; // Requestors address
        address relAddress; // Release Account address
        uint256 tokenAmount; // Amount of Token Due
        uint32 orderDate; // Unix time takes the format of uint32
        uint32 orderQty; // orderQty of assets
        uint32 level; // level of access
        string authCode; // Authorization Code
        string clientID; // Client Identification
        string name; // Name of the Client
        string email; // Email of the client
        TransactionStatus status; // Transaction Status
    }

    // Private address allocator for the INTRANAV Address.
    address payable private intraAddress;

    // Private instance of the Authcode Getter Oracle Smart Contract
    OraService oraService;
    Assets assets;
    OpenRequests openrequests;
    History history;

    // Constructor for the contract
    constructor(
        address payable _intraAddress,
        address payable _assets,
        address payable _openrequests,
        address payable _history
    ) public {
        intraAddress = _intraAddress;
        assets = Assets(_assets);
        openrequests = OpenRequests(_openrequests);
        history = History(_history);
    }

    /**
     * Public Client Accessible Methods
     */

    // Create a Request Method
    function Create_Rquest(
        uint32 _orderDate,
        uint32 _orderQty,
        uint32 _level,
        string calldata _name,
        string calldata _email,
        string calldata _clientID
    ) external {
        //create new Request Object
        Request memory newReq;

        //save address if sender
        address _sender = msg.sender;

        //fill new Request Object with informations
        newReq.reqAddress = _sender;
        newReq.orderDate = _orderDate;
        newReq.orderQty = _orderQty;
        newReq.level = _level;
        newReq.name = _name;
        newReq.email = _email;
        newReq.clientID = _clientID;
        newReq.status = TransactionStatus.OPEN; // Set Status Enum to 1 = REQUESTED

        //save the new request with sender adress in request dictionary
        requestDictionary[_sender] = newReq;
        if (openrequests.exists(_sender)) {
            openrequests.remove(_sender);
        }
        //adds created request to open requests
        openrequests.add(_sender);

         history.write(_sender, "New Request");
        emit FunctionCalled(msg.sender, "CreateRquest");
    }

    // Send Token Method ( Required to send the amount of TOKEN required by the portal)
    function sendToken() public payable {
        //checks if token sender sent a request before
        checkIsSender();

        address _sender = msg.sender;
        //get request of sender
        Request storage req = requestDictionary[_sender];
        uint256 amount = req.tokenAmount;
        //revert if wrong amount of tokens are sent
        if (amount != msg.value) revert();
        if (
            req.status == TransactionStatus.ACKNOWLEDGED &&
            _sender.balance > amount
        ) {
            emit FunctionCalled(_sender, "sendToken");

            //send the token and set transaktion status to paid
            intraAddress.transfer(msg.value);
            req.status = TransactionStatus.PAID;
            req.tokenAmount = 0;

            // Set Status Enum to 3 = PAID
            requestDictionary[_sender] = req;
             history.write(_sender, "PAID");
            emit FunctionCalled(_sender, "PAID");

            //call request authcode method
            ReqAuthcode();

            // Update the Balance and Quota with the new quantity
            assets.newOrder(_sender, requestDictionary[_sender].orderQty);
             history.write(_sender, "New Order Completed");
        } else {
             history.write(_sender, "Invalid transaction");
            emit FunctionCalled(_sender, "Invalid transaction");
        }
    }

    //update the authcode after request was succesfully
    function upd_Authcode() public {
        requestDictionary[msg.sender].authCode = oraService.get_Response();
    }

    // Get the Authorization Code
    function get_Authcode() public view returns (string memory) {
        return requestDictionary[msg.sender].authCode;
    }

    // Get Status
    function get_Status() public view returns (uint256) {
        return uint256(requestDictionary[msg.sender].status);
    }

    // Get Token Amount
    function get_TokenAmount() public view returns (uint256) {
        return uint256(requestDictionary[msg.sender].tokenAmount);
    }

    /**
     * Public Admin Accessible Methods
     */

    // Acknowledge the request
    function Acknowledge_Request(address _reqAddress, bool _Acknowledged)
        public
    {
        //checks if invoker is Admin
        checkAdminPermission();
        if (_Acknowledged) {
            Request storage req = requestDictionary[_reqAddress];

            req.relAddress = msg.sender;

            // Set Status Enum to 2 = ACKNOWLEDGED
            req.status = TransactionStatus.ACKNOWLEDGED;

            //calculate tokens required fot the request and save the amount to the request object
            uint256 amount = calculateToken(req.level, req.orderQty);
            req.tokenAmount = amount;
            requestDictionary[_reqAddress] = req;
            // Delete the Request from OPEN request list
            openrequests.remove(_reqAddress);
            emit FunctionCalled(msg.sender, "ACKNOWLEDGED");
             history.write(_reqAddress, "ACKNOWLEDGED");
        } else {
            requestDictionary[_reqAddress].status = TransactionStatus.REJECTED; // Set Status Enum to 4 = REJECTED
            openrequests.remove(_reqAddress);
             history.write(_reqAddress, "REJECTED");
            emit FunctionCalled(msg.sender, "REJECTED");
        }
    }

    // Delete Record Method
    function del_Record(address _client) public returns (bool) {
        checkAdminPermission();
        oraService = new OraService(BRIDGE_ADDRESS);
        delete requestDictionary[_client];
        assets.del_Client(_client);
        oraService.del_User(requestDictionary[_client].clientID);
        openrequests.remove(_client);
         history.write(_client, "DELETED");
        emit FunctionCalled(_client, "DELETED");
    }

    // Query the Request Content
    function query_Request(address _client)
        public
        view
        returns (
            address reqAddress,
            address relAddress,
            uint256 tokenAmount,
            uint32 orderDate, // Unix time takes the format of uint32
            uint32 orderQty, // orderQty in days
            uint32 level, // User Level
            string memory authCode,
            string memory clientID,
            string memory name,
            string memory email,
            TransactionStatus status
        )
    {
        checkAdminPermission();
        Request storage req = requestDictionary[_client];
        return (
            req.reqAddress,
            req.relAddress,
            req.tokenAmount,
            req.orderDate,
            req.orderQty,
            req.level,
            req.authCode,
            req.clientID,
            req.name,
            req.email,
            req.status
        );
    }

    /**
     * Commonly Accessible Functions
     */

    // Get the Request Content
    function get_Request()
        public
        view
        returns (
            address reqAddress,
            address relAddress,
            uint256 tokenAmount,
            uint32 orderDate, // Unix time takes the format of uint32
            uint32 orderQty, // Order Quantity
            uint32 level, // User Level
            string memory authCode,
            string memory clientID,
            string memory name,
            string memory email,
            TransactionStatus status
        )
    {
        Request storage req = requestDictionary[msg.sender];
        return (
            req.reqAddress,
            req.relAddress,
            req.tokenAmount,
            req.orderDate,
            req.orderQty,
            req.level,
            req.authCode,
            req.clientID,
            req.name,
            req.email,
            req.status
        );
    }

    /**
     * INTERNAL Utlity Functions
     */

    // Request New Authorization Code from the Certificate Authority
    function ReqAuthcode() internal {
        address sender = msg.sender;
        if (requestDictionary[sender].status != TransactionStatus.PAID)
            revert();
        else {
            //crete new Authcodegetter object with ethereum-bridge adress
            oraService = new OraService(BRIDGE_ADDRESS);
            //call get authcode getter function to request new authcode
            oraService.new_User(requestDictionary[sender].clientID);
            history.write(sender, "New Authorization Code Requested");
            emit FunctionCalled(sender, "Provable Success");
        }
    }

    // Calculate the Required Token Amount based on the Requested Level and the orderQty
    function calculateToken(uint256 _level, uint256 _orderQty)
        private
        pure
        returns (uint256)
    {
        uint256 tokenAmount;
        if (_level == 1) {
            tokenAmount = _orderQty * 5e16;
        } else {
            tokenAmount = _orderQty * 5e13;
        }
        return tokenAmount;
    }

    // Custom Eevent
    event FunctionCalled(address indexed _address, string _name);

    // Check if the invoker of the function is admin
    function checkAdminPermission() internal view {
        if (msg.sender != ADMIN_ADDRESS) {
            revert();
        }
    }

    // Check for sender
    function checkIsSender() internal view {
        address sender = msg.sender;
        if (requestDictionary[sender].reqAddress != sender) revert();
    }

}
