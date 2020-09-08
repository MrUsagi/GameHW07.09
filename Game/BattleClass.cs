using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class BattleClass
    {
        SomeLogic logic;
        bool switcher = true;
        int lastSendDamage;
        int lastTakenDAmage;

        string mesageBox;

        public class Hero
        {
            public string name;
            public int basicDamage;
            public int critChance;
            public int critPower;
            public int vortex;
            public int hp;
            public int protection;
        }

        Hero firstHero = new Hero();
        Hero secondHero = new Hero();

        bool FightStep(Hero atacer, Hero defender)
        {
            lastSendDamage = logic.MakeDamage(atacer.basicDamage, atacer.critChance, atacer.critPower);
            lastTakenDAmage = logic.TakeDamage(lastSendDamage, //def hp -= final atacer damage 
             defender.vortex, defender.protection); //& final defender resist
            defender.hp -= lastTakenDAmage;
            if (defender.hp < 1)//defender dead
                return true;
            return false;
            //continue battle
        }
        void BattleFunction()
        {
            if (switcher)
            {
                if (FightStep(firstHero, secondHero))
                    mesageBox = "first hero win";//dead
                mesageBox = firstHero.name + " send " + lastSendDamage + " damage";
                mesageBox = secondHero.name + " got " + lastTakenDAmage + " damage";

            }
            else
            {
                if (FightStep(secondHero, firstHero))
                    Console.WriteLine("second hero win");//dead
                mesageBox = secondHero.name + " send " + lastSendDamage + " damage";
                int blockedDamage = lastSendDamage - lastTakenDAmage;
                mesageBox = firstHero.name + " got " + lastTakenDAmage + " damage (" + blockedDamage + " blocked)";

            }
            switcher = !switcher;
        }

        void NextButtonClick()
        {
            BattleFunction();

        }
    }
}
