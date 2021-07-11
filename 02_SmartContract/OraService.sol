pragma solidity ^0.5.0;

import "./provableAPI_0.5.sol";

contract OraService is usingProvable {
    string response;
    address appAddress;
    event ProvableEvent(address sender, address appadress);
    event LogConstructorInitiated(string nextStep);
    event LogAuthcodeReceived(bool status);
    event LogNewQuery(string description);
    event LogNewProvableQuery(string description, string pathaddress);
    mapping(bytes32 => string) private responseDictionary; // Requests and its information List

    constructor(address _address) public payable {
        OAR = OracleAddrResolverI(_address);
        appAddress = msg.sender;
        emit LogConstructorInitiated(
            "Constructor was initiated. Call 'getAuthcode()' to send the Provable Query."
        );
    }

    function new_User(string memory customerID) public payable {
        if (provable_getPrice("URL") > address(this).balance) {
            emit LogNewQuery(
                "Provable query was NOT sent, please add some ETH to cover for the query fee!"
            );
        } else {
            string memory path = append2(
                "http://ec2co-ecsel-tubj03wqh1gc-869839621.eu-west-2.elb.amazonaws.com:9080/user/new/aXrWDpmJbrMRqyg2XpHmfOMV5vYVbCirflSw0ZICQS8%3D/",
                customerID
            );
            provable_query("URL", path);
            emit LogNewProvableQuery("Provable query was sent to...", path);
        }
    }

    function del_User(string memory customerID) public payable {
        if (provable_getPrice("URL") > address(this).balance) {
            emit LogNewQuery(
                "Provable query was NOT sent, please add some ETH to cover for the query fee!"
            );
        } else {
            string memory path = append2(
                "http://ec2co-ecsel-tubj03wqh1gc-869839621.eu-west-2.elb.amazonaws.com:9080/user/delete/aXrWDpmJbrMRqyg2XpHmfOMV5vYVbCirflSw0ZICQS8%3D/",
                customerID
            );
            provable_query("URL", path);
            emit LogNewProvableQuery("Provable query was sent to...", path);
        }
    }

    function add_Asset(
        string memory _clientID,
        string memory _authcode,
        string memory _assetID,
        string memory _serial
    ) public payable {
        if (provable_getPrice("URL") > address(this).balance) {
            emit LogNewQuery(
                "Provable query was NOT sent, please add some ETH to cover for the query fee!"
            );
        } else {
            string memory path = append5(
                "http://ec2co-ecsel-tubj03wqh1gc-869839621.eu-west-2.elb.amazonaws.com:9080/asset/register",
                _authcode,
                _clientID,
                _assetID,
                _serial
            );
            provable_query("URL", path);
            emit LogNewProvableQuery("Provable query was sent to...", path);
        }
    }

    function del_Asset(
        string memory _clientID,
        string memory _authcode,
        string memory _assetID
    ) public payable {
        if (provable_getPrice("URL") > address(this).balance) {
            emit LogNewQuery(
                "Provable query was NOT sent, please add some ETH to cover for the query fee!"
            );
        } else {
            string memory path = append4(
                "http://ec2co-ecsel-tubj03wqh1gc-869839621.eu-west-2.elb.amazonaws.com:9080/asset/delete",
                _authcode,
                _clientID,
                _assetID
            );
            provable_query("URL", path);
            emit LogNewProvableQuery("Provable query was sent to...", path);
        }
    }

    function __callback(bytes32 myid, string memory result) public {
        if (msg.sender != provable_cbAddress()) revert();
        response = result;
    }

    modifier fromContract {
        require(msg.sender == appAddress);
        _;
    }

    //getter
    function get_Response() public view fromContract returns (string memory) {
        return response;
    }

    function append2(string memory a, string memory b)
        internal
        pure
        returns (string memory)
    {
        return string(abi.encodePacked(a, b));
    }

    function append5(
        string memory a,
        string memory b,
        string memory c,
        string memory d,
        string memory e
    ) internal pure returns (string memory) {
        return string(abi.encodePacked(a, "/", b, "/", c, "/", d, "/", e));
    }

    function append4(
        string memory a,
        string memory b,
        string memory c,
        string memory d
    ) internal pure returns (string memory) {
        return string(abi.encodePacked(a, "/", b, "/", c, "/", d));
    }
}
