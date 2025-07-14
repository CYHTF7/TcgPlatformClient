using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    public class Card
    {
        [JsonIgnore]
        public int id;

        [JsonProperty("cardId")]
        public int CardId
        {
            get => id;
            set => id = value;
        }
        public int manaCost;
        public Rarity rarity;

        public string image;
        public string cardName;
        public string description;
    }

    public class CardAlly : Card
    {


        public int? usingCost;
        public bool? usingExhaust;
        public Type type; //always ally
        public CardClass cardClass;
        public Rerequirement rerequirement;
        public UniqueType uniqueType;
        //only fot ally
        public Fraction fraction;
        public Race race;
        public AllyClass allyClass;
        public PassiveSkill passiveSkill;
        //for battle 
        public int baseHp;
        public int maxHp;
        public int currentHp;
        public int baseAttack;
        //other
        public InstantOrBasic instantOrBasic;
        public List<ICardEffect> effects;
    }

    public class CardAbility : Card
    {


        public int usingCost;
        public Type type; //always albility
        public CardClass cardClass;
        public Rerequirement rerequirement;
        public UniqueType uniqueType;
        //only for ability
        public AbilityType abilityType;
        //other
        public bool ongoing;
        public InstantOrBasic instantOrBasic;
        public List<ICardEffect> effects;
    }

    public class CardHero : Card
    {


        public int? usingCost;
        public bool? usingExhaust;
        public Type type; //always hero
        public CardClass cardClass;
        //only for hero
        public Fraction fraction;
        public Race race;
        public AllyClass allyClass;
        public HeroSkill heroSkill;
        //for battle
        public int baseHp;
        public int maxHp;
        public int currentHp;
        //other 
        public InstantOrBasic instantOrBasic;
        public List<ICardEffect> effects;
    }
}




