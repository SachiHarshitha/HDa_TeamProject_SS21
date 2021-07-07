package Ether.COMPANY.mockapi.openapi;
import javax.crypto.KeyGenerator;
import javax.crypto.SecretKey;

import javax.json.bind.annotation.JsonbProperty;

import org.eclipse.microprofile.openapi.annotations.media.Schema;

/**
 * Authorization Class
 */
@Schema(name="Authorization", description="Authorization Class")
public class Authorization {

    /**
     * Constructor of the Authorization class
     * @param requestKey : String | Input Request ID.
     * @param authToken : String | Authorization Token in order to verify the request sender.
     */
    public Authorization(String requestKey, String authToken) {
        if (authToken.equals(new String("aXrWDpmJbrMRqyg2XpHmfOMV5vYVbCirflSw0ZICQS8="))) {
            try {
                this.requestKey = requestKey;
                KeyGenerator keyGen = KeyGenerator.getInstance("AES");
                keyGen.init(256);
                this.aesKey = keyGen.generateKey();
            } catch (Exception e) {
                System.out.println(e.toString());
                e.printStackTrace();
            }
        }
    }

    /**
     * Getter : requestKey
     * @return requestKey : String | Output Request ID.
     */
    public String getRequestKey() {
        return requestKey;
    }

    /**
     * Getter : aesKey
     * @return aesKey : SecretKey | Output the Secret Key
     */
    public SecretKey getAesKey() {
        return aesKey;
    }

    /**
     * Internal Private Properties of Authorization class
     */
    @JsonbProperty("requestKey")
    private String requestKey;
    @JsonbProperty("authKey")
    private SecretKey aesKey;
}
