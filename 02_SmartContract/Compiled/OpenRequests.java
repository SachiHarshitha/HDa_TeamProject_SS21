package .;

import java.math.BigInteger;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.concurrent.Callable;
import org.web3j.abi.TypeReference;
import org.web3j.abi.datatypes.Address;
import org.web3j.abi.datatypes.Bool;
import org.web3j.abi.datatypes.DynamicArray;
import org.web3j.abi.datatypes.Function;
import org.web3j.abi.datatypes.Type;
import org.web3j.crypto.Credentials;
import org.web3j.protocol.Web3j;
import org.web3j.protocol.core.RemoteCall;
import org.web3j.protocol.core.RemoteFunctionCall;
import org.web3j.protocol.core.methods.response.TransactionReceipt;
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
public class OpenRequests extends Contract {
    public static final String BINARY = "608060405234801561001057600080fd5b50610431806100206000396000f3fe608060405234801561001057600080fd5b50600436106100575760003560e01c80630a3b0a4f1461005c57806329092d0e146100845780633ded33bc146100aa5780636d4ce63c146100d0578063f6a3d24e14610128575b600080fd5b6100826004803603602081101561007257600080fd5b50356001600160a01b0316610162565b005b6100826004803603602081101561009a57600080fd5b50356001600160a01b03166101d2565b610082600480360360208110156100c057600080fd5b50356001600160a01b03166102a5565b6100d86102cf565b60408051602080825283518183015283519192839290830191858101910280838360005b838110156101145781810151838201526020016100fc565b505050509050019250505060405180910390f35b61014e6004803603602081101561013e57600080fd5b50356001600160a01b031661033a565b604080519115158252519081900360200190f35b6001546001600160a01b0316331461017957600080fd5b600080546001810182557f290decd9548b62a8d60345a988386fc84ba6bc95484008f6362f93160ef3e563810180546001600160a01b039094166001600160a01b03199094168417905591815260026020526040902055565b6001546001600160a01b031633146101e957600080fd5b6001600160a01b03811660009081526002602052604081205481549091908190600019810190811061021757fe5b600091825260208220015481546001600160a01b0390911692508291908490811061023e57fe5b600091825260208083209190910180546001600160a01b0319166001600160a01b0394851617905591831681526002909152604081208390558054906102889060001983016103b5565b5050506001600160a01b0316600090815260026020526040812055565b6102ad610393565b600180546001600160a01b0319166001600160a01b0392909216919091179055565b60606102d9610393565b600080548060200260200160405190810160405280929190818152602001828054801561032f57602002820191906000526020600020905b81546001600160a01b03168152600190910190602001808311610311575b505050505090505b90565b6000805b60005481101561038c57826001600160a01b03166000828154811061035f57fe5b6000918252602090912001546001600160a01b0316141561038457600191505061038e565b60010161033e565b505b919050565b3373b8b76e5a4aebbe98d09b5deb92a9505a6df8f1fb146103b357600080fd5b565b8154818355818111156103d9576000838152602090206103d99181019083016103de565b505050565b61033791905b808211156103f857600081556001016103e4565b509056fea265627a7a72315820cde7356b27408a83ca684cd8b8e5dd8c32ebb4cc01f3ac565aefc40241a1e0fd64736f6c634300050f0032";

    public static final String FUNC_ADD = "add";

    public static final String FUNC_EXISTS = "exists";

    public static final String FUNC_GET = "get";

    public static final String FUNC_REMOVE = "remove";

    public static final String FUNC_SETMAINCONTRACT = "setMainContract";

    @Deprecated
    protected OpenRequests(String contractAddress, Web3j web3j, Credentials credentials, BigInteger gasPrice, BigInteger gasLimit) {
        super(BINARY, contractAddress, web3j, credentials, gasPrice, gasLimit);
    }

    protected OpenRequests(String contractAddress, Web3j web3j, Credentials credentials, ContractGasProvider contractGasProvider) {
        super(BINARY, contractAddress, web3j, credentials, contractGasProvider);
    }

    @Deprecated
    protected OpenRequests(String contractAddress, Web3j web3j, TransactionManager transactionManager, BigInteger gasPrice, BigInteger gasLimit) {
        super(BINARY, contractAddress, web3j, transactionManager, gasPrice, gasLimit);
    }

