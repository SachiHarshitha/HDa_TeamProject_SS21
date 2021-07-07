package Ether.COMPANY.mockapi.openapi;

import java.util.HashMap;
import java.util.Map;

import org.eclipse.microprofile.openapi.annotations.media.Schema;

/**
 * Sample Asset Manager Class
 */
@Schema(name = "AssetManager", description = "AssetManager Class")
public class AssetManager {

    /**
     * Asset Wallet consist of a Map with clientID,Asset key-value pair.
     */
    private static Map<String, Asset> assetDB = new HashMap<>();;

    public Map<String, Asset> getAssetDB() {
        return assetDB;
    }

    /**
     * Constructor for the AssetManager class
     */
    public AssetManager() {
    }

    /**
     * Insert assetDB entry
     * 
     * @param asset : Asset | Type of Asset
     */
    public void Insert(Asset asset) {
        assetDB.put(asset.getAssetId(), asset);
    }

    /**
     * Get asset Entry by asset ID
     * 
     * @param assetID : String | Input Request ID to query for existing asset.
     * @return Authorization | Return a Asset by assetID
     */
    public Asset GetAssetbyID(String assetID) {
        if (assetDB.containsKey(assetID)) {
            return assetDB.get(assetID);
        }
        return null;
    }

    /**
     * Check for existance of an asset entry
     * 
     * @param assetID : String | Input Request ID to query for existing asset.
     * @return status : Boolean | Status of the existence of a given asset ID.
     */
    public boolean Exist(String assetID) {
        return assetDB.containsKey(assetID);
    }

    /**
     * Get Wallet Entries
     * 
     * @param assetID : String | Input Request ID to query for existing asset.
     */
    public void DeleteEntry(String assetID) {
        try {
            assetDB.remove(assetID);
        } catch (Exception e) {
            System.out.println(e.toString());
            e.printStackTrace();
        }
    }
}