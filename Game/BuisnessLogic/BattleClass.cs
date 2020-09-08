using Game.ProjectWindows;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows.Documents;

namespace Game
{
    partial class BattleClass
    {
        public static bool switcher { get; set; } = false;
        SomeLogic logic = new SomeLogic();
        float lastSendDamage;
        float lastTakenDamage;
        float blockedDamage;


        private bool FightStep(Hero atacer, Hero defender)
        {
            lastSendDamage = logic.MakeDamage(atacer.basicDamage, atacer.critChance, atacer.critPower);
            lastTakenDamage = logic.TakeDamage(lastSendDamage, defender.vortex, defender.protection); //& final defender resist
            defender.hp -= lastTakenDamage;
            if (defender.hp < 1)//defender dead
                return true;
            return false;
            //continue battle
        }
        public string BattleFunction(Hero firstHero, Hero secondHero)
        {
            Hero ataker = new Hero();
            Hero defender = new Hero();
            BattleClass.switcher = !switcher;
            if (switcher)
            {
                ataker = firstHero;
                defender = secondHero;
            }
            else
            {
                ataker = secondHero;
                defender = firstHero;
            }

            if (FightStep(ataker, defender))
                return ataker.name + " win";

            blockedDamage = lastSendDamage - lastTakenDamage;
            return ataker.name + " send " + lastSendDamage + " damage\n" + defender.name + " got " + lastTakenDamage + " damage (" + blockedDamage + " blocked)\n";

        }

    }
}
