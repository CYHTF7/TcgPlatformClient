using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cards;
using static UnityEngine.UI.GridLayoutGroup;

public static class CardDataAllyBase
{
    public static List<CardAlly> GetAllAllyCards()
    {
        return new List<CardAlly>
        {
            new CardAlly
            {
                id = 11192,
                rarity = Rarity.Common,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/1 - Commons/Kor Cindervein",
                cardName = "Kor Cindervein",
                description = "No card data.",
                manaCost = 3,
                usingCost = 0,
                usingExhaust = false,
                type = Type.Ally,
                cardClass = CardClass.Paladin,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                fraction = Fraction.Alliance,
                race = Race.Dwarf,
                allyClass = AllyClass.Paladin,
                passiveSkill = PassiveSkill.None,
                baseHp = 3,
                maxHp = 3,
                currentHp = 3,
                baseAttack = 3,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target =  Target.ChooseAllEnemyTeam,
                        damage = 3,
                        damageType = DamageType.Melee,
                    }
                }
            },
            new CardAlly
            {
                id = 11175,
                rarity = Rarity.Common,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/1 - Commons/Anika Berlyn",
                cardName = "Anika Berlyn",
                description = "No card data.",
                manaCost = 5,
                usingCost = 0,
                usingExhaust = false,
                type = Type.Ally,
                cardClass = CardClass.None,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                fraction = Fraction.Neutral,
                race = Race.Human,
                allyClass = AllyClass.Paladin,
                passiveSkill = PassiveSkill.None,
                baseHp = 6,
                maxHp = 6,
                currentHp = 6,
                baseAttack = 5,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target = Target.ChooseAllEnemyTeam,
                        damage = 5,
                        damageType = DamageType.Melee,
                    }
                }
            },
            new CardAlly
            {
                id = 11200,
                rarity = Rarity.Common,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/1 - Commons/Liba Wobblebonk",
                cardName = "Liba Wobblebonk",
                description = "No card data.",
                manaCost = 5,
                usingCost = 0,
                usingExhaust = false,
                type = Type.Ally,
                cardClass = CardClass.None,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                fraction = Fraction.Alliance,
                race = Race.Gnome,
                allyClass = AllyClass.Mage,
                passiveSkill = PassiveSkill.None,
                baseHp = 4,
                maxHp = 4,
                currentHp = 4,
                baseAttack = 3,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target = Target.AllEnemyTeam,
                        damage = 3,
                        damageType = DamageType.Arcane,
                    },
                    new DrawCardEffect
                    {
                        when = When.Immediately,
                        target = Target.HeroMy,
                        drawCount = 1
                    }
                }
            },
            new CardAlly
            {
                id = 11183,
                rarity = Rarity.Common,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/1 - Commons/Freya Lightsworn",
                cardName = "Freya Lightsworn",
                description = "No card data.",
                manaCost = 2,
                usingCost = 0,
                usingExhaust = false,
                type = Type.Ally,
                cardClass = CardClass.None,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                fraction = Fraction.Alliance,
                race = Race.Dwarf,
                allyClass = AllyClass.Priest,
                passiveSkill = PassiveSkill.None,
                baseHp = 2,
                maxHp = 2,
                currentHp = 2,
                baseAttack = 2,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target = Target.AllEnemyTeam,
                        damage = 2,
                        damageType = DamageType.Holy,
                    },
                    new HealEffect
                    {
                        when = When.PlayerDecision,
                        target = Target.ChooseAllMyTeam,
                        heal = 3
                    }
                },
            },
            new CardAlly
            {
                id = 11194,
                rarity = Rarity.Common,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/1 - Commons/Lady Courtney Noel",
                cardName = "Lady Courtney Noel",
                description = "No card data.",
                manaCost = 3,
                usingCost = 0,
                usingExhaust = true,
                type = Type.Ally,
                cardClass = CardClass.None,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                fraction = Fraction.Alliance,
                race = Race.Human,
                allyClass = AllyClass.Priest,
                passiveSkill = PassiveSkill.None,
                baseHp = 4,
                maxHp = 4,
                currentHp = 4,
                baseAttack = 1,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target = Target.AllEnemyTeam,
                        damage = 1,
                        damageType = DamageType.Holy,
                    },
                    new HealEffect
                    {
                        when = When.PlayerDecision,
                        target = Target.ChooseAllMyTeam,
                        heal = 1
                    }
                },
            },
            new CardAlly
            {
                id = 11228,
                rarity = Rarity.Common,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/1 - Commons/Benethor Draigo",
                cardName = "Benethor Draigo",
                description = "No card data.",
                manaCost = 3,
                usingCost = 0,
                usingExhaust = false,
                type = Type.Ally,
                cardClass = CardClass.None,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                fraction = Fraction.Horde,
                race = Race.Undead,
                allyClass = AllyClass.Mage,
                passiveSkill = PassiveSkill.None,
                baseHp = 2,
                maxHp = 2,
                currentHp = 2,
                baseAttack = 4,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target = Target.AllEnemyTeam,
                        damage = 4,
                        damageType = DamageType.Fire,
                    }
                },
            },
            new CardAlly
            {
                id = 11262,
                rarity = Rarity.Common,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/1 - Commons/Vaerik Proudhoof",
                cardName = "Vaerik Proudhoof",
                description = "No card data.",
                manaCost = 4,
                usingCost = 0,
                usingExhaust = false,
                type = Type.Ally,
                cardClass = CardClass.None,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                fraction = Fraction.Horde,
                race = Race.Tauren,
                allyClass = AllyClass.Warrior,
                passiveSkill = PassiveSkill.None,
                baseHp = 3,
                maxHp = 3,
                currentHp = 3,
                baseAttack = 5,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target = Target.AllEnemyTeam,
                        damage = 5,
                        damageType = DamageType.Melee,
                    }
                },
            },
            new CardAlly
            {
                id = 11242,
                rarity = Rarity.Uncommon,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/2 - Uncommons/Hierophant Caydiem",
                cardName = "Hierophant Caydiem",
                description = "No card data.",
                manaCost = 4,
                usingCost = 3,
                usingExhaust = false,
                type = Type.Ally,
                cardClass = CardClass.None,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                fraction = Fraction.Horde,
                race = Race.Tauren,
                allyClass = AllyClass.Druid,
                passiveSkill = PassiveSkill.None,
                baseHp = 4,
                maxHp = 4,
                currentHp = 4,
                baseAttack = 2,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target = Target.AllEnemyTeam,
                        damage = 2,
                        damageType = DamageType.Nature,
                    },
                    new DealDamageEffect
                    {
                        when = When.PlayerDecision,
                        target = Target.AllEnemyTeam,
                        damage = 1,
                        damageType = DamageType.Nature,
                    },
                    new HealEffect
                    {
                        when = When.PlayerDecision,
                        target = Target.ChooseAllMyTeam,
                        heal = 1
                    }
                },
            },
            new CardAlly
            {
                id = 11234,
                rarity = Rarity.Uncommon,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/2 - Uncommons/Deacon Johanna",
                cardName = "Deacon Johanna",
                description = "No card data.",
                manaCost = 2,
                usingCost = 2,
                usingExhaust = false,
                type = Type.Ally,
                cardClass = CardClass.None,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                fraction = Fraction.Horde,
                race = Race.Undead,
                allyClass = AllyClass.Priest,
                passiveSkill = PassiveSkill.None,
                baseHp = 2,
                maxHp = 2,
                currentHp = 2,
                baseAttack = 2,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target = Target.AllEnemyTeam,
                        damage = 2,
                        damageType = DamageType.Holy,
                    },
                    new HealEffect
                    {
                        when = When.PlayerDecision,
                        target = Target.ChooseAllMyTeam,
                        heal = 2,
                        useCount = 1
                    }
                },
            },
            new CardAlly
            {
                id = 11195,
                rarity = Rarity.Epic,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/4 - Epics/Lady Jaina Proudmoore",
                cardName = "Lady Jaina Proudmoore",
                description = "No card data.",
                manaCost = 8,
                usingCost = 0,
                usingExhaust = false,
                type = Type.Ally,
                cardClass = CardClass.None,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.Unique,
                fraction = Fraction.Alliance,
                race = Race.Human,
                allyClass = AllyClass.Mage,
                passiveSkill = PassiveSkill.None,
                baseHp = 4,
                maxHp = 4,
                currentHp = 4,
                baseAttack = 7,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target = Target.AllEnemyTeam,
                        damage = 7,
                        damageType = DamageType.Frost,
                    }
                    //
                },
            },
            new CardAlly
            {
                id = 11267,
                rarity = Rarity.Epic,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/4 - Epics/Warchief Thrall",
                cardName = "Warchief Thrall",
                description = "No card data.",
                manaCost = 9,
                usingCost = 0,
                usingExhaust = false,
                type = Type.Ally,
                cardClass = CardClass.None,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.Unique,
                fraction = Fraction.Horde,
                race = Race.Orc,
                allyClass = AllyClass.Shaman,
                passiveSkill = PassiveSkill.None,
                baseHp = 8,
                maxHp = 8,
                currentHp = 8,
                baseAttack = 7,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target = Target.AllEnemyTeam,
                        damage = 7,
                        damageType = DamageType.Frost,
                    }
                    //
                },
            },
            new CardAlly
            {
                id = 11176,
                rarity = Rarity.Common,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/1 - Commons/Apprentice Teep",
                cardName = "Apprentice Teep",
                description = "No card data.",
                manaCost = 1,
                usingCost = 0,
                usingExhaust = false,
                type = Type.Ally,
                cardClass = CardClass.None,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                fraction = Fraction.Alliance,
                race = Race.Gnome,
                allyClass = AllyClass.Mage,
                passiveSkill = PassiveSkill.Elusive,
                baseHp = 1,
                maxHp = 1,
                currentHp = 1,
                baseAttack = 2,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target =  Target.ChooseAllEnemyTeam,
                        damage = 2,
                        damageType = DamageType.Frost,
                    }
                }
            },
            new CardAlly
            {
                id = 11264,
                rarity = Rarity.Common,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/1 - Commons/Vesh_ral",
                cardName = "Vesh'ral",
                description = "No card data.",
                manaCost = 3,
                usingCost = 0,
                usingExhaust = false,
                type = Type.Ally,
                cardClass = CardClass.None,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                fraction = Fraction.Horde,
                race = Race.Troll,
                allyClass = AllyClass.Mage,
                passiveSkill = PassiveSkill.Ferocity,
                baseHp = 1,
                maxHp = 1,
                currentHp = 1,
                baseAttack = 3,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target =  Target.ChooseAllEnemyTeam,
                        damage = 3,
                        damageType = DamageType.Fire,
                    }
                }
            },
            new CardAlly
            {
                id = 11217,
                rarity = Rarity.Common,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/1 - Commons/Sha_lin Nightwind",
                cardName = "Sha'lin Nightwind",
                description = "No card data.",
                manaCost = 3,
                usingCost = 0,
                usingExhaust = false,
                type = Type.Ally,
                cardClass = CardClass.None,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                fraction = Fraction.Alliance,
                race = Race.NightElf,
                allyClass = AllyClass.Druid,
                passiveSkill = PassiveSkill.Elusive,
                baseHp = 1,
                maxHp = 1,
                currentHp = 1,
                baseAttack = 4,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target =  Target.ChooseAllEnemyTeam,
                        damage = 4,
                        damageType = DamageType.Melee,
                    }
                }
            },
            new CardAlly
            {
                id = 11221,
                rarity = Rarity.Common,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/1 - Commons/Tristan Rapidstrike",
                cardName = "Tristan Rapidstrike",
                description = "No card data.",
                manaCost = 4,
                usingCost = 0,
                usingExhaust = false,
                type = Type.Ally,
                cardClass = CardClass.None,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                fraction = Fraction.Alliance,
                race = Race.NightElf,
                allyClass = AllyClass.Warrior,
                passiveSkill = PassiveSkill.Protector,
                baseHp = 3,
                maxHp = 3,
                currentHp = 3,
                baseAttack = 3,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target =  Target.ChooseAllEnemyTeam,
                        damage = 4,
                        damageType = DamageType.Melee,
                    }
                }
            },
            new CardAlly
            {
                id = 11179,
                rarity = Rarity.Uncommon,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/2 - Uncommons/Braxiss the Sleeper",
                cardName = "Braxiss the Sleeper",
                description = "No card data.",
                manaCost = 6,
                usingCost = 0,
                usingExhaust = false,
                type = Type.Ally,
                cardClass = CardClass.None,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.None,
                fraction = Fraction.Alliance,
                race = Race.NightElf,
                allyClass = AllyClass.Druid,
                passiveSkill = PassiveSkill.Elusive,
                baseHp = 4,
                maxHp = 4,
                currentHp = 4,
                baseAttack = 6,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target =  Target.ChooseAllEnemyTeam,
                        damage = 6,
                        damageType = DamageType.Melee,
                    }
                }
            },
            new CardAlly
            {
                id = 1138,
                rarity = Rarity.RareGold,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/3 - Rares/Fury",
                cardName = "Fury",
                description = "No card data.",
                manaCost = 5,
                usingCost = 0,
                usingExhaust = false,
                type = Type.Ally,
                cardClass = CardClass.Hunter,
                rerequirement = Rerequirement.None,
                uniqueType = UniqueType.Pet,
                fraction = Fraction.Neutral,
                race = Race.Cat,
                allyClass = AllyClass.None,
                passiveSkill = PassiveSkill.Ferocity,
                baseHp = 3,
                maxHp = 3,
                currentHp = 3,
                baseAttack = 5,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.Simple,
                        target =  Target.ChooseAllEnemyTeam,
                        damage = 5,
                        damageType = DamageType.Melee,
                    }
                }
            },
        };
    }
}


