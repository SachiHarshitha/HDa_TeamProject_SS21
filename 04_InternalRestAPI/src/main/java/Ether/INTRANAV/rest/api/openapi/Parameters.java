package Ether.INTRANAV.rest.api.openapi;

import java.math.BigInteger;

/**
 * Set the Parameters below according to the Simulation Environment
 */
public class Parameters {

        // Main Smart Contract Address
        public static final String MAIN_CONTRACT_ADDRESS = "0xd2DF0bc9B2e9eb28c260daDf7D2ACC6db23fD024";
        // ASSETS Smart Contract Address
        public static final String ASSETS_CONTRACT_ADDRESS = "0xbA89f50904FeB82245C9c238dDb8A88420b87489";
        // Open Requests Smart Contract Address
        public static final String OPREQUESTS_CONTRACT_ADDRESS = "0xfEdC7803a40c39ae4bfef1430677B5f3B6cFDca7";
        // History Smart Contract Address
        public static final String HISTORY_CONTRACT_ADDRESS = "0x604865472362ba89C115dB5a7e01A31e8E75a41E";
        // Private KEY of the Client Account used in the project
        public static final String CLIENT_PRIVATE_KEY = "0xbf562bcbb6792187dc5cdcf645ff07595d68ce9f234f173785ca1eae097c61e1";
        // Private KEY of the ADMIN Account used in the project
        public static final String ADMIN_PRIVATE_KEY = "0x77f4d8047405cc8dbeed5c831a6a8123c3102948b235b5aca7a94be529cd743e";
        // Default Gas Price
        public static final BigInteger GAS_PRICE = BigInteger.valueOf(20_000_000_000L);
        // Default Gas Limit
        public static final BigInteger GAS_LIMIT = BigInteger.valueOf(6_000_000L);
        // Default Gas Value
        public static final BigInteger GAS_VALUE = BigInteger.valueOf(100_000L);
        // Address of the Ganache Docker. In order to access another docker value must
        // be "http://host.docker.internal:PORT/"
        public static final String GANACHE = "http://host.docker.internal:8545/";
}
