package Ether.COMPANY.mockapi.openapi;

import org.eclipse.microprofile.openapi.annotations.OpenAPIDefinition;
import org.eclipse.microprofile.openapi.annotations.Operation;
import org.eclipse.microprofile.openapi.annotations.info.Info;
import org.eclipse.microprofile.openapi.annotations.media.Content;
import org.eclipse.microprofile.openapi.annotations.responses.APIResponse;
import org.eclipse.microprofile.openapi.annotations.responses.APIResponses;
import org.eclipse.microprofile.openapi.annotations.tags.Tag;

import java.util.Base64;
import javax.crypto.SecretKey;

import javax.enterprise.context.RequestScoped;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

/**
 * Rest Controller Class for the Authentification Token Generator
 */
@Path("/user")
@Tag(name = "User", description = "User Authentification Handler")
@RequestScoped
@OpenAPIDefinition(info = @Info(title = "AES Auth endpoint", version = "1.0"))
public class AccessController {

        // Instantiate a Authorization class.
        public static Authorizations wallet = new Authorizations();

        @APIResponses(value = {
                        @APIResponse(responseCode = "200", description = "AES Security Key", content = @Content(mediaType = MediaType.APPLICATION_JSON)),
                        @APIResponse(responseCode = "404", description = "Incorrect Auth Token, No Key returned") })

        /**
         * Register a new client and get new auth Key API function
         * 
         * @param clientID  : String | Input Request ID
         * @param authToken : String | Authorization Token in order to access the
         *                  generator.
         * @return secretkey : Response | Response contained with the Auth Token.
         */

        @GET
        @Produces(MediaType.APPLICATION_JSON)
        @Path("new/{authToken}/{reqID}")
        @Operation(summary = "Register a new reqID and return the new Key", description = "Requires a Request ID  and valid Authentification Token to generate a new Key.")
        public Response getKey(@PathParam("reqID") String reqID, @PathParam("authToken") String authToken) {
                String key = "";
                try {
                        // Check if there is any wallet entry exists related to the Request ID
                        // If does not exist then create a new entry.
                        if (!wallet.existInWallet(reqID)) {
                                Authorization auth = new Authorization(reqID, authToken);
                                wallet.UpdateWallet(auth);
                                SecretKey secretKey = auth.getAesKey();
                                key = Base64.getEncoder().encodeToString(secretKey.getEncoded());
                        }
                        // If exist get the existing code
                        else {
                                key = Base64.getEncoder()
                                                .encodeToString(wallet.getWalletEntry(reqID).getAesKey().getEncoded());
                        }
                        // key = new JSONObject().put("Key", key).toString();

                } catch (Exception e) {
                        // If exception has been caught then print the response into the system console
                        // and send the NOT_ACCEPTABLE response.
                        System.out.println(e.toString());
                        return Response.status(Response.Status.NOT_ACCEPTABLE).entity(key).build();
                }
                return Response.status(Response.Status.OK).entity(key).build();
        }

        /**
         * Delete an existing client account Key API function
         * 
         * @param clientID  : String | Input Request ID
         * @param authToken : String | Authorization Token in order to access the
         *                  generator.
         * @return response : boolean | Return status whether clientID exist.
         */
        @GET
        @Produces(MediaType.APPLICATION_JSON)
        @Path("delete/{authToken}/{clientID}")
        @Operation(summary = "Delete an existing Key", description = "Requires a Request ID and valid Authentification Token to delete a new Key.")
        public Response deleteKey(@PathParam("clientID") String clientID, @PathParam("authToken") String authToken) {
                try {
                        // Check if there is any wallet entry exists related to the Request ID and
                        // delete it
                        if (wallet.existInWallet(clientID)) {
                                wallet.deleteWalletEntry(clientID, authToken);
                        }
                } catch (Exception e) {
                        // If exception has been caught then print the response into the system console
                        // and send the NOT_ACCEPTABLE response.
                        System.out.println(e.toString());
                        return Response.status(Response.Status.NOT_ACCEPTABLE).entity(false).build();
                }
                return Response.status(Response.Status.OK).entity(wallet.existInWallet(clientID)).build();
        }

        /**
         * Simple Get API function to check if client ID exist in the Database
         * 
         * @param clientID : String | Input Request ID
         * @return status : Boolean | Status
         */
        @GET
        @Produces(MediaType.APPLICATION_JSON)
        @Path("keyexist/{clientID}")
        @Operation(summary = "Check if key exist", description = "Requires a Request ID ")
        public Response keyExist(@PathParam("clientID") String clientID) {
                try {
                        // Check if there is any wallet entry exists related to the Request ID
                        return Response.status(Response.Status.OK).entity(wallet.existInWallet(clientID)).build();

                } catch (Exception e) {
                        // If exception has been caught then print the response into the system console
                        // and send the NOT_ACCEPTABLE response.
                        System.out.println(e.toString());
                        return Response.status(Response.Status.NOT_ACCEPTABLE).entity(false).build();
                }
        }
}
