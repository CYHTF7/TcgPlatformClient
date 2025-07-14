using System;

namespace Cards
{
    //emums for hero
    [Flags]
    public enum HeroSkill : long
    {
        None = 0,
        Enhancement = 1,
        Fury = 2,
        Holy = 4,
        Marksmanship = 8,
        Fire = 16,
        Restoration = 32,
        Tailor = 64,
        Alchemy = 128,
        Herbalism = 256,
        Protection = 512,
        Blacksmithing = 1024,
        Mining = 2048,
        Engineering = 4096,
        Leatherworking = 8192,
    }

    //enums for ally
    public enum Rarity
    {
        Common,
        //CommonGolg,
        Uncommon,
        //UncommonGold,
        Rare,
        RareGold,
        Epic,
        //EpicGold
    }
    public enum Type
    {
        Ally,
        Ability,
        Equipment,
        Quest,
        Hero
    }
    public enum Fraction
    {
        Neutral,
        Horde,
        Alliance
    }
    public enum Race
    {
        Human,
        NightElf,
        Gnome,
        Troll,
        Dwarf,
        Undead,
        Tauren,
        Orc,
        Cat
    }
    public enum CardClass
    {
        None,
        Priest,
        Warlock,
        Hunter,
        Warrior,
        Paladin,
        Shaman,
        Rogue,
        Mage,
        Druid
    }
    public enum AllyClass
    {
        None,
        Priest,
        Warlock,
        Hunter,
        Warrior,
        Paladin,
        Shaman,
        Rogue,
        Mage,
        Druid
    }

    public enum PassiveSkill
    {
        None,
        Elusive,
        Protector,
        Ferocity
    }

    public enum Rerequirement
    {
        None,
        Protection,
        Horde
    }

    public enum AbilityType
    {
        None,
        Enhancement,
        Fury,
        Holy,
        Marksmanship,
        Fire,
        Restoration

    }

    public enum UniqueType //for max count logic
    {
        None,
        Unique,
        Aspect,
        Pet
    }

    public enum WeaponType
    {
        Ranged,
        Axe

    }

    //enums for effects
    public enum DamageType
    {
        Arcane,
        Fire,
        Frost,
        Holy,
        Melee,
        Nature,
        Ranged,
        Shadow
    }

    public enum Target
    {
        All,
        HeroMy,
        EnemyHero,
        ChooseHero,
        AllyMy,
        AllyEnemy,
        ChooseAllyMy,
        ChooseAllyEnemy,
        AllMyTeam,
        AllEnemyTeam,
        ChooseAllMyTeam,
        ChooseAllEnemyTeam,
        AbilityMy,
        AbilityEnemy,
        EquipmentMy,
        EquipmentEnemy
    }

    public enum When
    {
        Immediately,
        Posthumously,
        PlayerDecision,
        Simple
    }

    public enum InstantOrBasic
    {
        Instant,
        Basic
    }
}


