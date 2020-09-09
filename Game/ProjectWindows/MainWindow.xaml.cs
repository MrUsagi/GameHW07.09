using Game.BuisnessLogic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowService _service;
        public MainWindow(MainWindowService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void SlelecPlayerBtn1_Click(object sender, RoutedEventArgs e)
        {
            
            CharactersSelectionWindow window = App.ServiceProvider.GetRequiredService<CharactersSelectionWindow>();
            //this.Close();
            window.ShowDialog();
            if(window.SelectedHero != null)
            {
                BattleClass.Attacker = window.SelectedHero;
            }
        }
        private void SlelecPlayerBtn2_Click(object sender, RoutedEventArgs e)
        {

            CharactersSelectionWindow window = App.ServiceProvider.GetRequiredService<CharactersSelectionWindow>();
            //this.Close();
            window.ShowDialog();
            if (window.SelectedHero != null)
            {
                BattleClass.Defender = window.SelectedHero;
            }
        }

        private void FightBtn_Click(object sender, RoutedEventArgs e)
        {
            FightWindow window = App.ServiceProvider.GetRequiredService<FightWindow>();
            //this.Close();
            window.Show();
        }

        private void AddCharacterBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterWindow window = App.ServiceProvider.GetRequiredService<AddCharacterWindow>();
            //this.Close();
            window.Show();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _service.CheckFighters(FightBtn);
        }
    }
}
