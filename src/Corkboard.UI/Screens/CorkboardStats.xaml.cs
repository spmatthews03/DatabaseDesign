﻿using Corkboard.API.Helpers.ModelHelpers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Corkboard.UI.Screens
{
    /// <summary>
    /// Interaction logic for CorkboardStats.xaml
    /// </summary>
    public partial class CorkboardStats : Page
    {
        public CorkboardStats(Home previousPage)
        {
            InitializeComponent();
            homePage = previousPage;
            DisplayStats();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            homePage.MainWindow.Navigate(homePage);
        }

        #region private

        private object DisplayedUser { get; set; }
        private Home homePage;

        private GridViewColumn CreateGridColumn(string value, double width, string newBinding = null)
        {
            newBinding = newBinding ?? value;
            return new GridViewColumn
            {
                Header = value,
                DisplayMemberBinding = new Binding(newBinding),
                Width = width
            };
        }

        private void DisplayStats()
        {
            var view = new GridView();
            StatsView.View = view;
            view.Columns.Add(CreateGridColumn("User", 185));
            view.Columns.Add(CreateGridColumn("Public Corkboards", 138.9, "PublicCorkboards"));
            view.Columns.Add(CreateGridColumn("Private Corkboards", 144, "PrivateCorkboards"));
            view.Columns.Add(CreateGridColumn("Public Pushpins", 136, "PublicPushpins"));
            view.Columns.Add(CreateGridColumn("Private Pushpins", 136, "PrivatePushpins"));

            var stats = StatHelper.GetCorkboardStats();
            foreach (var stat in stats)
            {
                var item = new { User = stat.User, PublicCorkboards = stat.PublicCorkboards, PrivateCorkboards = stat.PrivateCorkboards, PublicPushpins = stat.PublicPushpins, PrivatePushpins = stat.PrivatePushpins };
                StatsView.Items.Add(item);

                if (item.User.Equals(homePage.MainWindow.User.Name))
                {
                    DisplayedUser = item;
                    StatsView.SelectedItem = item;
                }
            }
        }

        private void StatsView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StatsView.SelectedItem = DisplayedUser;
        }

        #endregion
    }
}
