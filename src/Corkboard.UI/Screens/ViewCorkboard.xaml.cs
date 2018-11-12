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

namespace Corkboard.UI.Screens
{
    /// <summary>
    /// Interaction logic for ViewCorkboard.xaml
    /// </summary>
    public partial class ViewCorkboard : Page
    {
        public ViewCorkboard(IPage previousPage, Models.User owner, Models.User viewer)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            this.owner = owner;
            this.viewer = viewer;
            GetCorkboard();
            SetTitle();
            SetSwitchButton();
            SetWatch();
        }

        public Models.CorkboardModel Corkboard { get; private set; }

        private void FollowButton_Click(object sender, RoutedEventArgs e)
        {
            // follow owner
        }

        private void SwitchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SwitchButton.Content.Equals("Add PushPin"))
            {
                previousPage.MainWindow.Navigate(new AddPushpin(previousPage.MainWindow, this));
            }

            if (SwitchButton.Content.Equals("Watch"))
            {
                SetWatch();
            }
        }

        #region private

        private Models.User owner;
        private IPage previousPage;
        private Models.User viewer;

        private void GetCorkboard()
        {
            // set corkboard object
            // populate ui
        }

        private void SetTitle()
        {
            TitleBlock.Text = $"{Corkboard.Title} by {owner.Name} - {Corkboard.Category} - Latest update: {Corkboard.LastUpdate}";
        }

        private void SetWatch()
        {
            // call api
            var watchers = Corkboard.Watchers;
            if (watchers.Count == 0)
            {
                WatcherBlock.Text = "No one is watching this corkboard. Be the first!";
            }
            else if (watchers.Count == 1)
            {
                WatcherBlock.Text = "This corkboard has 1 watcher.";
            }
            else
            {
                WatcherBlock.Text = $"This corkboard has {Corkboard.Watchers.Count} watchers.";
            }
        }

        private void SetSwitchButton()
        {
            if (owner.Name.Equals(viewer.Name))
            {
                SwitchButton.Content = "Add PushPin";
            }
            else if (!Corkboard.IsPrivate)
            {
                SwitchButton.Content = "Watch";
            }
        }

        #endregion
    }
}
