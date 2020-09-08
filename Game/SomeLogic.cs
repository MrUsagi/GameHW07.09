using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class SomeLogic
    {
        Random random = new Random();
        public int MakeDamage(int basicDamage, int critChance /*0-100*/, int critPower/*/100+*/)
        {
            if (random.Next(0, 101) >= critChance)
                return basicDamage * critPower; //crit damage
            return basicDamage; //basic non crit damage
        }
        public int TakeDamage(int damage, int vortex /*0-100*/, int protection/*0-100*/)
        {
            if (random.Next(0, 101) >= vortex)
                return damage - (damage / 100 * protection); //damage after protection
            return 0; //miss
        }

    }
}
