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
        Hero firstHero = new Hero()
        { basicDamage = 10, critChance = 25, critPower = 110, hp = 150, name = "Gayman", protection = 35, vortex = 10 };//Test heroes
                                                                                                                        // ЭТО НАДО УДАЛИТЬ!!!
        Hero secondHero = new Hero()
        { basicDamage = 15, critChance = 50, critPower = 230, hp = 80, name = "Vovaman", protection = 10, vortex = 25 };//Test heroes

        public FightWindow()
        {
            InitializeComponent();

            Hero1Pb.Maximum = firstHero.hp;
            Hero2Pb.Maximum = secondHero.hp;
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = @"../Resources/Mortal Kombat.wav";
            player.Play();

        }

        private void NextTurnBtn_Click(object sender, RoutedEventArgs e)
        {

            BattleClass battleClass = new BattleClass();
            BattleLogTb.Text += battleClass.BattleFunction(firstHero,secondHero);
            Hero1HpLb.Content = Math.Round(firstHero.hp, MidpointRounding.ToEven);
            Hero2HpLb.Content = Math.Round(secondHero.hp, MidpointRounding.ToEven);
            Hero1Pb.Value = firstHero.hp;
            Hero2Pb.Value = secondHero.hp;
        }
    }
}
