using Game.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Media;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Game.ProjectWindows
{
    /// <summary>
    /// Interaction logic for FifghtWindow.xaml
    /// </summary>
    public partial class FightWindow : Window
    {
        public bool switcher { get; set; }
        //Hero firstHero = new Hero()
        //{ BasicDamage = 10, CritChance = 25, CritPower = 110, Hp = 150, Name = "Gayman", Protection = 35, Vortex = 10 };//Test heroes
        //                                                                                                                // ЭТО НАДО УДАЛИТЬ!!! yt afrn
        //Hero secondHero = new Hero()
        //{ BasicDamage = 15, CritChance = 50, CritPower = 230, Hp = 80, Name = "Vovaman", Protection = 10, Vortex = 25 };//Test heroes

        public FightWindow()
        {
            InitializeComponent();

            Hero1Pb.Maximum = BattleClass.Attacker.Hp;
            Hero2Pb.Maximum = BattleClass.Defender.Hp;
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = @"../Resources/Mortal Kombat.wav";
            player.Play();

        }

        private void NextTurnBtn_Click(object sender, RoutedEventArgs e)
        {
            BattleClass battleClass = new BattleClass();
            BattleLogTb.Text += battleClass.BattleFunction();
            Hero1HpLb.Content = Math.Round(BattleClass.Attacker.Hp, MidpointRounding.ToEven);
            Hero2HpLb.Content = Math.Round(BattleClass.Defender.Hp, MidpointRounding.ToEven);
            Hero1Pb.Value = BattleClass.Attacker.Hp;
            Hero2Pb.Value = BattleClass.Defender.Hp;
            ScrollViewer.ScrollToBottom();
        }
    }
}
