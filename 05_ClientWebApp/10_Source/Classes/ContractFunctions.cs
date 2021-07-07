using INTRANAV.Contracts.Assets;
using INTRANAV.Contracts.Assets.ContractDefinition;
using INTRANAV.Contracts.Main;
using INTRANAV.Contracts.Main.ContractDefinition;
using INTRANAV_Client_Application.Data;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Net;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace INTRANAV_Client_Application
{
    public class ContractFunctions
    {
        private static string maincontrAddress = @"";
        private static string assetcontrAddress = @"";
        private Web3 web3 = new Web3();

        public static string MaincontrAddress { get => maincontrAddress; set => maincontrAddress = value; }
        public static string AssetcontrAddress { get => assetcontrAddress; set => assetcontrAddress = value; }

        public void Init(string mainAddress, string assetAddress)
        {
            MaincontrAddress = mainAddress;
            AssetcontrAddress = assetAddress;
        }
        private void connect(string privateKey)
        {
            try
            {
                var account = new Account(privateKey);
                var url = new Uri("http://localhost:8545");
                web3 = new Web3(account);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public string getBalance(string privateKey)
        {
            decimal response = 0;
            try
            {
                connect(privateKey);
                var account = new Account(privateKey);
                var balance = web3.Eth.GetBalance.SendRequestAsync(account.Address).Result;
                var etherAmount = Web3.Convert.FromWei(balance.Value);
                response = etherAmount;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get Balance Exception : " + ex.ToString());
            }
            return response.ToString();
        }

        public uint getAssetBalance(string privateKey)
        {
            uint response = 0;
            try
            {
                connect(privateKey);
                AssetsService assetsService = new AssetsService(web3, AssetcontrAddress);
                var account = new Account(privateKey);
                response = assetsService.Get_BalanceQueryAsync().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get Token Amount Exception : " + ex.ToString());
            }
            return response;
        }
        public BigInteger getReqToken(string privateKey)
        {
            BigInteger response = 0;
            try
            {
                connect(privateKey);
                MainService mainContract = new MainService(web3, MaincontrAddress);
                response = mainContract.Get_TokenAmountQueryAsync().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get Token Amount Exception : " + ex.ToString());
            }
            return response;
        }

        public BigInteger getStatus(string privateKey)
        {
            BigInteger response = 0;
            try
            {
                connect(privateKey);
                MainService mainContract = new MainService(web3, MaincontrAddress);
                response = mainContract.Get_StatusQueryAsync().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get Status Exception : " + ex.ToString());
            }
            return response;
        }

        public Request getRequest(string privateKey)
        {
            Request request = new Request();
            try
            {
                connect(privateKey);
                MainService mainContract = new MainService(web3, MaincontrAddress);
                var response = mainContract.Get_RequestQueryAsync().Result;
                if (response != null)
                    request = new Request(response.ReqAddress, response.RelAddress, response.TokenAmount, UnixTimeStampToDateTime(response.OrderDate), response.OrderQty, response.Level, response.AuthCode, response.ClientID, response.Name, response.Email, response.Status);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get Request Exception : " + ex.ToString());
            }
            return request;
        }

        public async void newRequest(Request request, string privateKey)
        {
            try
            {
                connect(privateKey);
                MainService mainContract = new MainService(web3, MaincontrAddress);
                var reqFunction = new Create_RquestFunction();
                reqFunction.OrderDate = DatetimeToUnixTime(request.OrderDate);
                reqFunction.Name = request.Name;
                reqFunction.Email = request.Email;
                reqFunction.ClientID = request.ClientID;
                reqFunction.OrderQty = request.Quantity;
                reqFunction.Level = request.Level;
                reqFunction.Gas = 600000;
                var receiptNRequest = await mainContract.Create_RquestRequestAndWaitForReceiptAsync(reqFunction);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("New Request Exception : " + ex.ToString());
            }
        }

        public async Task transferToken(string privateKey)
        {
            try
            {
                connect(privateKey);
                MainService mainContract = new MainService(web3, MaincontrAddress);
                var sendTFunction = new SendTokenFunction();
                sendTFunction.AmountToSend = getReqToken(privateKey);
                var reciptSendT = await mainContract.SendTokenRequestAndWaitForReceiptAsync(sendTFunction);
                if (reciptSendT.Status.Value == 1)
                {
                    Thread.Sleep(10000);
                    while (String.IsNullOrWhiteSpace(mainContract.Get_AuthcodeQueryAsync().Result))
                    {
                        Thread.Sleep(2000);
                        var response = mainContract.Upd_AuthcodeRequestAndWaitForReceiptAsync();
                        Console.WriteLine(response.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Transfer Token Exception : " + ex.ToString());
            }
        }
        public async Task<Task<string>> add_Sensor(User user, string sensorID, string sensorSerial)
        {
            try
            {
                connect(user.PrivateKey);
                AssetsService assetsService = new AssetsService(web3, AssetcontrAddress);
                var addSfunc = new Register_AssetFunction();
                addSfunc.AssetID = sensorID;
                addSfunc.ClientID = user.ClientID;
                addSfunc.Authcode = WebUtility.UrlEncode(user.Authcode);
                addSfunc.Serial = sensorSerial;
                var receiptAddSens = await assetsService.Register_AssetRequestAndWaitForReceiptAsync(addSfunc);
                Thread.Sleep(5000);
                while (!String.IsNullOrWhiteSpace(assetsService.Upd_ResponseQueryAsync().Result))
                {
                    Thread.Sleep(2000);
                    var response = assetsService.Upd_ResponseQueryAsync();
                    Console.WriteLine(response.ToString());
                }
                return assetsService.Upd_ResponseQueryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Sensor Exception : " + ex.ToString());
                return null;
            }
        }

        public async Task<Task<string>> del_Sensor(User user, string sensorID)
        {
            try
            {
                connect(user.PrivateKey);
                AssetsService assetsService = new AssetsService(web3, AssetcontrAddress);
                var delSfunc = new Del_AssetFunction();
                delSfunc.AssetID = sensorID;
                delSfunc.Authcode = WebUtility.UrlEncode(user.Authcode);
                delSfunc.ClientID = user.ClientID;
                var receiptDelSens = await assetsService.Del_AssetRequestAndWaitForReceiptAsync(delSfunc);
                Thread.Sleep(5000);
                while (!String.IsNullOrWhiteSpace(assetsService.Upd_ResponseQueryAsync().Result))
                {
                    Thread.Sleep(2000);
                    var response = assetsService.Upd_ResponseQueryAsync();
                    Console.WriteLine(response.ToString());
                }
                return assetsService.Upd_ResponseQueryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Sensor Exception : " + ex.ToString());
                return null;
            }
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static uint DatetimeToUnixTime(DateTime timestamp)
        {
            uint unixTimestamp = (uint)(timestamp.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp;
        }
    }
}
