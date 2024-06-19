using System;
using System.Windows;
using System.Windows.Input;

namespace PastaneMenuVeSiparis.SunumKatmani
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            txtTitle.Text = "Masalar";
        }

        #region Window Controls...
        private void ColorZone_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnTamEkran_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void btnSimge_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        #endregion

        private void Masalar(object sender, RoutedEventArgs e)
        {
            mainFrame.Source = new Uri("/Views/MasaViews/Masalar.xaml", UriKind.Relative);
            myDrawer.IsLeftDrawerOpen = false;
            txtTitle.Text = "Masalar";
        }

        private void Kategoriler(object sender, RoutedEventArgs e)
        {
            mainFrame.Source = new Uri("/Views/KategoriViews/KategoriListView.xaml", UriKind.Relative);
            myDrawer.IsLeftDrawerOpen = false;
            txtTitle.Text = "Kategoriler";
        }

        private void Urunler(object sender, RoutedEventArgs e)
        {
            mainFrame.Source = new Uri("/Views/UrunViews/UrunListView.xaml", UriKind.Relative);
            myDrawer.IsLeftDrawerOpen = false;
            txtTitle.Text = "Ürünler";
        }
        private void Siparisler(object sender, RoutedEventArgs e)
        {
            mainFrame.Source = new Uri("/Views/SiparisViews/SiparislerList.xaml", UriKind.Relative);
            myDrawer.IsLeftDrawerOpen = false;
            txtTitle.Text = "Siparişler";
        }
    }
}