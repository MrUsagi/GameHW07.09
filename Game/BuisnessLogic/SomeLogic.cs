using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class SomeLogic
    {
        Random random = new Random();
        public double MakeDamage(double basicDamage, double critChance /*0-100*/, double critPower/*/100+*/)
        {
            if (random.Next(0, 101) <= critChance)
                return basicDamage / 100 * critPower; //crit damage
            return basicDamage; //basic non crit damage
        }
        public double TakeDamage(double damage, double vortex /*0-100*/, double protection/*0-100*/)
        {
            if (random.Next(0, 101) <= vortex)
                return 0; //miss
            return damage - (damage / 100 * protection); //damage after protection
        }

    }
}
