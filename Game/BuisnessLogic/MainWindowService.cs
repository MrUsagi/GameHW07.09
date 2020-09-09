using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;

namespace Game.BuisnessLogic
{
    public class MainWindowService
    {
        private Button btnToCheck;
        public async Task CheckFighters(Button btn)
        {
            btnToCheck = btn;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Check;
            timer.AutoReset = true;
            timer.Start();
        }

        private void Check(object sender, ElapsedEventArgs e)
        {
            if(BattleClass.Attacker != null && BattleClass.Defender != null)
            {
                btnToCheck.Dispatcher.Invoke(() => { btnToCheck.IsEnabled = true; });
                
            }
        }
    }
}
