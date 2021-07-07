using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using INTRANAV.Contracts.Main.ContractDefinition;

namespace INTRANAV.Contracts.Main
{
    public partial class MainService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, MainDeployment mainDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<MainDeployment>().SendRequestAndWaitForReceiptAsync(mainDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, MainDeployment mainDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<MainDeployment>().SendRequestAsync(mainDeployment);
        }

        public static async Task<MainService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, MainDeployment mainDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, mainDeployment, cancellationTokenSource);
            return new MainService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public MainService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> Acknowledge_RequestRequestAsync(Acknowledge_RequestFunction acknowledge_RequestFunction)
        {
             return ContractHandler.SendRequestAsync(acknowledge_RequestFunction);
        }

        public Task<TransactionReceipt> Acknowledge_RequestRequestAndWaitForReceiptAsync(Acknowledge_RequestFunction acknowledge_RequestFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(acknowledge_RequestFunction, cancellationToken);
        }

        public Task<string> Acknowledge_RequestRequestAsync(string reqAddress, bool acknowledged)
        {
            var acknowledge_RequestFunction = new Acknowledge_RequestFunction();
                acknowledge_RequestFunction.ReqAddress = reqAddress;
                acknowledge_RequestFunction.Acknowledged = acknowledged;
            
             return ContractHandler.SendRequestAsync(acknowledge_RequestFunction);
        }

        public Task<TransactionReceipt> Acknowledge_RequestRequestAndWaitForReceiptAsync(string reqAddress, bool acknowledged, CancellationTokenSource cancellationToken = null)
        {
            var acknowledge_RequestFunction = new Acknowledge_RequestFunction();
                acknowledge_RequestFunction.ReqAddress = reqAddress;
                acknowledge_RequestFunction.Acknowledged = acknowledged;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(acknowledge_RequestFunction, cancellationToken);
        }

        public Task<string> Create_RquestRequestAsync(Create_RquestFunction create_RquestFunction)
        {
             return ContractHandler.SendRequestAsync(create_RquestFunction);
        }

        public Task<TransactionReceipt> Create_RquestRequestAndWaitForReceiptAsync(Create_RquestFunction create_RquestFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(create_RquestFunction, cancellationToken);
        }

        public Task<string> Create_RquestRequestAsync(uint orderDate, uint orderQty, uint level, string name, string email, string clientID)
        {
            var create_RquestFunction = new Create_RquestFunction();
                create_RquestFunction.OrderDate = orderDate;
                create_RquestFunction.OrderQty = orderQty;
                create_RquestFunction.Level = level;
                create_RquestFunction.Name = name;
                create_RquestFunction.Email = email;
                create_RquestFunction.ClientID = clientID;
            
             return ContractHandler.SendRequestAsync(create_RquestFunction);
        }

        public Task<TransactionReceipt> Create_RquestRequestAndWaitForReceiptAsync(uint orderDate, uint orderQty, uint level, string name, string email, string clientID, CancellationTokenSource cancellationToken = null)
        {
            var create_RquestFunction = new Create_RquestFunction();
                create_RquestFunction.OrderDate = orderDate;
                create_RquestFunction.OrderQty = orderQty;
                create_RquestFunction.Level = level;
                create_RquestFunction.Name = name;
                create_RquestFunction.Email = email;
                create_RquestFunction.ClientID = clientID;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(create_RquestFunction, cancellationToken);
        }

        public Task<string> Del_RecordRequestAsync(Del_RecordFunction del_RecordFunction)
        {
             return ContractHandler.SendRequestAsync(del_RecordFunction);
        }

        public Task<TransactionReceipt> Del_RecordRequestAndWaitForReceiptAsync(Del_RecordFunction del_RecordFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(del_RecordFunction, cancellationToken);
        }

        public Task<string> Del_RecordRequestAsync(string client)
        {
            var del_RecordFunction = new Del_RecordFunction();
                del_RecordFunction.Client = client;
            
             return ContractHandler.SendRequestAsync(del_RecordFunction);
        }

        public Task<TransactionReceipt> Del_RecordRequestAndWaitForReceiptAsync(string client, CancellationTokenSource cancellationToken = null)
        {
            var del_RecordFunction = new Del_RecordFunction();
                del_RecordFunction.Client = client;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(del_RecordFunction, cancellationToken);
        }

        public Task<string> Get_AuthcodeQueryAsync(Get_AuthcodeFunction get_AuthcodeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Get_AuthcodeFunction, string>(get_AuthcodeFunction, blockParameter);
        }

        
        public Task<string> Get_AuthcodeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Get_AuthcodeFunction, string>(null, blockParameter);
        }

        public Task<Get_RequestOutputDTO> Get_RequestQueryAsync(Get_RequestFunction get_RequestFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<Get_RequestFunction, Get_RequestOutputDTO>(get_RequestFunction, blockParameter);
        }

        public Task<Get_RequestOutputDTO> Get_RequestQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<Get_RequestFunction, Get_RequestOutputDTO>(null, blockParameter);
        }

        public Task<BigInteger> Get_StatusQueryAsync(Get_StatusFunction get_StatusFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Get_StatusFunction, BigInteger>(get_StatusFunction, blockParameter);
        }

        
        public Task<BigInteger> Get_StatusQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Get_StatusFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> Get_TokenAmountQueryAsync(Get_TokenAmountFunction get_TokenAmountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Get_TokenAmountFunction, BigInteger>(get_TokenAmountFunction, blockParameter);
        }

        
        public Task<BigInteger> Get_TokenAmountQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Get_TokenAmountFunction, BigInteger>(null, blockParameter);
        }

        public Task<Query_RequestOutputDTO> Query_RequestQueryAsync(Query_RequestFunction query_RequestFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<Query_RequestFunction, Query_RequestOutputDTO>(query_RequestFunction, blockParameter);
        }

        public Task<Query_RequestOutputDTO> Query_RequestQueryAsync(string client, BlockParameter blockParameter = null)
        {
            var query_RequestFunction = new Query_RequestFunction();
                query_RequestFunction.Client = client;
            
            return ContractHandler.QueryDeserializingToObjectAsync<Query_RequestFunction, Query_RequestOutputDTO>(query_RequestFunction, blockParameter);
        }

        public Task<string> SendTokenRequestAsync(SendTokenFunction sendTokenFunction)
        {
             return ContractHandler.SendRequestAsync(sendTokenFunction);
        }

        public Task<string> SendTokenRequestAsync()
        {
             return ContractHandler.SendRequestAsync<SendTokenFunction>();
        }

        public Task<TransactionReceipt> SendTokenRequestAndWaitForReceiptAsync(SendTokenFunction sendTokenFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sendTokenFunction, cancellationToken);
        }

        public Task<TransactionReceipt> SendTokenRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<SendTokenFunction>(null, cancellationToken);
        }

        public Task<string> Upd_AuthcodeRequestAsync(Upd_AuthcodeFunction upd_AuthcodeFunction)
        {
             return ContractHandler.SendRequestAsync(upd_AuthcodeFunction);
        }

        public Task<string> Upd_AuthcodeRequestAsync()
        {
             return ContractHandler.SendRequestAsync<Upd_AuthcodeFunction>();
        }

        public Task<TransactionReceipt> Upd_AuthcodeRequestAndWaitForReceiptAsync(Upd_AuthcodeFunction upd_AuthcodeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upd_AuthcodeFunction, cancellationToken);
        }

        public Task<TransactionReceipt> Upd_AuthcodeRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<Upd_AuthcodeFunction>(null, cancellationToken);
        }
    }
}
