using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cards;

public class CardDataHeroBase
{
    public static List<CardHero> GetAllHeroCards() 
    {
        return new List<CardHero>
        {
            new CardHero
            {
                id = 111,
                rarity = Rarity.Uncommon,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/2 - Uncommons/Heroes/Boris Brightbeard",
                cardName = "Boris Brightbeard",
                description = "",
                usingCost = 0,
                usingExhaust = true,
                type = Type.Hero,
                cardClass = CardClass.Paladin,
                fraction = Fraction.Alliance,
                race = Race.Dwarf,
                allyClass = AllyClass.Priest,
                baseHp = 26,
                maxHp = 26,
                currentHp = 26,
                heroSkill = HeroSkill.Enhancement | HeroSkill.Tailor | HeroSkill.Holy,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new HealXEffect
                    {
                        when = When.PlayerDecision,
                        target =  Target.ChooseAllEnemyTeam,
                        heal = 0,
                        costX = 0,
                    }
                }
            },
            new CardHero
            {
                id = 116,
                rarity = Rarity.Uncommon,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/2 - Uncommons/Heroes/Moonshadow",
                cardName = "Moonshadow",
                description = "",
                usingCost = 3,
                usingExhaust = true,
                type = Type.Hero,
                cardClass = CardClass.Druid,
                fraction = Fraction.Alliance,
                race = Race.NightElf,
                allyClass = AllyClass.Druid,
                baseHp = 27,
                maxHp = 27,
                currentHp = 27,
                heroSkill = HeroSkill.Restoration | HeroSkill.Alchemy | HeroSkill.Herbalism,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new ShuffleHandEffect
                    {
                        when = When.PlayerDecision,
                        target =  Target.ChooseAllEnemyTeam,
                        shuffleCount = 0,
                    }
                }
            },
            new CardHero
            {
                id = 114,
                rarity = Rarity.Uncommon,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/2 - Uncommons/Heroes/Graccus",
                cardName = "Graccus",
                description = "",
                usingCost = 3,
                usingExhaust = true,
                type = Type.Hero,
                cardClass = CardClass.Paladin,
                fraction = Fraction.Alliance,
                race = Race.Human,
                allyClass = AllyClass.Paladin,
                baseHp = 29,
                maxHp = 29,
                currentHp = 29,
                heroSkill = HeroSkill.Protection | HeroSkill.Blacksmithing | HeroSkill.Mining,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new PreventDamageEffect
                    {
                        when = When.PlayerDecision,
                        target =  Target.ChooseAllEnemyTeam,
                        damageCount = 3,
                    }
                }
            },
            new CardHero
            {
                id = 113,
                rarity = Rarity.Uncommon,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/2 - Uncommons/Heroes/Elendril",
                cardName = "Elendril",
                description = "",
                usingCost = 1,
                usingExhaust = true,
                type = Type.Hero,
                cardClass = CardClass.Hunter,
                fraction = Fraction.Alliance,
                race = Race.NightElf,
                allyClass = AllyClass.Hunter,
                baseHp = 28,
                maxHp = 28,
                currentHp = 28,
                heroSkill = HeroSkill.Marksmanship | HeroSkill.Engineering | HeroSkill.Leatherworking,
                instantOrBasic = InstantOrBasic.Instant,
                effects = new List<ICardEffect>
                {
                    new BuffDamageEffect
                    {
                        when = When.PlayerDecision,
                        target =  Target.EquipmentMy,
                        weaponType = WeaponType.Ranged,
                        buffDamageCount = 3,
                        duration = 1
                    }
                }
            },
            new CardHero
            {
                id = 1115,
                rarity = Rarity.Uncommon,
                image = "Images/Cards/1 - Standart Sets/1 - Azeroth Block/1 - Heroes of Azeroth (2006)/2 - Uncommons/Heroes/Ta_zo",
                cardName = "Ta'zo",
                description = "",
                usingCost = 3,
                usingExhaust = false,
                type = Type.Hero,
                cardClass = CardClass.Mage,
                fraction = Fraction.Horde,
                race = Race.Troll,
                allyClass = AllyClass.Mage,
                baseHp = 25,
                maxHp = 25,
                currentHp = 25,
                heroSkill = HeroSkill.Fire | HeroSkill.Enhancement | HeroSkill.Tailor,
                instantOrBasic = InstantOrBasic.Basic,
                effects = new List<ICardEffect>
                {
                    new DealDamageEffect
                    {
                        when = When.PlayerDecision,
                        target =  Target.EquipmentMy,
                        damage = 3,
                        damageType = DamageType.Fire

                    }
                }
            },
        }; 
    }
}
