package Ether.COMPANY.mockapi.openapi;

import javax.json.bind.annotation.JsonbProperty;

import org.eclipse.microprofile.openapi.annotations.media.Schema;

/**
 * Example Asset Class containing Asset ID and Serial Number. This class can be
 * optimized according to the requirements
 */
@Schema(name = "Asset", description = "Dummy Asset Class")
public class Asset {

    public Asset(String assetId, String serialNumber) {
        this.assetId = assetId;
        this.serialNumber = serialNumber;
    }

    public String getAssetId() {
        return assetId;
    }

    public String getSerialNumber() {
        return serialNumber;
    }

    @JsonbProperty("assetId")
    private String assetId;

    @JsonbProperty("serialNumber")
    private String serialNumber;

}
