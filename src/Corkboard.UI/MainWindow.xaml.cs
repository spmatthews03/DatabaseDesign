﻿using Corkboard.API.Models;
using Corkboard.UI.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Corkboard.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigate(new Login(this));
        }

        public void Navigate(Page nextPage)
        {
            if (nextPage.GetType() == typeof(Home))
            {
                Content = new Home(this);
            }
            else
            {
                Content = nextPage;
            }
        }

        public void SetUser(User user)
        {
            User = user;
        }

        public User User { get; private set; }
    }
}
