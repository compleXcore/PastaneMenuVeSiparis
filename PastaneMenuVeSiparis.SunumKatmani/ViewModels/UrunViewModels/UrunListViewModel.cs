using PastaneMenuVeSiparis.IsKatmani;
using PastaneMenuVeSiparis.SunumKatmani.Commons;
using PastaneMenuVeSiparis.SunumKatmani.Views.UrunViews;
using PastaneMenuVeSiparis.VeriTabaniErisimKatmani;
using System.Collections.ObjectModel;
using System.Windows;

namespace PastaneMenuVeSiparis.SunumKatmani.ViewModels.UrunViewModels
{
    public class UrunListViewModel : BaseViewModel
    {
        private readonly UrunManager urunManager;
        private ObservableCollection<UrunViewModel> _items;
        private UrunViewModel _selectedItem;

        public ObservableCollection<UrunViewModel> Items
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

        public UrunViewModel SelectedItem
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
        public RelayCommand InsertCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        public UrunListViewModel()
        {
            urunManager = new UrunManager();
            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { OnInsert(); }, o => { return true; });
            DeleteCommand = new RelayCommand(o => { OnDelete(); }, o => { return _selectedItem != null; });
            UpdateCommand = new RelayCommand(o => { OnUpdate(); }, o => { return _selectedItem != null; });

            OnRefresh();
        }

        private void OnRefresh()
        {
            var items = urunManager.ListeleKategori();
            Items = new ObservableCollection<UrunViewModel>();
            foreach (var item in items)
            {
                Items.Add(new UrunViewModel(item));
            }
        }

        private void OnInsert()
        {
            UrunViewModel vm = new UrunViewModel();
            UrunView view = new UrunView
            {
                Title = "Ürün Ekle",
                DataContext = vm
            };

            if (view.ShowDialog() == true)
            {
                UnitOfWork uow = new UnitOfWork();
                vm.Urun.Kategori = uow.KategoriRepo.GetItem(vm.Urun.KategoriId);
                var item = urunManager.Ekle(vm.Urun);
                Items.Add(new UrunViewModel(item));
            }

        }

        private void OnDelete()
        {
            if (MessageBox.Show(_selectedItem.Urun.Ad + " adlı ürünü silmek istiyor musunuz?", "Ürün Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                urunManager.Sil(_selectedItem.Id);
                Items.Remove(_selectedItem);
            }
        }

        private void OnUpdate()
        {
            UrunView view = new UrunView
            {
                Title = "Ürün Güncelle",
                DataContext = _selectedItem
            };

            if (view.ShowDialog() == true)
            {
                var item = urunManager.Guncelle(_selectedItem.Urun);
                OnRefresh();
            }
        }
    }
}