    protected OpenRequests(String contractAddress, Web3j web3j, TransactionManager transactionManager, ContractGasProvider contractGasProvider) {
        super(BINARY, contractAddress, web3j, transactionManager, contractGasProvider);
    }

    public RemoteFunctionCall<TransactionReceipt> add(String _client) {
        final Function function = new Function(
                FUNC_ADD, 
                Arrays.<Type>asList(new org.web3j.abi.datatypes.Address(160, _client)), 
                Collections.<TypeReference<?>>emptyList());
        return executeRemoteCallTransaction(function);
    }

    public RemoteFunctionCall<Boolean> exists(String _client) {
        final Function function = new Function(FUNC_EXISTS, 
                Arrays.<Type>asList(new org.web3j.abi.datatypes.Address(160, _client)), 
                Arrays.<TypeReference<?>>asList(new TypeReference<Bool>() {}));
        return executeRemoteCallSingleValueReturn(function, Boolean.class);
    }

    public RemoteFunctionCall<List> get() {
        final Function function = new Function(FUNC_GET, 
                Arrays.<Type>asList(), 
                Arrays.<TypeReference<?>>asList(new TypeReference<DynamicArray<Address>>() {}));
        return new RemoteFunctionCall<List>(function,
                new Callable<List>() {
                    @Override
                    @SuppressWarnings("unchecked")
                    public List call() throws Exception {
                        List<Type> result = (List<Type>) executeCallSingleValueReturn(function, List.class);
                        return convertToNative(result);
                    }
                });
    }

    public RemoteFunctionCall<TransactionReceipt> remove(String _client) {
        final Function function = new Function(
                FUNC_REMOVE, 
                Arrays.<Type>asList(new org.web3j.abi.datatypes.Address(160, _client)), 
                Collections.<TypeReference<?>>emptyList());
        return executeRemoteCallTransaction(function);
    }

    public RemoteFunctionCall<TransactionReceipt> setMainContract(String _mainContract) {
        final Function function = new Function(
                FUNC_SETMAINCONTRACT, 
                Arrays.<Type>asList(new org.web3j.abi.datatypes.Address(160, _mainContract)), 
                Collections.<TypeReference<?>>emptyList());
        return executeRemoteCallTransaction(function);
    }

    @Deprecated
    public static OpenRequests load(String contractAddress, Web3j web3j, Credentials credentials, BigInteger gasPrice, BigInteger gasLimit) {
        return new OpenRequests(contractAddress, web3j, credentials, gasPrice, gasLimit);
    }

    @Deprecated
    public static OpenRequests load(String contractAddress, Web3j web3j, TransactionManager transactionManager, BigInteger gasPrice, BigInteger gasLimit) {
        return new OpenRequests(contractAddress, web3j, transactionManager, gasPrice, gasLimit);
    }

    public static OpenRequests load(String contractAddress, Web3j web3j, Credentials credentials, ContractGasProvider contractGasProvider) {
        return new OpenRequests(contractAddress, web3j, credentials, contractGasProvider);
    }

    public static OpenRequests load(String contractAddress, Web3j web3j, TransactionManager transactionManager, ContractGasProvider contractGasProvider) {
        return new OpenRequests(contractAddress, web3j, transactionManager, contractGasProvider);
    }

    public static RemoteCall<OpenRequests> deploy(Web3j web3j, Credentials credentials, ContractGasProvider contractGasProvider) {
        return deployRemoteCall(OpenRequests.class, web3j, credentials, contractGasProvider, BINARY, "");
    }

    @Deprecated
    public static RemoteCall<OpenRequests> deploy(Web3j web3j, Credentials credentials, BigInteger gasPrice, BigInteger gasLimit) {
        return deployRemoteCall(OpenRequests.class, web3j, credentials, gasPrice, gasLimit, BINARY, "");
    }

    public static RemoteCall<OpenRequests> deploy(Web3j web3j, TransactionManager transactionManager, ContractGasProvider contractGasProvider) {
        return deployRemoteCall(OpenRequests.class, web3j, transactionManager, contractGasProvider, BINARY, "");
    }

    @Deprecated
    public static RemoteCall<OpenRequests> deploy(Web3j web3j, TransactionManager transactionManager, BigInteger gasPrice, BigInteger gasLimit) {
        return deployRemoteCall(OpenRequests.class, web3j, transactionManager, gasPrice, gasLimit, BINARY, "");
    }
}
