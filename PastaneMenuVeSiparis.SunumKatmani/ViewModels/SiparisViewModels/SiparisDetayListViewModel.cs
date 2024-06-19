using PastaneMenuVeSiparis.IsKatmani;
using PastaneMenuVeSiparis.SunumKatmani.Commons;
using PastaneMenuVeSiparis.SunumKatmani.ViewModels.MasaViewModels;
using PastaneMenuVeSiparis.SunumKatmani.Views.MasaViews;
using PastaneMenuVeSiparis.VarlikKatmani.Enums;
using PastaneMenuVeSiparis.VarlikKatmani;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PastaneMenuVeSiparis.SunumKatmani.Views.SiparisViews;
using static System.Net.Mime.MediaTypeNames;
using MaterialDesignThemes.Wpf;

namespace PastaneMenuVeSiparis.SunumKatmani.ViewModels.SiparisViewModels
{
    public class SiparisDetayListViewModel : BaseViewModel
    {
        private ObservableCollection<SiparisDetayViewModel> _items;

        public ObservableCollection<SiparisDetayViewModel> Items
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

        public SiparisDetayListViewModel(Siparis siparis)
        {
            Items = new ObservableCollection<SiparisDetayViewModel>();

            using (SiparisDetayManager siparisDetayManager = new SiparisDetayManager())
            {
                var items = siparisDetayManager.SiparisDetaylar(siparis.Id);
                foreach (var item in items)
                {
                    Items.Add(new SiparisDetayViewModel(item));
                }
            }
        }
    }
}
