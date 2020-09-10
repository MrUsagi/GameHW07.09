using Game.DataLayer.Models;
using Game.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Media;

namespace Game.BuisnessLogic
{
    public class AddCharacterService
    {
        private readonly HeroesRepository _repository;
        private Button btnToCheck;
        private Panel gridToCheck;
        public AddCharacterService(HeroesRepository repository)
        {
            _repository = repository;
        }

        public async Task AddHero(string name, string damage, string critChance, string critPower, string dodge, string armor, string hp)
        {
            await _repository.CreateAsync(new Hero()
            {
                Name = name,
                BasicDamage = Convert.ToDouble(damage),
                CritChance = Convert.ToDouble(critChance),
                CritPower = Convert.ToDouble(critPower),
                Vortex = Convert.ToDouble(dodge),
                Protection = Convert.ToDouble(armor),
                Hp = Convert.ToDouble(hp)
            });
        }
        public async Task<bool> Validation(string text)
        {
            return double.TryParse(text, out var res);
        }
        public void CheckData(Button btn, Panel panel)
        {
            btnToCheck = btn;
            gridToCheck = panel;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Check;
            timer.AutoReset = true;
            timer.Start();
        }

        private void Check(object sender, ElapsedEventArgs e)
        {
            gridToCheck.Dispatcher.Invoke(() =>
            {
                var validation = false;
                foreach (var item in gridToCheck.Children)
                {
                    if (item is TextBox box)
                    {
                        if (box.BorderBrush == Brushes.Red)
                        {
                            validation = false;
                        }
                        else
                            validation = true;
                    }
                }
                btnToCheck.Dispatcher.Invoke(() => { btnToCheck.IsEnabled = validation; });
            });

        }
    }
}
