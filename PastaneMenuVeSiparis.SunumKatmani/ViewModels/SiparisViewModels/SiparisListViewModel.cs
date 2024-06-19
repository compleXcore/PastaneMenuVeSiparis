using PastaneMenuVeSiparis.IsKatmani;
using PastaneMenuVeSiparis.SunumKatmani.Commons;
using PastaneMenuVeSiparis.SunumKatmani.ViewModels.MasaViewModels;
using PastaneMenuVeSiparis.SunumKatmani.ViewModels.UrunViewModels;
using PastaneMenuVeSiparis.SunumKatmani.Views.MasaViews;
using PastaneMenuVeSiparis.SunumKatmani.Views.SiparisViews;
using PastaneMenuVeSiparis.SunumKatmani.Views.UrunViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PastaneMenuVeSiparis.SunumKatmani.ViewModels.SiparisViewModels
{
    public class SiparisListViewModel : BaseViewModel
    {
        private ObservableCollection<SiparisViewModel> _items;
        private SiparisViewModel _selectedItem;

        public ObservableCollection<SiparisViewModel> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged();
                }
            }
        }

        public SiparisViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand DetayCommand { get; set; }

        public SiparisListViewModel()
        {
            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            DetayCommand = new RelayCommand(o => { OnDetay(); }, o => { return _selectedItem != null; });

            OnRefresh();
        }

        private void OnRefresh()
        {
            using(SiparisManager siparisManager = new SiparisManager())
            {
                var items = siparisManager.Siparisler();
                Items = new ObservableCollection<SiparisViewModel>();
                foreach (var item in items)
                {
                    Items.Add(new SiparisViewModel(item));
                }
            }
        }

        private void OnDetay()
        {
            var test = _selectedItem.Siparis;

            using(SiparisDetayManager siparisDetayManager = new SiparisDetayManager())
            {
                SiparisDetayListViewModel siparisDetayListViewModel = new SiparisDetayListViewModel(test);

                SiparislerDetayList siparisDetaylari = new SiparislerDetayList
                {
                    Title = "2. Masanın detayları",
                    DataContext = siparisDetayListViewModel
                };

                siparisDetaylari.Show();
            }
        }
    }
}
