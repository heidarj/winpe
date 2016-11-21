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

        public bool isDocked = false;

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
                menuItem.Header = "Dock";
            }
            else {
                AppBarFunctions.SetAppBar(this, ABEdge.Right, dockPanel1, true);
                isDocked = true;
                menuItem.Header = "Undock";
            }
        }

        

        private void image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            image1.Source = new BitmapImage(new Uri(@"C:\Users\heida\OneDrive\Documents\GitHub\winpe\winpe\resources\Creative-Tail-rocket.svg.red.png"));
        }

        private void image1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            image1.Source = new BitmapImage(new Uri (@"C:\Users\heida\OneDrive\Documents\GitHub\winpe\winpe\resources\Creative-Tail-rocket.svg.png"));
            if(popup.IsOpen ==true) { popup.IsOpen = false; }
            else { popup.IsOpen = true; }
        }

        private void image1_MouseEnter(object sender, MouseEventArgs e)
        {
            image1.Source = new BitmapImage(new Uri(@"C:\Users\heida\OneDrive\Documents\GitHub\winpe\winpe\resources\Creative-Tail-rocket.svg.blue.png"));
        }

        private void image1_MouseLeave(object sender, MouseEventArgs e)
        {
            image1.Source = new BitmapImage(new Uri(@"C:\Users\heida\OneDrive\Documents\GitHub\winpe\winpe\resources\Creative-Tail-rocket.svg.png"));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (isDocked) { Dock(); }

            base.OnClosing(e);
        }

        private void dockPanelMenuItemDock_Click(object sender, RoutedEventArgs e)
        {
            Dock();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Dock();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
