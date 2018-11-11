﻿using System;
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

namespace Corkboard.UI.Screens
{
    /// <summary>
    /// Interaction logic for AddCorkboard.xaml
    /// </summary>
    public partial class AddCorkboard : Page
    {
        public AddCorkboard(MainWindow window)
        {
            InitializeComponent();
            MainWindow = window;
            PopulateCategoryDropdown();
        }


        private void VisibilityButton_Private_Checked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Visibility = Visibility.Visible;
        }

        private void VisibilityButton_Private_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Visibility = Visibility.Hidden;
        }

        #region focus events

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Text.Equals("Enter the password for the new Corkboard"))
            {
                PasswordBox.Text = string.Empty;
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Text.Equals(string.Empty))
            {
                PasswordBox.Text = "Enter the password for the new Corkboard";
            }
        }

        private void TitleBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TitleBox.Text.Equals("Title"))
            {
                TitleBox.Text = string.Empty;
            }
        }

        private void TitleBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TitleBox.Text.Equals(string.Empty))
            {
                TitleBox.Text = "Title";
            }
        }

        #endregion

        #region private

        private MainWindow MainWindow { get; set; }

        private void PopulateCategoryDropdown()
        {
            // call api to get categories
            //CatecoryComboBox.Items = ;
        }

        #endregion
    }
}
