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
using System.Windows.Shapes;

namespace WpfApplicationMobi
{
    /// <summary>
    /// Interaction logic for WindowNav.xaml
    /// </summary>
    public partial class WindowNav : Window
    {
        public WindowNav()
        {
            InitializeComponent();
            NavigationFrame.Navigate(new Page1());
        }

        private void NavigationFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
        }
    }
}
