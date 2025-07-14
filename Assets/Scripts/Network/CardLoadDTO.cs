using Newtonsoft.Json;

public class CardLoadDTO
{
    [JsonIgnore]
    public int id;

    [JsonProperty("cardId")]
    public int CardId
    {
        get => id;
        set => id = value;
    }

    public int quantity { get; set; }
}
