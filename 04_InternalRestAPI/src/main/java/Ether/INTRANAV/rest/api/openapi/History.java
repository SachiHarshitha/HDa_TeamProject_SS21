package Ether.INTRANAV.rest.api.openapi;

import io.reactivex.Flowable;
import io.reactivex.functions.Function;
import java.math.BigInteger;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.concurrent.Callable;
import org.web3j.abi.EventEncoder;
import org.web3j.abi.TypeReference;
import org.web3j.abi.datatypes.Address;
import org.web3j.abi.datatypes.DynamicArray;
import org.web3j.abi.datatypes.Event;
import org.web3j.abi.datatypes.Type;
import org.web3j.abi.datatypes.Utf8String;
import org.web3j.abi.datatypes.generated.Bytes32;
import org.web3j.abi.datatypes.generated.Uint256;
import org.web3j.crypto.Credentials;
import org.web3j.protocol.Web3j;
import org.web3j.protocol.core.DefaultBlockParameter;
import org.web3j.protocol.core.RemoteCall;
import org.web3j.protocol.core.RemoteFunctionCall;
import org.web3j.protocol.core.methods.request.EthFilter;
import org.web3j.protocol.core.methods.response.BaseEventResponse;
import org.web3j.protocol.core.methods.response.Log;
import org.web3j.protocol.core.methods.response.TransactionReceipt;
import org.web3j.tuples.generated.Tuple2;
import org.web3j.tx.Contract;
import org.web3j.tx.TransactionManager;
import org.web3j.tx.gas.ContractGasProvider;

/**
 * <p>Auto generated code.
 * <p><strong>Do not modify!</strong>
 * <p>Please use the <a href="https://docs.web3j.io/command_line.html">web3j command line tools</a>,
 * or the org.web3j.codegen.SolidityFunctionWrapperGenerator in the 
 * <a href="https://github.com/web3j/web3j/tree/master/codegen">codegen module</a> to update.
 *
 * <p>Generated with web3j version 1.4.1.
 */
@SuppressWarnings("rawtypes")
public class History extends Contract {
    public static final String BINARY = "608060405234801561001057600080fd5b50610379806100206000396000f3fe608060405234801561001057600080fd5b50600436106100365760003560e01c8063c2bc2efc1461003b578063d3a5a039146100fa575b600080fd5b6100616004803603602081101561005157600080fd5b50356001600160a01b0316610128565b604051808060200180602001838103835285818151815260200191508051906020019060200280838360005b838110156100a557818101518382015260200161008d565b50505050905001838103825284818151815260200191508051906020019060200280838360005b838110156100e45781810151838201526020016100cc565b5050505090500194505050505060405180910390f35b6101266004803603604081101561011057600080fd5b506001600160a01b038135169060200135610238565b005b60608061013361029f565b6001600160a01b03831660009081526020818152604091829020805483518181528184028101909301909352919060609082801561017b578160200160208202803883390190505b5090506060826040519080825280602002602001820160405280156101aa578160200160208202803883390190505b50905060005b8381101561022b578481815481106101c457fe5b9060005260206000209060020201600001548382815181106101e257fe5b6020026020010181815250508481815481106101fa57fe5b90600052602060002090600202016001015482828151811061021857fe5b60209081029190910101526001016101b0565b5090945092505050915091565b6001600160a01b038216600081815260208181526040808320815180830190925242825281830186815281546001818101845583875285872094516002909202909401908155905192019190915592825252805461029990829081906102c1565b50505050565b3373b8b76e5a4aebbe98d09b5deb92a9505a6df8f1fb146102bf57600080fd5b565b8280548282559060005260206000209060020281019282156103115760005260206000209160020282015b82811115610311578254825560018084015490830155600292830192909101906102ec565b5061031d929150610321565b5090565b61034191905b8082111561031d5760008082556001820155600201610327565b9056fea265627a7a72315820075e2fd6c83fca77afa1cb2fca1a76ccd1227a2a3b42ad04829511206ab4223d64736f6c634300050f0032";

    public static final String FUNC_GET = "get";

    public static final String FUNC_WRITE = "write";

    public static final Event FUNCTIONCALLED_EVENT = new Event("FunctionCalled", 
            Arrays.<TypeReference<?>>asList(new TypeReference<Address>(true) {}, new TypeReference<Utf8String>() {}));
    ;

    @Deprecated
    protected History(String contractAddress, Web3j web3j, Credentials credentials, BigInteger gasPrice, BigInteger gasLimit) {
        super(BINARY, contractAddress, web3j, credentials, gasPrice, gasLimit);
    }

    protected History(String contractAddress, Web3j web3j, Credentials credentials, ContractGasProvider contractGasProvider) {
        super(BINARY, contractAddress, web3j, credentials, contractGasProvider);
    }

    @Deprecated
    protected History(String contractAddress, Web3j web3j, TransactionManager transactionManager, BigInteger gasPrice, BigInteger gasLimit) {
        super(BINARY, contractAddress, web3j, transactionManager, gasPrice, gasLimit);
    }

    protected History(String contractAddress, Web3j web3j, TransactionManager transactionManager, ContractGasProvider contractGasProvider) {
        super(BINARY, contractAddress, web3j, transactionManager, contractGasProvider);
    }

