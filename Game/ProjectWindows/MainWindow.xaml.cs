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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SlelecPlayerBtn_Click(object sender, RoutedEventArgs e)
        {
            CharactersSelectionWindow window = new CharactersSelectionWindow();
            this.Close();
            window.Show();
        }

        private void FightBtn_Click(object sender, RoutedEventArgs e)
        {
            FightWindow window = new FightWindow();
            this.Close();
            window.Show();
        }

        private void AddCCharacterBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterWindow window = new AddCharacterWindow();
            this.Close();
            window.Show();
        }
    }
}
