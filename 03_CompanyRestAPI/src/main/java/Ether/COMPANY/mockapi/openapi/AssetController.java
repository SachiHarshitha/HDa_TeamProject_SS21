package Ether.COMPANY.mockapi.openapi;

import java.util.Base64;
import java.util.HashMap;
import java.util.Map;

import javax.enterprise.context.RequestScoped;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import com.google.gson.Gson;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;

import org.eclipse.microprofile.openapi.annotations.OpenAPIDefinition;
import org.eclipse.microprofile.openapi.annotations.Operation;
import org.eclipse.microprofile.openapi.annotations.info.Info;
import org.eclipse.microprofile.openapi.annotations.media.Content;
import org.eclipse.microprofile.openapi.annotations.responses.APIResponse;
import org.eclipse.microprofile.openapi.annotations.responses.APIResponses;
import org.eclipse.microprofile.openapi.annotations.tags.Tag;

/**
 * Rest Controller Class for the Asset Management
 */
@Tag(name = "Asset", description = "Asset related method handler")
@Path("/asset")
@RequestScoped
@OpenAPIDefinition(info = @Info(title = "Asset Management", version = "1.0"))
public class AssetController {

        private static Map<String, AssetManager> clientDB = new HashMap<>();;

        @APIResponses(value = {
                        @APIResponse(responseCode = "200", description = "Asset Management Database", content = @Content(mediaType = MediaType.APPLICATION_JSON)),
                        @APIResponse(responseCode = "404", description = "Incorrect Auth Token, No Key returned") })

        /**
         *  Register a new asset using the authtoken given to the client
         * @param clientID     : String | Input Request ID
         * @param authToken    : String | Authorization Token in order to access the
         *                     generator.
         * @param assetId       : String | Asset identification ex. MAC address
         * @param serialNumber  : String | Asset Serial Number
         * @return status : Boolean | Return the status
         */
        @GET
        @Produces(MediaType.APPLICATION_JSON)
        @Path("register/{authToken}/{cliendID}/{assetId}/{serialNumber}")
        @Operation(summary = "Register an asset", description = "Requires a Request ID and valid Authentification Token to register a new Key.")
        public Response add_Asset(@PathParam("authToken") String authToken, @PathParam("cliendID") String clientID,
                        @PathParam("assetId") String assetId, @PathParam("serialNumber") String serialNumber) {
                try {
                        if (Base64.getEncoder().encodeToString(
                                        AccessController.wallet.getWalletEntry(clientID).getAesKey().getEncoded())
                                        .equals(authToken)) {
                                Asset asset = new Asset(assetId, serialNumber);

                                // Check if there is any client entry exists related to the Client ID and
                                if (clientDB.containsKey(clientID)) {
                                        clientDB.get(clientID).Insert(asset);
                                } else {
                                        AssetManager assets = new AssetManager();
                                        assets.Insert(asset);
                                        clientDB.put(clientID, assets);
                                }
                        }

                } catch (Exception e) {
                        // If exception has been caught then print the response into the system console
                        // and send the NOT_ACCEPTABLE response.
                        System.out.println(e.toString());
                        return Response.status(Response.Status.NOT_ACCEPTABLE).entity(false).build();
                }
                return Response.status(Response.Status.OK).entity(true).build();
        }

        /**
         * Delete an existing asset.
         * @param clientID     : String | Input Request ID
         * @param authToken    : String | Authorization Token in order to access the
         *                     generator.
         * @param assetId       : String | Asset identification ex. MAC address
         * @return
         */
        @GET
        @Produces(MediaType.APPLICATION_JSON)
        @Path("delete/{authToken}/{clientID}/{assetId}")
        @Operation(summary = "Delete an Asset", description = "Requires a Request ID and valid Authentification Token to delete an existing Key.")
        public Response del_Asset(@PathParam("authToken") String authToken, @PathParam("clientID") String clientID,
                        @PathParam("assetId") String assetId) {
                try {
                        if (Base64.getEncoder().encodeToString(
                                        AccessController.wallet.getWalletEntry(clientID).getAesKey().getEncoded())
                                        .equals(authToken)) {
                                // Check if there is any client entry exists related to the Client ID and
                                if (clientDB.containsKey(clientID)) {
                                        AssetManager entry = clientDB.get(clientID);
                                        entry.DeleteEntry(assetId);
                                        clientDB.put(clientID, entry);
                                }
                                return Response.status(Response.Status.OK).entity(true).build();
                        }
                        return Response.status(Response.Status.OK).entity(false).build();
                } catch (Exception e) {
                        // If exception has been caught then print the response into the system console
                        // and send the NOT_ACCEPTABLE response.
                        System.out.println(e.toString());
                        return Response.status(Response.Status.NOT_ACCEPTABLE).entity(false).build();
                }

        }

        /**
         * Get all the registeres assets under the client
         * @param clientID     : String | Input Request ID
         * @param authToken    : String | Authorization Token in order to access the
         *                     generator.
         * @return assets : String | JSON string containing all the assets registered under the client
         */
        @GET
        @Produces(MediaType.APPLICATION_JSON)
        @Path("getbyID/{authToken}/{clientID}")
        @Operation(summary = "Get Assets registered under client", description = "Requires a Client ID")
        public Response getbyID(@PathParam("authToken") String authToken, @PathParam("clientID") String clientID) {
                String response = "";
                try {
                        // Check if there is any db entry exists related to the client ID
                        if (Base64.getEncoder().encodeToString(
                                        AccessController.wallet.getWalletEntry(clientID).getAesKey().getEncoded())
                                        .equals(authToken)) {
                                if (clientDB.containsKey(clientID)) {
                                        final Gson gson = new Gson();
                                        final JsonElement jsonTree = gson
                                                        .toJsonTree(clientDB.get(clientID).getAssetDB(), Map.class);
                                        final JsonObject jsonObject = new JsonObject();
                                        jsonObject.add("Assets", jsonTree);
                                        response = jsonObject.toString();
                                }
                        }
                } catch (Exception e) {
                        // If exception has been caught then print the response into the system console
                        // and send the NOT_ACCEPTABLE response.
                        System.out.println(e.toString());
                        return Response.status(Response.Status.NOT_ACCEPTABLE).entity(response).build();
                }
                return Response.status(Response.Status.OK).entity(response).build();
        }
}
