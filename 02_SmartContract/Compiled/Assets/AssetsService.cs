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
using INTRANAV.Contracts.Assets.ContractDefinition;

namespace INTRANAV.Contracts.Assets
{
    public partial class AssetsService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, AssetsDeployment assetsDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<AssetsDeployment>().SendRequestAndWaitForReceiptAsync(assetsDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, AssetsDeployment assetsDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<AssetsDeployment>().SendRequestAsync(assetsDeployment);
        }

        public static async Task<AssetsService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, AssetsDeployment assetsDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, assetsDeployment, cancellationTokenSource);
            return new AssetsService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public AssetsService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> Del_AssetRequestAsync(Del_AssetFunction del_AssetFunction)
        {
             return ContractHandler.SendRequestAsync(del_AssetFunction);
        }

        public Task<TransactionReceipt> Del_AssetRequestAndWaitForReceiptAsync(Del_AssetFunction del_AssetFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(del_AssetFunction, cancellationToken);
        }

        public Task<string> Del_AssetRequestAsync(string clientID, string authcode, string assetID)
        {
            var del_AssetFunction = new Del_AssetFunction();
                del_AssetFunction.ClientID = clientID;
                del_AssetFunction.Authcode = authcode;
                del_AssetFunction.AssetID = assetID;
            
             return ContractHandler.SendRequestAsync(del_AssetFunction);
        }

        public Task<TransactionReceipt> Del_AssetRequestAndWaitForReceiptAsync(string clientID, string authcode, string assetID, CancellationTokenSource cancellationToken = null)
        {
            var del_AssetFunction = new Del_AssetFunction();
                del_AssetFunction.ClientID = clientID;
                del_AssetFunction.Authcode = authcode;
                del_AssetFunction.AssetID = assetID;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(del_AssetFunction, cancellationToken);
        }

        public Task<string> Del_ClientRequestAsync(Del_ClientFunction del_ClientFunction)
        {
             return ContractHandler.SendRequestAsync(del_ClientFunction);
        }

        public Task<TransactionReceipt> Del_ClientRequestAndWaitForReceiptAsync(Del_ClientFunction del_ClientFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(del_ClientFunction, cancellationToken);
        }

        public Task<string> Del_ClientRequestAsync(string client)
        {
            var del_ClientFunction = new Del_ClientFunction();
                del_ClientFunction.Client = client;
            
             return ContractHandler.SendRequestAsync(del_ClientFunction);
        }

        public Task<TransactionReceipt> Del_ClientRequestAndWaitForReceiptAsync(string client, CancellationTokenSource cancellationToken = null)
        {
            var del_ClientFunction = new Del_ClientFunction();
                del_ClientFunction.Client = client;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(del_ClientFunction, cancellationToken);
        }

        public Task<uint> Get_BalanceQueryAsync(Get_BalanceFunction get_BalanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Get_BalanceFunction, uint>(get_BalanceFunction, blockParameter);
        }

        
        public Task<uint> Get_BalanceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Get_BalanceFunction, uint>(null, blockParameter);
        }

        public Task<uint> Get_TotalQueryAsync(Get_TotalFunction get_TotalFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Get_TotalFunction, uint>(get_TotalFunction, blockParameter);
        }

        
        public Task<uint> Get_TotalQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Get_TotalFunction, uint>(null, blockParameter);
        }

        public Task<string> NewOrderRequestAsync(NewOrderFunction newOrderFunction)
        {
             return ContractHandler.SendRequestAsync(newOrderFunction);
        }

        public Task<TransactionReceipt> NewOrderRequestAndWaitForReceiptAsync(NewOrderFunction newOrderFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(newOrderFunction, cancellationToken);
        }

        public Task<string> NewOrderRequestAsync(string client, uint amount)
        {
            var newOrderFunction = new NewOrderFunction();
                newOrderFunction.Client = client;
                newOrderFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(newOrderFunction);
        }

        public Task<TransactionReceipt> NewOrderRequestAndWaitForReceiptAsync(string client, uint amount, CancellationTokenSource cancellationToken = null)
        {
            var newOrderFunction = new NewOrderFunction();
                newOrderFunction.Client = client;
                newOrderFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(newOrderFunction, cancellationToken);
        }

        public Task<string> Register_AssetRequestAsync(Register_AssetFunction register_AssetFunction)
        {
             return ContractHandler.SendRequestAsync(register_AssetFunction);
        }

        public Task<TransactionReceipt> Register_AssetRequestAndWaitForReceiptAsync(Register_AssetFunction register_AssetFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(register_AssetFunction, cancellationToken);
        }

        public Task<string> Register_AssetRequestAsync(string clientID, string authcode, string assetID, string serial)
        {
            var register_AssetFunction = new Register_AssetFunction();
                register_AssetFunction.ClientID = clientID;
                register_AssetFunction.Authcode = authcode;
                register_AssetFunction.AssetID = assetID;
                register_AssetFunction.Serial = serial;
            
             return ContractHandler.SendRequestAsync(register_AssetFunction);
        }

        public Task<TransactionReceipt> Register_AssetRequestAndWaitForReceiptAsync(string clientID, string authcode, string assetID, string serial, CancellationTokenSource cancellationToken = null)
        {
            var register_AssetFunction = new Register_AssetFunction();
                register_AssetFunction.ClientID = clientID;
                register_AssetFunction.Authcode = authcode;
                register_AssetFunction.AssetID = assetID;
                register_AssetFunction.Serial = serial;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(register_AssetFunction, cancellationToken);
        }

        public Task<string> SetMainContractRequestAsync(SetMainContractFunction setMainContractFunction)
        {
             return ContractHandler.SendRequestAsync(setMainContractFunction);
        }

        public Task<TransactionReceipt> SetMainContractRequestAndWaitForReceiptAsync(SetMainContractFunction setMainContractFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMainContractFunction, cancellationToken);
        }

        public Task<string> SetMainContractRequestAsync(string mainContract)
        {
            var setMainContractFunction = new SetMainContractFunction();
                setMainContractFunction.MainContract = mainContract;
            
             return ContractHandler.SendRequestAsync(setMainContractFunction);
        }

        public Task<TransactionReceipt> SetMainContractRequestAndWaitForReceiptAsync(string mainContract, CancellationTokenSource cancellationToken = null)
        {
            var setMainContractFunction = new SetMainContractFunction();
                setMainContractFunction.MainContract = mainContract;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMainContractFunction, cancellationToken);
        }

        public Task<string> Upd_ResponseQueryAsync(Upd_ResponseFunction upd_ResponseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Upd_ResponseFunction, string>(upd_ResponseFunction, blockParameter);
        }

        
        public Task<string> Upd_ResponseQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Upd_ResponseFunction, string>(null, blockParameter);
        }
    }
}
