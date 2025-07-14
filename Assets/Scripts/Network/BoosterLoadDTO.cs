using Newtonsoft.Json;

public class BoosterLoadDTO
{
    [JsonIgnore]
    public int id;

    [JsonProperty("boosterId")]
    public int BoosterId
    {
        get => id;
        set => id = value;
    }

    public int quantity { get; set; }
}

