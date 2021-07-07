package Ether.COMPANY.mockapi.openapi;

import java.util.HashMap;
import java.util.Map;


import org.eclipse.microprofile.openapi.annotations.media.Schema;

/**
 * Authorizations Class
 */
@Schema(name = "Authorizations", description = "Authorizations Class")
public class Authorizations {

    /**
     * Wallet consist of a Map with String, Authorization key-value pair.
     */
    private static Map<String, Authorization> wallet = new HashMap<>();;

    /**
     * Constructor for the Authorizations class
     */
    public Authorizations() {
    }

    /**
     * Insert Wallet Entries
     * 
     * @param authorization : Authorization | Type of Authorization
     */
    public void UpdateWallet(Authorization authorization) {
        wallet.put(authorization.getRequestKey(), authorization);
    }

    /**
     * Get Wallet Entries
     * 
     * @param key : String | Input Request ID to query for existing authorization.
     * @return Authorization | Return a Authorization
     */
    public Authorization getWalletEntry(String key) {
        if (wallet.containsKey(key)) {
            return wallet.get(key);
        }
        return null;
    }

    /**
     * Check for existance of an wallet entry
     * 
     * @param key : String | Input Request ID to query for existing authorization.
     * @return status : Boolean | Status of the existence of a given request ID.
     */
    public boolean existInWallet(String key) {
        return wallet.containsKey(key);
    }

    /**
     * Get Wallet Entries
     * 
     * @param key : String | Input Request ID to query for existing authorization.
     * @return Authorization | Return a Authorization
     */
    public void deleteWalletEntry(String key, String authToken) {
        if (authToken.equals(new String("aXrWDpmJbrMRqyg2XpHmfOMV5vYVbCirflSw0ZICQS8="))) {
            try {
                wallet.remove(key);
            } catch (Exception e) {
                System.out.println(e.toString());
                e.printStackTrace();
            }
        }

    }
}
