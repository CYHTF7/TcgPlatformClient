using Newtonsoft.Json;

namespace Boosters 
{
    public class Booster
    {
        [JsonIgnore]
        public int id;

        [JsonProperty("boosterId")]
        public int BoosterId
        {
            get => id;
            set => id = value;
        }
        public string image;
        public string boosterName;
        public int cost;
    }
}

