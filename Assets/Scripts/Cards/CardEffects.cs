using static UnityEngine.UI.GridLayoutGroup;

namespace Cards 
{
    //effects
    public interface ICardEffect
    {
        public string EffectType { get; }
        public abstract void ApplyEffect();
    }

    public class DealDamageEffect : ICardEffect
    {
        public string EffectType => "DealDamageEffect";

        public When when;
        public Target target;
        public int damage;
        public DamageType damageType;

        public void ApplyEffect()
        {
            //
        }
    }

    public class DealDamageXEffect : ICardEffect
    {
        public string EffectType => "DealDamageXEffect";

        public When when;
        public Target target;
        public int damage;
        public int damageX;
        public DamageType damageType;
        public int costX;

        public void ApplyEffect()
        {
            //
        }
    }


    public class DrawCardEffect : ICardEffect
    {
        public string EffectType => "DrawCardEffect";

        public When when;
        public Target target;
        public int drawCount;

        public void ApplyEffect()
        {
            //
        }
    }

    public class HealEffect : ICardEffect
    {
        public string EffectType => "HealEffect";

        public When when;
        public Target target;
        public int heal;
        public int? useCount = 0;

        public void ApplyEffect()
        {
            //
        }
    }

    public class HealXEffect : ICardEffect
    {
        public string EffectType => "HealXEffect";

        public When when;
        public Target target;
        public int heal;
        public int costX;

        public void ApplyEffect()
        {
            //
        }
    }

    public class ShuffleHandEffect : ICardEffect
    {
        public string EffectType => "ShuffeHandleEffect";

        public When when;
        public Target target;
        public int shuffleCount;

        public void ApplyEffect()
        {
            //
        }
    }

    public class PreventDamageEffect : ICardEffect
    {
        public string EffectType => "PreventlEffect";

        public When when;
        public Target target;
        public int damageCount;

        public void ApplyEffect()
        {
            //
        }
    }

    public class BuffDamageEffect : ICardEffect
    {
        public string EffectType => "BuffDamageEffect";

        public When when;
        public Target target;
        public WeaponType? weaponType;
        public int buffDamageCount;
        public int duration;

        public void ApplyEffect()
        {
            //
        }
    }

}

