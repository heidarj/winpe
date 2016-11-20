using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using winpe;

namespace PixieLauncher {
    /// <summary>
    /// Interaction logic for menu.xaml
    /// </summary>
    public partial class menu : UserControl {

        static string windrive = System.IO.Path.GetPathRoot(Environment.SystemDirectory);
        static string toolsDir = windrive + @"Tools\";

        public menu() {
            InitializeComponent();
            string[] tools = Directory.GetFiles(toolsDir);
            Console.WriteLine(tools[0]);

            foreach (string tool in tools) {
                FileInfo fi = new FileInfo(tool);
                if ((fi.Extension == ".exe") || (fi.Extension == ".lnk") || (fi.Extension == ".bat")) {
                    Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(tool);
                    shortcut a = new winpe.shortcut();
                    a.image.Source = loadBitmap(icon.ToBitmap());
                    a.label.Content = System.IO.Path.GetFileNameWithoutExtension(tool);
                    a.MouseDown += new MouseButtonEventHandler(button_Click);
                    a.path = tool;
                    a.Margin = new Thickness(6, 6, 6, 6);

                    wrapPanel.Children.Add(a);
                }
            }
        }

        [DllImport("gdi32")]
        static extern int DeleteObject(IntPtr o);

        public static BitmapSource loadBitmap(Bitmap source) {
            IntPtr ip = source.GetHbitmap();
            BitmapSource bs = null;
            try {
                bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ip,
                   IntPtr.Zero, Int32Rect.Empty,
                   BitmapSizeOptions.FromEmptyOptions());
            }
            finally {
                DeleteObject(ip);
            }

            return bs;
        }

        void button_Click(object sender, RoutedEventArgs e) {
            shortcut b = sender as shortcut;
            Process proc = new Process();
            proc.StartInfo.FileName = b.path;
            proc.Start();
        }
    }
}
