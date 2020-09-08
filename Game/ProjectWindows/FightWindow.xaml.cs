﻿using System;
using System.Collections.Generic;
using System.Media;
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
        public FightWindow()
        {
            InitializeComponent();
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = @"../Resources/Mortal Kombat.wav";
            player.Play();
        }
    }
}
