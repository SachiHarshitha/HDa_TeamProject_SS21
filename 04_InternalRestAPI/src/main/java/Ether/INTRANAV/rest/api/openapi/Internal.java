package Ether.INTRANAV.rest.api.openapi;

import java.math.BigInteger;

import java.util.List;

import javax.enterprise.context.ApplicationScoped;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.eclipse.microprofile.openapi.annotations.OpenAPIDefinition;
import org.eclipse.microprofile.openapi.annotations.info.Info;
import org.eclipse.microprofile.openapi.annotations.tags.Tag;
import org.web3j.crypto.Credentials;
import org.web3j.protocol.Web3j;
import org.web3j.protocol.core.methods.response.EthAccounts;
import org.web3j.protocol.core.methods.response.EthBlockNumber;
import org.web3j.protocol.http.HttpService;
import org.web3j.tuples.generated.Tuple11;
import org.web3j.tx.gas.ContractGasProvider;
import org.web3j.tx.gas.StaticGasProvider;

@Tag(name = "Internal", description = "Internal Main Contract Method Handler")
@Path("/Internal")
@ApplicationScoped
@OpenAPIDefinition(info = @Info(title = "Internal Functions endpoint", version = "1.0"))
public class Internal {

    private static Main mainContract;
    private Web3j web3j;

    public void loadMain() {
        System.out.println("Going to load Main contract");
        try {
            web3j = Web3j.build(new HttpService(Parameters.GANACHE));
            ContractGasProvider gasProvider = new StaticGasProvider(Parameters.GAS_PRICE, Parameters.GAS_LIMIT);
            Credentials credentials = Credentials.create(Parameters.ADMIN_PRIVATE_KEY);

            mainContract = new Main(Parameters.MAIN_CONTRACT_ADDRESS, web3j, credentials, gasProvider);
            System.out.println("Load Main contract done!");

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    @Path("GetLasBlock")
    public BigInteger getLatestBlockNumber() {
        loadMain();
        EthBlockNumber result = new EthBlockNumber();
        try {
            result = this.web3j.ethBlockNumber().sendAsync().get();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return result.getBlockNumber();
    }

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    @Path("GetAccounts")
    public List<String> getEthAccounts() {
        loadMain();

        EthAccounts result = new EthAccounts();
        try {
            result = this.web3j.ethAccounts().sendAsync().get();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return result.getAccounts();

    }

    @POST
    @Produces(MediaType.APPLICATION_JSON)
    @Path("requestAcknowledge/{reqAddress}/{acknowledged}")
    public Response requestAcknowledge(@PathParam("reqAddress") String reqAddress,
            @PathParam("acknowledged") boolean acknowledged) {
        try {
            loadMain();
            BigInteger response;
            mainContract.Acknowledge_Request(reqAddress, acknowledged).send();
            response = mainContract.get_Status().send();
            return Response.status(Response.Status.OK).entity(response).build();
        } catch (Exception e) {
            System.out.println(e.toString());
            throw new javax.ws.rs.ServiceUnavailableException();
        }
    }


    @POST
    @Produces(MediaType.APPLICATION_JSON)
    @Path("requestDelete/{reqAddress}")
    public Response requestDelete(@PathParam("reqAddress") String _reqAddress) {
        try {
            loadMain();
            mainContract.del_Record(_reqAddress).send();
            return Response.status(Response.Status.OK).entity(true).build();
        } catch (Exception e) {
            System.out.println(e.toString());
            throw new javax.ws.rs.ServiceUnavailableException();
        }
    }

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    @Path("queryRequest/{reqAddress}")
    public Response queryRequest(@PathParam("reqAddress") String _reqAddress) {
        try {
            loadMain();
            Tuple11<String, String, BigInteger, BigInteger, BigInteger, BigInteger, String, String, String, String, BigInteger> response;
            response = mainContract.query_Request(_reqAddress).send();
            return Response.status(Response.Status.OK).entity(response).build();
        } catch (Exception e) {
            System.out.println(e.toString());
            throw new javax.ws.rs.ServiceUnavailableException();
        }
    }

}
