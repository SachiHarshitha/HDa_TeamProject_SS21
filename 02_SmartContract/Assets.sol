pragma solidity ^0.5.0;

import "./OraService.sol";

contract Assets {
    address constant ADMIN_ADDRESS = 0xb8B76e5A4AebBe98D09b5dEb92A9505A6df8f1fb; //ADMIN Account which the Internal API uses
    address constant BRIDGE_ADDRESS =
        0x6f485C8BF6fc43eA212E93BBF8ce046C7f1cb475; // Ethereum-Bridge Account address

    mapping(address => uint32) private balanceDictionary; // Order Balance sheet for each client
    mapping(address => uint32) private quotaDictionary; // Total quantity owned by the Client
    address mainContract;

    // Private instance of the Authcode Getter Oracle Smart Contract
    OraService oraService;

    // Function to set Main Contract address using Admin Account
    function setMainContract(address _mainContract) public {
        checkAdminPermission();
        mainContract = _mainContract;
    }

    // Update the quota and balance with the new ordered amount. Can be only invoked from the Main Contract.
    function newOrder(address _client, uint32 _amount) public onlyMainContract {
        balanceDictionary[_client] += _amount;
        quotaDictionary[_client] += _amount;
    }

    // Get Sensor Balance available for client
    function get_Balance() public view returns (uint32) {
        return balanceDictionary[msg.sender];
    }

    // Get total Sensor Owned by the Client
    function get_Total() public view returns (uint32) {
        return quotaDictionary[msg.sender];
    }

    function del_Client(address _client) public onlyMainContract {
        delete balanceDictionary[_client];
        delete quotaDictionary[_client];
    }

    // Add a asset and reduce the quota
    function register_Asset(
        string calldata _clientID,
        string calldata _authcode,
        string calldata _assetID,
        string calldata _serial
    ) external {
        address _sender = msg.sender;
        require(
            balanceDictionary[_sender] > 0,
            "asset Balance is insufficient, Please purchase in order to proceed"
        );
        oraService = new OraService(BRIDGE_ADDRESS);
        oraService.add_Asset(_clientID, _authcode, _assetID, _serial);
        balanceDictionary[_sender] -= 1;
        emit FunctionCalled(msg.sender, "asset Added");
    }

    // Delete a asset and release the quota
    function del_Asset(
        string calldata _clientID,
        string calldata _authcode,
        string calldata _assetID
    ) external {
        address _sender = msg.sender;
        require(
            quotaDictionary[_sender] + 1 > balanceDictionary[_sender],
            "asset Balance is insufficient, Please purchase in order to proceed"
        );
        oraService = new OraService(BRIDGE_ADDRESS);
        oraService.del_Asset(_clientID, _authcode, _assetID);
        balanceDictionary[_sender] += 1;
        emit FunctionCalled(msg.sender, "asset Deleted");
    }

    // Access modifier restricted only to the Main Contract
    modifier onlyMainContract() {
        require(msg.sender == mainContract);
        _;
    }

    // Get the Oracle Service Response.
    function upd_Response() public view returns (string memory) {
        return oraService.get_Response();
    }

    // Custom Eevent
    event FunctionCalled(address indexed _address, string _name);

    // Check if the invoker of the function is admin
    function checkAdminPermission() internal view {
        if (msg.sender != ADMIN_ADDRESS) {
            revert();
        }
    }
}
