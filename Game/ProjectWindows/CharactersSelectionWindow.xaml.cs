﻿using System;
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
        public CharactersSelectionWindow()
        {
            InitializeComponent();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            this.Close();
            window.Show();
        }

        private void AddCharacterBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterWindow window = new AddCharacterWindow();
            this.Close();
            window.Show();
        }
    }
}
