using PastaneMenuVeSiparis.SunumKatmani.ViewModels.MasaViewModels;
using PastaneMenuVeSiparis.SunumKatmani.Views.MasaViews;
using System.Windows;
using System.Windows.Controls;

namespace PastaneMenuVeSiparis.SunumKatmani.Views
{
    /// <summary>
    /// Interaction logic for Masalar.xaml
    /// </summary>
    public partial class Masalar : Page
    {
        public Masalar()
        {
            InitializeComponent();
        }

        private void Masa_1Click(object sender, RoutedEventArgs e)
        {
            MasaDetayListViewModel masaDetayListViewModel = new MasaDetayListViewModel(VarlikKatmani.Enums.Masa.Masa_1);
            MasaDetaylari masaDetaylari = new MasaDetaylari
            {
                Title = "1. Masanın detayları",
                DataContext = masaDetayListViewModel
            };

            masaDetaylari.Show();
        }
        private void Masa_2Click(object sender, RoutedEventArgs e)
        {
            MasaDetayListViewModel masaDetayListViewModel = new MasaDetayListViewModel(VarlikKatmani.Enums.Masa.Masa_2);
            MasaDetaylari masaDetaylari = new MasaDetaylari
            {
                Title = "2. Masanın detayları",
                DataContext = masaDetayListViewModel
            };

            masaDetaylari.Show();
        }
        private void Masa_3Click(object sender, RoutedEventArgs e)
        {
            MasaDetayListViewModel masaDetayListViewModel = new MasaDetayListViewModel(VarlikKatmani.Enums.Masa.Masa_3);
            MasaDetaylari masaDetaylari = new MasaDetaylari
            {
                Title = "3. Masanın detayları",
                DataContext = masaDetayListViewModel
            };

            masaDetaylari.Show();
        }
        private void Masa_4Click(object sender, RoutedEventArgs e)
        {
            MasaDetayListViewModel masaDetayListViewModel = new MasaDetayListViewModel(VarlikKatmani.Enums.Masa.Masa_4);
            MasaDetaylari masaDetaylari = new MasaDetaylari
            {
                Title = "4. Masanın detayları",
                DataContext = masaDetayListViewModel
            };

            masaDetaylari.Show();
        }
        private void Masa_5Click(object sender, RoutedEventArgs e)
        {
            MasaDetayListViewModel masaDetayListViewModel = new MasaDetayListViewModel(VarlikKatmani.Enums.Masa.Masa_5);
            MasaDetaylari masaDetaylari = new MasaDetaylari
            {
                Title = "5. Masanın detayları",
                DataContext = masaDetayListViewModel
            };

            masaDetaylari.Show();
        }
        private void Masa_6Click(object sender, RoutedEventArgs e)
        {
            MasaDetayListViewModel masaDetayListViewModel = new MasaDetayListViewModel(VarlikKatmani.Enums.Masa.Masa_6);
            MasaDetaylari masaDetaylari = new MasaDetaylari
            {
                Title = "6. Masanın detayları",
                DataContext = masaDetayListViewModel
            };

            masaDetaylari.Show();
        }
        private void Masa_7Click(object sender, RoutedEventArgs e)
        {
            MasaDetayListViewModel masaDetayListViewModel = new MasaDetayListViewModel(VarlikKatmani.Enums.Masa.Masa_7);
            MasaDetaylari masaDetaylari = new MasaDetaylari
            {
                Title = "7. Masanın detayları",
                DataContext = masaDetayListViewModel
            };

            masaDetaylari.Show();
        }
        private void Masa_8Click(object sender, RoutedEventArgs e)
        {
            MasaDetayListViewModel masaDetayListViewModel = new MasaDetayListViewModel(VarlikKatmani.Enums.Masa.Masa_8);
            MasaDetaylari masaDetaylari = new MasaDetaylari
            {
                Title = "8. Masanın detayları",
                DataContext = masaDetayListViewModel
            };

            masaDetaylari.Show();
        }
        private void Masa_9Click(object sender, RoutedEventArgs e)
        {
            MasaDetayListViewModel masaDetayListViewModel = new MasaDetayListViewModel(VarlikKatmani.Enums.Masa.Masa_9);
            MasaDetaylari masaDetaylari = new MasaDetaylari
            {
                Title = "9. Masanın detayları",
                DataContext = masaDetayListViewModel
            };

            masaDetaylari.Show();
        }
    }
}