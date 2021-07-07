package Ether.INTRANAV.rest.api.openapi;

import java.math.BigInteger;
import java.time.LocalDateTime;
import java.util.Arrays;
import java.util.List;
import java.time.ZoneOffset;
import javax.enterprise.context.ApplicationScoped;
import javax.ws.rs.GET;
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
import org.web3j.tuples.generated.Tuple2;
import org.web3j.tx.gas.ContractGasProvider;
import org.web3j.tx.gas.StaticGasProvider;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.SerializationFeature;
import com.fasterxml.jackson.datatype.jsr310.JavaTimeModule;

@Tag(name = "Historical Record", description = "History Contract related functions")
@Path("/history")
@ApplicationScoped
@OpenAPIDefinition(info = @Info(title = "History Functions endpoint", version = "1.0"))
public class History_Controller {
    private static History hist;
    private Web3j web3j;
    private Record[] historyRecords = null;

    private class Record {
        public LocalDateTime get_Timestamp() {
            return timestamp;
        }

        public String get_Data() {
            return Data;
        }

        public Record(LocalDateTime timestamp, String data) {
            this.timestamp = timestamp;
            Data = data;
        }

        private LocalDateTime timestamp;
        private String Data;
    }

    @APIResponses(value = { @APIResponse(responseCode = "200", description = "OK Response"),
            @APIResponse(responseCode = "404", description = "Error Response") })

    public void loadHistory() {
        try {
            web3j = Web3j.build(new HttpService(Parameters.GANACHE));
            ContractGasProvider gasProvider = new StaticGasProvider(Parameters.GAS_PRICE, Parameters.GAS_LIMIT);
            Credentials credentials = Credentials.create(Parameters.ADMIN_PRIVATE_KEY);
            hist = new History(Parameters.HISTORY_CONTRACT_ADDRESS, web3j, credentials, gasProvider);

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    @Path("query/{clientAddress}")
    public Response queryHistory(@PathParam("clientAddress") String _clientAddress) {
        try {
            loadHistory();
            Tuple2<List<BigInteger>, List<byte[]>> response;
            ObjectMapper mapper = new ObjectMapper();
            mapper.registerModule(new JavaTimeModule());
            mapper.disable(SerializationFeature.WRITE_DATES_AS_TIMESTAMPS);
            response = hist.get(_clientAddress).send();
            int entrycount = response.component1().size();
            historyRecords = new Record[entrycount];
            for (int i = 0; i < entrycount; i++) {
                Record record = new Record(
                        LocalDateTime.ofEpochSecond(response.component1().get(i).longValue(), 0, ZoneOffset.UTC),
                        new String(trim(response.component2().get(i))));
                historyRecords[i] = record;
            }
            return Response.status(Response.Status.OK).entity(mapper.writeValueAsString(historyRecords)).build();
        } catch (Exception e) {
            System.out.println(e.toString());
            throw new javax.ws.rs.ServiceUnavailableException();
        }
    }

    static byte[] trim(byte[] bytes) {
        int i = bytes.length - 1;
        while (i >= 0 && bytes[i] == 0) {
            --i;
        }
        return Arrays.copyOf(bytes, i + 1);
    }
}
