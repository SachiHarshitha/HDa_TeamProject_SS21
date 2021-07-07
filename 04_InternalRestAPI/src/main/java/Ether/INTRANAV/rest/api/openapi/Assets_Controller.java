package Ether.INTRANAV.rest.api.openapi;

import javax.enterprise.context.ApplicationScoped;

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
import org.web3j.protocol.http.HttpService;
import org.web3j.tx.gas.ContractGasProvider;
import org.web3j.tx.gas.StaticGasProvider;

@Tag(name = "Assets", description = "Assets Contract related functions")
@Path("/assets")
@ApplicationScoped
@OpenAPIDefinition(info = @Info(title = "Assets Functions endpoint", version = "1.0"))
public class Assets_Controller {
    private static Assets assets;
    private Web3j web3j;

    
    public void loadAssets() {
        System.out.println("Going to load Orders contract");
        try {
            web3j = Web3j.build(new HttpService("http://localhost:8545"));
            ContractGasProvider gasProvider = new StaticGasProvider(Parameters.GAS_PRICE, Parameters.GAS_LIMIT);
            Credentials credentials = Credentials.create(Parameters.ADMIN_PRIVATE_KEY);

            assets = new Assets(Parameters.ASSETS_CONTRACT_ADDRESS, web3j, credentials, gasProvider);
            System.out.println("Load Order contract done!");

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @POST
    @Produces(MediaType.APPLICATION_JSON)
    @Path("init/{address}")
    public Response initOrders(@PathParam("address") String mainAddress) {
        try {
            loadAssets();
            assets.setMainContract(mainAddress).send();
            return Response.status(Response.Status.OK).entity(true).build();
        } catch (Exception e) {
            System.out.println(e.toString());
            throw new javax.ws.rs.ServiceUnavailableException();
        }
    }
}
