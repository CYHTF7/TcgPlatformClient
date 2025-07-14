using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cards;

public static class CardDataAbilityBase
{
    public static List<CardAbility> GetAllAbilityCards()
    {
        return new List<CardAbility>
        {
            new CardAbility
            {
                id = 1133,
                rarity = Rarity.Common,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/1 - Commons/Arcane Shot",
                cardName = "Arcane Shot",
                description = "No card data.",
                manaCost = 2,
                usingCost = 0,
                type = Type.Ability,
                cardClass = CardClass.Hunter,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                abilityType = AbilityType.Marksmanship,
                ongoing = false,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Immediately,
                        target = Target.All,
                        damage = 2,
                        damageType = DamageType.Ranged
                    },
                    new DrawCardEffect
                    {
                        when = When.Immediately,
                        drawCount = 1
                    }
                }
            },
            new CardAbility
            {
                id = 1175,
                rarity = Rarity.Uncommon,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/2 - Uncommons/Touched by Light",
                cardName = "Touched by Light",
                description = "No card data.",
                manaCost = 1,
                usingCost = 0,
                type = Type.Ability,
                cardClass = CardClass.Paladin,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                abilityType = AbilityType.Holy,
                ongoing = false,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new HealEffect
                    {
                        when = When.Immediately,
                        target = Target.All,
                        heal = 2
                    },
                    new DrawCardEffect
                    {
                        when = When.Immediately,
                        target = Target.HeroMy,
                        drawCount = 1
                    }
                }
            },
            new CardAbility
            {
                id = 1154,
                rarity = Rarity.Rare,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/3 - Rares/Flamestrike",
                cardName = "Flamestrike",
                description = "No card data.",
                manaCost = 7,
                usingCost = 0,
                type = Type.Ability,
                cardClass = CardClass.Mage,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                abilityType = AbilityType.Fire,
                ongoing = false,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Immediately,
                        target = Target.All,
                        damage = 3,
                        damageType = DamageType.Fire
                    }
                }
            },
            new CardAbility
            {
                id = 1123,
                rarity = Rarity.Rare,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/3 - Rares/Innervate",
                cardName = "Innervate",
                description = "No card data.",
                manaCost = 4,
                usingCost = 0,
                type = Type.Ability,
                cardClass = CardClass.Druid,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                abilityType = AbilityType.Restoration,
                ongoing = false,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DrawCardEffect
                    {
                        when = When.Immediately,
                        target = Target.ChooseHero,
                        drawCount = 3
                    }
                }
            },
            new CardAbility
            {
                id = 1122,
                rarity = Rarity.Uncommon,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/2 - Uncommons/Healing Touch",
                cardName = "Healing Touch",
                description = "No card data.",
                manaCost = 3,
                usingCost = 0,
                type = Type.Ability,
                cardClass = CardClass.Druid,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                abilityType = AbilityType.Restoration,
                ongoing = false,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new HealEffect
                    {
                        when = When.Immediately,
                        target = Target.ChooseAllMyTeam,
                        heal = 10
                    }
                }
            },
            new CardAbility
            {
                id = 1179,
                rarity = Rarity.Uncommon,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/2 - Uncommons/Heal",
                cardName = "Heal",
                description = "No card data.",
                manaCost = 2,
                usingCost = 0,
                type = Type.Ability,
                cardClass = CardClass.Priest,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                abilityType = AbilityType.Holy,
                ongoing = false,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new HealEffect
                    {
                        when = When.Immediately,
                        target = Target.ChooseAllMyTeam,
                        heal = 7
                    }
                }
            },
            new CardAbility
            {
                id = 1132,
                rarity = Rarity.Rare,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/3 - Rares/Aimed Shot",
                cardName = "Aimed Shot",
                description = "No card data.",
                manaCost = 1,
                usingCost = 0,
                type = Type.Ability,
                cardClass = CardClass.Hunter,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                abilityType = AbilityType.Marksmanship,
                ongoing = false,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageXEffect
                    {
                        when = When.Immediately,
                        target = Target.All,
                        damage = 0,
                        damageX = 1,
                        damageType = DamageType.Ranged,
                        costX = 1
                    }
                }
            },
        };
    }
}