    public List<FunctionCalledEventResponse> getFunctionCalledEvents(TransactionReceipt transactionReceipt) {
        List<Contract.EventValuesWithLog> valueList = extractEventParametersWithLog(FUNCTIONCALLED_EVENT, transactionReceipt);
        ArrayList<FunctionCalledEventResponse> responses = new ArrayList<FunctionCalledEventResponse>(valueList.size());
        for (Contract.EventValuesWithLog eventValues : valueList) {
            FunctionCalledEventResponse typedResponse = new FunctionCalledEventResponse();
            typedResponse.log = eventValues.getLog();
            typedResponse._address = (String) eventValues.getIndexedValues().get(0).getValue();
            typedResponse._name = (String) eventValues.getNonIndexedValues().get(0).getValue();
            responses.add(typedResponse);
        }
        return responses;
    }

    public Flowable<FunctionCalledEventResponse> functionCalledEventFlowable(EthFilter filter) {
        return web3j.ethLogFlowable(filter).map(new Function<Log, FunctionCalledEventResponse>() {
            @Override
            public FunctionCalledEventResponse apply(Log log) {
                Contract.EventValuesWithLog eventValues = extractEventParametersWithLog(FUNCTIONCALLED_EVENT, log);
                FunctionCalledEventResponse typedResponse = new FunctionCalledEventResponse();
                typedResponse.log = log;
                typedResponse._address = (String) eventValues.getIndexedValues().get(0).getValue();
                typedResponse._name = (String) eventValues.getNonIndexedValues().get(0).getValue();
                return typedResponse;
            }
        });
    }

    public Flowable<FunctionCalledEventResponse> functionCalledEventFlowable(DefaultBlockParameter startBlock, DefaultBlockParameter endBlock) {
        EthFilter filter = new EthFilter(startBlock, endBlock, getContractAddress());
        filter.addSingleTopic(EventEncoder.encode(FUNCTIONCALLED_EVENT));
        return functionCalledEventFlowable(filter);
    }

    public RemoteFunctionCall<Tuple2<List<BigInteger>, List<byte[]>>> get(String _client) {
        final org.web3j.abi.datatypes.Function function = new org.web3j.abi.datatypes.Function(FUNC_GET, 
                Arrays.<Type>asList(new org.web3j.abi.datatypes.Address(160, _client)), 
                Arrays.<TypeReference<?>>asList(new TypeReference<DynamicArray<Uint256>>() {}, new TypeReference<DynamicArray<Bytes32>>() {}));
        return new RemoteFunctionCall<Tuple2<List<BigInteger>, List<byte[]>>>(function,
                new Callable<Tuple2<List<BigInteger>, List<byte[]>>>() {
                    @Override
                    public Tuple2<List<BigInteger>, List<byte[]>> call() throws Exception {
                        List<Type> results = executeCallMultipleValueReturn(function);
                        return new Tuple2<List<BigInteger>, List<byte[]>>(
                                convertToNative((List<Uint256>) results.get(0).getValue()), 
                                convertToNative((List<Bytes32>) results.get(1).getValue()));
                    }
                });
    }

    public RemoteFunctionCall<TransactionReceipt> write(String _sender, byte[] _data) {
        final org.web3j.abi.datatypes.Function function = new org.web3j.abi.datatypes.Function(
                FUNC_WRITE, 
                Arrays.<Type>asList(new org.web3j.abi.datatypes.Address(160, _sender), 
                new org.web3j.abi.datatypes.generated.Bytes32(_data)), 
                Collections.<TypeReference<?>>emptyList());
        return executeRemoteCallTransaction(function);
    }

    @Deprecated
    public static History load(String contractAddress, Web3j web3j, Credentials credentials, BigInteger gasPrice, BigInteger gasLimit) {
        return new History(contractAddress, web3j, credentials, gasPrice, gasLimit);
    }

    @Deprecated
    public static History load(String contractAddress, Web3j web3j, TransactionManager transactionManager, BigInteger gasPrice, BigInteger gasLimit) {
        return new History(contractAddress, web3j, transactionManager, gasPrice, gasLimit);
    }

    public static History load(String contractAddress, Web3j web3j, Credentials credentials, ContractGasProvider contractGasProvider) {
        return new History(contractAddress, web3j, credentials, contractGasProvider);
    }

    public static History load(String contractAddress, Web3j web3j, TransactionManager transactionManager, ContractGasProvider contractGasProvider) {
        return new History(contractAddress, web3j, transactionManager, contractGasProvider);
    }

    public static RemoteCall<History> deploy(Web3j web3j, Credentials credentials, ContractGasProvider contractGasProvider) {
        return deployRemoteCall(History.class, web3j, credentials, contractGasProvider, BINARY, "");
    }

    @Deprecated
    public static RemoteCall<History> deploy(Web3j web3j, Credentials credentials, BigInteger gasPrice, BigInteger gasLimit) {
        return deployRemoteCall(History.class, web3j, credentials, gasPrice, gasLimit, BINARY, "");
    }

    public static RemoteCall<History> deploy(Web3j web3j, TransactionManager transactionManager, ContractGasProvider contractGasProvider) {
        return deployRemoteCall(History.class, web3j, transactionManager, contractGasProvider, BINARY, "");
    }

    @Deprecated
    public static RemoteCall<History> deploy(Web3j web3j, TransactionManager transactionManager, BigInteger gasPrice, BigInteger gasLimit) {
        return deployRemoteCall(History.class, web3j, transactionManager, gasPrice, gasLimit, BINARY, "");
    }

    public static class FunctionCalledEventResponse extends BaseEventResponse {
        public String _address;

        public String _name;
    }
}
