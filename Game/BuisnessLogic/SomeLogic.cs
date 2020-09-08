using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class SomeLogic
    {
        Random random = new Random();
        public float MakeDamage(float basicDamage, float critChance /*0-100*/, float critPower/*/100+*/)
        {
            if (random.Next(0, 101) <= critChance)
                return basicDamage / 100 * critPower; //crit damage
            return basicDamage; //basic non crit damage
        }
        public float TakeDamage(float damage, float vortex /*0-100*/, float protection/*0-100*/)
        {
            if (random.Next(0, 101) <= vortex)
                return 0; //miss
            return damage - (damage / 100 * protection); //damage after protection
        }

    }
}
