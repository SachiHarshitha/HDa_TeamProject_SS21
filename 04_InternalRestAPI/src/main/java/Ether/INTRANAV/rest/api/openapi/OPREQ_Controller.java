package Ether.INTRANAV.rest.api.openapi;

import java.util.List;

import javax.enterprise.context.ApplicationScoped;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import org.eclipse.microprofile.openapi.annotations.responses.APIResponse;
import org.eclipse.microprofile.openapi.annotations.responses.APIResponses;
import org.eclipse.microprofile.openapi.annotations.OpenAPIDefinition;
import org.eclipse.microprofile.openapi.annotations.info.Info;
import org.eclipse.microprofile.openapi.annotations.tags.Tag;
import org.web3j.crypto.Credentials;
import org.web3j.protocol.Web3j;
import org.web3j.protocol.http.HttpService;
import org.web3j.tx.gas.ContractGasProvider;
import org.web3j.tx.gas.StaticGasProvider;

@Tag(name = "Open Requests", description = "Open Request Contract related functions")
@Path("/oprequests")
@ApplicationScoped
@OpenAPIDefinition(info = @Info(title = "Open Request Functions endpoint", version = "1.0"))
public class OPREQ_Controller {
    private static OpenRequests opreqs;
    private Web3j web3j;

    @APIResponses(value = { @APIResponse(responseCode = "200", description = "OK Response"),
            @APIResponse(responseCode = "404", description = "Error Response") })

    public void loadOpenRequests() {
        try {
            web3j = Web3j.build(new HttpService(Parameters.GANACHE));
            ContractGasProvider gasProvider = new StaticGasProvider(Parameters.GAS_PRICE, Parameters.GAS_LIMIT);
            Credentials credentials = Credentials.create(Parameters.ADMIN_PRIVATE_KEY);
            opreqs = new OpenRequests(Parameters.OPREQUESTS_CONTRACT_ADDRESS, web3j, credentials, gasProvider);

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @POST
    @Produces(MediaType.APPLICATION_JSON)
    @Path("initopreqs/{address}")
    public Response initOrders(@PathParam("address") String mainAddress) {
        try {
            loadOpenRequests();
            opreqs.setMainContract(mainAddress).send();
            return Response.status(Response.Status.OK).entity(true).build();
        } catch (Exception e) {
            System.out.println(e.toString());
            throw new javax.ws.rs.ServiceUnavailableException();
        }
    }

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    @Path("get")
    public Response getall() {
        try {
            loadOpenRequests();
            List response = opreqs.get().send();
            return Response.status(Response.Status.OK).entity(response).build();
        } catch (Exception e) {
            System.out.println(e.toString());
            throw new javax.ws.rs.ServiceUnavailableException();
        }
    }







}
