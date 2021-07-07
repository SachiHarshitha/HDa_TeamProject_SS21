pragma solidity ^0.5.0;

contract OpenRequests {
    address constant ADMIN_ADDRESS = 0xb8B76e5A4AebBe98D09b5dEb92A9505A6df8f1fb; //ADMIN Account which the Internal API uses
    address[] private openRequests; // Array of Open Requests
    address mainContract; // Address of the Main Contract
    mapping(address => uint256) private openRequestIndexer; // Supporting Map to Index through the Open Request Array.

    // Get All open requests
    function get() public view returns (address[] memory) {
        checkAdminPermission();
        return openRequests;
    }

    // Add open request
    function add(address _client) public onlyMainContract {
        openRequestIndexer[_client] = openRequests.push(_client) - 1;
    }

    // Delete an Open Request
    function remove(address _client) public onlyMainContract {
        uint256 rowToDelete = openRequestIndexer[_client];
        address keyToMove = openRequests[openRequests.length - 1];
        openRequests[rowToDelete] = keyToMove;
        openRequestIndexer[keyToMove] = rowToDelete;
        openRequests.length--;
        delete openRequestIndexer[_client];
    }

    // Check if the Clients address is included in the open requests.
    function exists(address _client) public view returns (bool) {
        for (uint256 i; i < openRequests.length; i++) {
            if (openRequests[i] == _client) return true;
        }
    }

    // Function to set Main Contract address using Admin Account
    function setMainContract(address _mainContract) public {
        checkAdminPermission();
        mainContract = _mainContract;
    }

    // Check if the invoker of the function is admin
    function checkAdminPermission() internal view {
        if (msg.sender != ADMIN_ADDRESS) {
            revert();
        }
    }

    // Check if the invoker of the function is admin
        modifier onlyMainContract() {
        require(msg.sender == mainContract);
        _;
    }
}
