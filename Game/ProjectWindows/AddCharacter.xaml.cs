using Game.BuisnessLogic;
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
    /// Interaction logic for AddCharacter.xaml
    /// </summary>
    public partial class AddCharacterWindow : Window
    {
        private readonly AddCharacterService _service;
        public AddCharacterWindow(AddCharacterService service)
        {
            InitializeComponent();
            _service = service;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await _service.AddHero(nameBox.Text, damageBox.Text, critChanceBox.Text, critPowerBox.Text, dodgeChanceBox.Text, armorBox.Text, hpBox.Text);
            this.Close();
        }

        private async void Box_KeyUp(object sender, KeyEventArgs e)
        {
            if(sender is TextBox box)
            {
                if (!await _service.Validation(box.Text))
                {
                    box.BorderBrush = Brushes.Red;
                }
                else
                    box.BorderBrush = Brushes.Black;
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _service.CheckData(saveBtn,mainGrid);
        }
    }
}
