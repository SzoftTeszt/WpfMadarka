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

namespace WpfMadarka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double Height;
        private double Width;
        private int KattSzam;
        private double SumTime;
        private DateTime CurrentTime;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Height= e.NewSize.Height;
            Width=e.NewSize.Width;
            lbl.Width= Width;
            //lbl.Content = "Szélesség:" + Width + " Magasság:" + Height;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (KattSzam == 0)
            {
                CurrentTime = DateTime.Now;
            }
            else {
                SumTime += (DateTime.Now - CurrentTime).TotalMilliseconds;
                CurrentTime = DateTime.Now;
            }
            Random rnd = new Random();
            Canvas.SetLeft(duolingo, rnd.Next(1, (int)Width-50));
            Canvas.SetTop(duolingo, rnd.Next(50, (int)Height-50));
            KattSzam++;
            if (KattSzam == 10) {
                MessageBox.Show((SumTime / 10).ToString());
                KattSzam = 0;
                SumTime = 0;
            }
        }
    }
}
