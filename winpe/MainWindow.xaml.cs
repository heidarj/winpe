using System;
using System.Collections.Generic;
using System.IO;
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
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;
using WpfAppBar;

namespace winpe {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PixieLauncher : Window {
        public PixieLauncher() {
            InitializeComponent();
        }

        bool isDocked = false;

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            //Dock();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            Dock();
        }

        public void Dock() {
            if (isDocked) {
                AppBarFunctions.SetAppBar(this, ABEdge.None);
                isDocked = false;
                menuItemDock.Header = "Dock";
            }
            else {
                AppBarFunctions.SetAppBar(this, ABEdge.Right, image1, true);
                isDocked = true;
                menuItemDock.Header = "Undock";
            }
        }

        private void image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            image1.Opacity = 70;
        }

        private void image1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            image1.Opacity = 100;
            Dock();
        }
    }
}
