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
        public FightWindow()
        {
            InitializeComponent();

            Hero1Pb.Maximum = BattleClass.Attacker.Hp;
            Hero2Pb.Maximum = BattleClass.Defender.Hp;
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = @"../Resources/Mortal Kombat.wav";
            player.Play();

            Player1Img.Source = new BitmapImage(new Uri(BattleClass.Attacker.ImageURL, UriKind.RelativeOrAbsolute));
            Player2Img.Source = new BitmapImage(new Uri(BattleClass.Defender.ImageURL, UriKind.RelativeOrAbsolute));
            Hero1Name.Content = BattleClass.Attacker.Name;
            Hero2Name.Content = BattleClass.Defender.Name;


            
        }

        private void NextTurnBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BattleClass.Attacker.Hp < 0 || BattleClass.Defender.Hp < 0)
            {
                NextTurnBtn.IsEnabled = false;
                return;
            }

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
