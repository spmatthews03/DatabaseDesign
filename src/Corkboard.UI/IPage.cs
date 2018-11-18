using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Corkboard.UI
{
    public interface IPage
    {
        /// <summary>
        ///  Represents the main window containing the page.
        /// </summary>
        MainWindow MainWindow { get; }

        /// <summary>
        /// Current page.
        /// </summary>
        Page Self { get; }
    }
}
