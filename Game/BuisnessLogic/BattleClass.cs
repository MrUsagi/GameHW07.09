using Game.DataLayer.Models;
using Game.ProjectWindows;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows.Documents;

namespace Game
{
    public class BattleClass
    {
        public static bool switcher { get; set; } = false;
        public static Hero Attacker { get; set; }
        public static Hero Defender { get; set; }
        SomeLogic logic = new SomeLogic();
        double lastSendDamage;
        double lastTakenDamage;
        double blockedDamage;


        private bool FightStep(Hero atacer, Hero defender)
        {
            lastSendDamage = logic.MakeDamage(Attacker.BasicDamage, Attacker.CritChance, Attacker.CritPower);
            lastTakenDamage = logic.TakeDamage(lastSendDamage, defender.Vortex, defender.Protection); //& final defender resist
            defender.Hp -= lastTakenDamage;
            if (defender.Hp < 1)//defender dead
                return true;
            return false;
            //continue battle
        }
        public string BattleFunction()
        {
            Hero ataker = new Hero();
            Hero defender = new Hero();
            BattleClass.switcher = !switcher;
            if (switcher)
            {
                ataker = Attacker;
                defender = Defender;
            }
            else
            {
                ataker = Defender;
                defender = Attacker;
            }

            if (FightStep(ataker, defender))
                return ataker.Name + " win";

            blockedDamage = lastSendDamage - lastTakenDamage;
            return ataker.Name + " send " + lastSendDamage + " damage\n" + defender.Name + " got " + lastTakenDamage + " damage (" + blockedDamage + " blocked)\n";

        }

    }
}
