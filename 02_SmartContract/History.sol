pragma solidity ^0.5.0;

contract History{
        address constant ADMIN_ADDRESS = 0xb8B76e5A4AebBe98D09b5dEb92A9505A6df8f1fb; //ADMIN Account which the Internal API uses

        mapping(address => Record[]) private historyDictionary; // Historical Transaction Log
        
            // History Transaction Record Content
    struct Record {
        uint256 timestamp;
        bytes32 data;
    }
    
        // Write an Entry into History
    function write(address _sender, bytes32 _data) public {
        Record[] storage history = historyDictionary[_sender];
        history.push(Record({timestamp: now, data: _data}));
        historyDictionary[_sender] = history;
    }
    
        // Get History Record Method
    function get(address _client)
        public
        view
        returns (uint256[] memory, bytes32[] memory)
    {
        //gets the timestamp and data of the historical log and returns it
        checkAdminPermission();
        Record[] storage records = historyDictionary[_client];
        uint256 arrayLength = records.length;
        uint256[] memory timestamp = new uint256[](arrayLength);
        bytes32[] memory data = new bytes32[](arrayLength);

        for (uint256 i = 0; i < arrayLength; i++) {
            timestamp[i] = records[i].timestamp;
            data[i] = records[i].data;
        }
        return (timestamp, data);
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