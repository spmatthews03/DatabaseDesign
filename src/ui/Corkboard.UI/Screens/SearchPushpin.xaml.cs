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
    /// Interaction logic for SearchPushpin.xaml
    /// </summary>
    public partial class SearchPushpin : Page
    {
        public SearchPushpin(Home previousPage, string searchText)
        {
            InitializeComponent();
            PreviousPage = previousPage;
            SearchText = searchText;
        }

        #region private

        private Home PreviousPage { get; set; }
        private string SearchText { get; set; }

        #endregion
    }
}
