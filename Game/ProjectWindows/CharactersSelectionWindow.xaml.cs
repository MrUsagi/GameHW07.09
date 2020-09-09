using Game.BuisnessLogic;
using Game.DataLayer.Models;
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
    /// Interaction logic for CharactersSelectionWindow.xaml
    /// </summary>
    public partial class CharactersSelectionWindow : Window
    {
        private readonly CharactersSelectionService _service;
        public Hero SelectedHero;
        
        public CharactersSelectionWindow(CharactersSelectionService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddCharacterBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterWindow window = App.ServiceProvider.GetRequiredService<AddCharacterWindow>();
            //this.Close();
            window.Show();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _service.LoadHeroes(mainPanel);
            foreach (var button in mainPanel.Children)
            {
                if (button is Button btn)
                {
                    btn.Click += HeroSelect;
                }
            }
        }
        private async void HeroSelect(object sender, RoutedEventArgs e)
        {
            SelectedHero = await _service.PickHero((sender as Button).Content);
            this.Close();
        }
    }
}
