package Ether.INTRANAV.rest.api.openapi;

import java.math.BigInteger;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.util.concurrent.TimeUnit;

import javax.enterprise.context.ApplicationScoped;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.eclipse.microprofile.openapi.annotations.OpenAPIDefinition;
import org.eclipse.microprofile.openapi.annotations.info.Info;
import org.eclipse.microprofile.openapi.annotations.responses.APIResponse;
import org.eclipse.microprofile.openapi.annotations.responses.APIResponses;
import org.eclipse.microprofile.openapi.annotations.tags.Tag;
import org.web3j.crypto.Credentials;
import org.web3j.protocol.Web3j;
import org.web3j.protocol.core.DefaultBlockParameterName;
import org.web3j.protocol.core.methods.response.EthGetBalance;
import org.web3j.protocol.http.HttpService;
import org.web3j.tuples.generated.Tuple11;
import org.web3j.tx.gas.ContractGasProvider;
import org.web3j.tx.gas.StaticGasProvider;

@Tag(name = "External", description = "External Method Handler")
@Path("/External")
@ApplicationScoped
@OpenAPIDefinition(info = @Info(title = "External Functions endpoint", version = "1.0"))
public class External {

        private static Main mainContract;
        private static Assets assetContract;
        private Web3j web3j;

        @APIResponses(value = { @APIResponse(responseCode = "200", description = "OK Response"),
                        @APIResponse(responseCode = "404", description = "Error Response") })

        public void loadMain() {
                System.out.println("Going to load Main contract");
                try {
                        web3j = Web3j.build(new HttpService(Parameters.GANACHE));
                        ContractGasProvider gasProvider = new StaticGasProvider(Parameters.GAS_PRICE,
                                        Parameters.GAS_LIMIT);
                        Credentials credentials = Credentials.create(Parameters.ADMIN_PRIVATE_KEY);

                        mainContract = new Main(Parameters.MAIN_CONTRACT_ADDRESS, web3j, credentials, gasProvider);
                        System.out.println("Load Main contract done!");

                } catch (Exception e) {
                        e.printStackTrace();
                }
        }

        @POST
        @Produces(MediaType.APPLICATION_JSON)
        @Path("requestAccess")
        public Response requestAccess(@QueryParam("duration") String duration, @QueryParam("level") String level,
                        @QueryParam("name") String _name, @QueryParam("email") String _email,
                        @QueryParam("clientID") String _clientID) {
                try {
                        ZoneId zoneId = ZoneId.systemDefault();
                        LocalDateTime dateTime = LocalDateTime.now();
                        long unixTime = dateTime.atZone(zoneId).toEpochSecond();
                        loadMain();
                        mainContract.Create_Rquest(BigInteger.valueOf(unixTime), new BigInteger(duration),
                                        new BigInteger(level), _name, _email, _clientID).send();
                        BigInteger response = mainContract.get_Status().send();

                        return Response.status(Response.Status.OK).entity(response).build();
                } catch (Exception e) {
                        System.out.println(e.toString());
                        throw new javax.ws.rs.ServiceUnavailableException();
                }
        }

        @POST
        @Produces(MediaType.APPLICATION_JSON)
        @Path("transferToken")
        public Response transferToken() {
                try {
                        loadMain();
                        BigInteger weiValue = mainContract.get_TokenAmount().send();
                        mainContract.sendToken(weiValue).send();
                        int response = mainContract.get_Status().send().intValue();
                        if (response == (3)) {
                                TimeUnit.SECONDS.sleep(10);
                                mainContract.upd_Authcode().send();
                        }

                        return Response.status(Response.Status.OK).entity(response).build();
                } catch (Exception e) {
                        System.out.println(e.toString());
                        throw new javax.ws.rs.ServiceUnavailableException();
                }
        }

        @GET
        @Produces(MediaType.APPLICATION_JSON)
        @Path("getStatus")
        public Response getStatus() {
                try {
                        loadMain();
                        BigInteger response;
                        response = mainContract.get_Status().send();
                        return Response.status(Response.Status.OK).entity(response).build();
                } catch (Exception e) {
                        System.out.println(e.toString());
                        throw new javax.ws.rs.ServiceUnavailableException();
                }
        }

        @GET
        @Produces(MediaType.APPLICATION_JSON)
        @Path("getBalance")
        public Response getBalance() {
                try {
                        loadMain();
                        Credentials credentials = Credentials.create(Parameters.CLIENT_PRIVATE_KEY);
                        EthGetBalance response = web3j
                                        .ethGetBalance(credentials.getAddress(), DefaultBlockParameterName.LATEST)
                                        .send();
                        return Response.status(Response.Status.OK).entity(response).build();
                } catch (Exception e) {
                        System.out.println(e.toString());
                        throw new javax.ws.rs.ServiceUnavailableException();
                }
        }

        @GET
        @Produces(MediaType.APPLICATION_JSON)
        @Path("getAmount")
        public Response getAmount() {
                try {
                        loadMain();
                        BigInteger response;
                        response = mainContract.get_TokenAmount().send();
                        return Response.status(Response.Status.OK).entity(response).build();
                } catch (Exception e) {
                        System.out.println(e.toString());
                        throw new javax.ws.rs.ServiceUnavailableException();
                }
        }

        @GET
        @Produces(MediaType.APPLICATION_JSON)
        @Path("getAuth")
        public Response getAuth() {
                try {
                        loadMain();
                        String response;
                        response = mainContract.get_Authcode().send();
                        return Response.status(Response.Status.OK).entity(response).build();
                } catch (Exception e) {
                        System.out.println(e.toString());
                        throw new javax.ws.rs.ServiceUnavailableException();
                }
        }

        @GET
        @Produces(MediaType.APPLICATION_JSON)
        @Path("getRequest")
        public Response getRequest() {
                try {
                        loadMain();
                        Tuple11<String, String, BigInteger, BigInteger, BigInteger, BigInteger, String, String, String, String, BigInteger> response;
                        response = mainContract.get_Request().send();
                        return Response.status(Response.Status.OK).entity(response).build();
                } catch (Exception e) {
                        System.out.println(e.toString());
                        throw new javax.ws.rs.ServiceUnavailableException();
                }
        }
}
