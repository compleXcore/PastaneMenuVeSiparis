using PastaneMenuVeSiparis.IsKatmani;
using PastaneMenuVeSiparis.SunumKatmani.Commons;
using PastaneMenuVeSiparis.SunumKatmani.Views.MasaViews;
using PastaneMenuVeSiparis.VarlikKatmani;
using PastaneMenuVeSiparis.VarlikKatmani.Enums;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace PastaneMenuVeSiparis.SunumKatmani.ViewModels.MasaViewModels
{
    public class MasaDetayListViewModel : BaseViewModel
    {
        private ObservableCollection<MasaDetayViewModel> _items;
        private MasaDetayViewModel _selectedItem;
        private Masa masaid;

        public ObservableCollection<MasaDetayViewModel> Items
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

        public MasaDetayViewModel SelectedItem
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
        private decimal _toplamfiyat;
        public decimal ToplamFiyat
        {
            get { return _toplamfiyat; }
            set
            {
                if(_toplamfiyat != value)
                {
                    _toplamfiyat = value;
                    OnPropertyChanged();
                }
            }
        }
        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand InsertCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand OnayCommand { get; set; }
        public RelayCommand IptalCommand { get; set; }

        public MasaDetayListViewModel(Masa masaid)
        {
            this.masaid = masaid;
            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { OnInsert(); }, o => { return true; });
            OnayCommand = new RelayCommand(o => { OnOnay(); }, o => { return true; });
            IptalCommand = new RelayCommand(o => { OnIptal(); }, o => { return true; });
            DeleteCommand = new RelayCommand(o => { OnDelete(); }, o => { return _selectedItem != null; });
            UpdateCommand = new RelayCommand(o => { OnUpdate(); }, o => { return _selectedItem != null; });

            OnRefresh();
        }

        private void OnIptal()
        {
            if (Items != null)
            {
                using (SiparisManager siparisManager = new SiparisManager())
                using (SiparisDetayManager siparisDetayManager = new SiparisDetayManager())
                {
                    var siparis = siparisManager.GetSepetteSiparis(masaid);
                    if (siparis != null)
                    {
                        siparisManager.Sil(siparis.Id);
                        var items = siparisDetayManager.SiparisDetaylar(siparis.Id);
                        if(items != null)
                        {
                            foreach (var item in items)
                            {
                                siparisDetayManager.Sil(item.Id);
                            }
                        }
                        Items = new ObservableCollection<MasaDetayViewModel>();
                        ToplamFiyat = 0;
                    }
                }
            }
        }

        private void OnOnay()
        {
            if (Items != null)
            {
                using (SiparisManager siparisManager = new SiparisManager())
                {
                    var siparis = siparisManager.GetSepetteSiparis(masaid);
                    if(siparis != null)
                    {
                        siparis.Durum = Durumlar.TeslimEdildi;
                        siparis.Tarih = DateTime.Now;
                        siparisManager.Guncelle(siparis);
                        Items = new ObservableCollection<MasaDetayViewModel>();
                        ToplamFiyat = 0;
                    }
                }
            }
        }

        private void OnRefresh()
        {
            Siparis siparis;
            using (SiparisManager siparisManager = new SiparisManager())
            {
                siparis = siparisManager.GetSepetteSiparis(masaid);
                if(siparis != null )
                {
                    ToplamFiyat = siparis.ToplamFiyat;
                }
            }
            Items = new ObservableCollection<MasaDetayViewModel>();
            if (siparis != null)
            {
                using(SiparisDetayManager siparisDetayManager = new SiparisDetayManager())
                {
                    var items = siparisDetayManager.SiparisDetaylar(siparis.Id);
                    foreach (var item in items)
                    {
                        Items.Add(new MasaDetayViewModel(item));
                    }
                }
            }
        }

        private void OnInsert()
        {
            MasaDetayViewModel vm = new MasaDetayViewModel();
            MasaDetayView view = new MasaDetayView
            {
                Title = "Detay Ekle",
                DataContext = vm
            };

            if (view.ShowDialog() == true && vm.UrunId != 0)
            {
                Siparis siparis;
                using (SiparisManager siparisManager = new SiparisManager())
                {
                    siparis = siparisManager.GetSepetteSiparis(masaid);
                    if (siparis == null)
                    {
                        using (UrunManager urunManager = new UrunManager())
                        using (SiparisDetayManager siparisDetayManager = new SiparisDetayManager())
                        {
                            Urun urun = urunManager.GetItem(vm.UrunId);
                            siparis = siparisManager.Ekle(new Siparis
                            {
                                MasaId = masaid,
                                ToplamFiyat = urun.Fiyat * vm.Adet,
                                Tarih = DateTime.Now
                            });

                            siparisDetayManager.Ekle(new SiparisDetay
                            {
                                UrunId = vm.UrunId,
                                Adet = vm.Adet,
                                Tutar = urun.Fiyat * vm.Adet,
                                SiparisId = siparis.Id
                            });

                            var siparisDetay = siparisDetayManager.SiparisDetaylar(siparis.Id);
                            SiparisDetay siparisDetay1 = siparisDetay.FirstOrDefault(x => x.Urun.Id == urun.Id);
                            Items.Add(new MasaDetayViewModel(siparisDetay1));
                            ToplamFiyat = siparis.ToplamFiyat;
                        }
                    }
                    else
                    {
                        using (SiparisDetayManager siparisDetayManager = new SiparisDetayManager())
                        using (UrunManager urunManager = new UrunManager())
                        {
                            var siparisDetay = siparisDetayManager.SiparisDetaylar(siparis.Id);
                            Urun urun = urunManager.GetItem(vm.UrunId);
                            SiparisDetay siparisDetay1 = siparisDetay.FirstOrDefault(x => x.Urun.Id == urun.Id);
                            if (siparisDetay1 == null)
                            {
                                siparisDetayManager.Ekle(new SiparisDetay
                                {
                                    UrunId = vm.UrunId,
                                    Adet = vm.Adet,
                                    Tutar = urun.Fiyat * vm.Adet,
                                    SiparisId = siparis.Id
                                });
                                siparis.ToplamFiyat += urun.Fiyat * vm.Adet;
                                siparisManager.Guncelle(siparis);
                                siparisDetay = siparisDetayManager.SiparisDetaylar(siparis.Id);
                                siparisDetay1 = siparisDetay.FirstOrDefault(x => x.Urun.Id == urun.Id);
                                Items.Add(new MasaDetayViewModel(siparisDetay1));
                                ToplamFiyat = siparis.ToplamFiyat;
                            }
                            else
                            {
                                siparis.ToplamFiyat -= siparisDetay1.Tutar;
                                siparisDetay1.Adet = vm.Adet;
                                siparisDetay1.Tutar = urun.Fiyat * vm.Adet;
                                siparis.ToplamFiyat += siparisDetay1.Tutar;
                                Items[siparisDetay.IndexOf(siparisDetay1)] = new MasaDetayViewModel(siparisDetay1);
                                siparisDetayManager.Guncelle(siparisDetay1);
                                siparisManager.Guncelle(siparis);
                                ToplamFiyat = siparis.ToplamFiyat;
                            }
                        }
                    }
                }
            }
        }

        private void OnDelete()
        {
            if (MessageBox.Show(_selectedItem.Urun.Ad + " adlı sipariş detayı silmek istiyor musunuz?", "Ürün Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (SiparisDetayManager siparisDetayManager = new SiparisDetayManager())
                using (SiparisManager siparisManager = new SiparisManager())
                {
                    var siparis = siparisManager.GetSepetteSiparis(masaid);
                    siparis.ToplamFiyat -= _selectedItem.Tutar;
                    ToplamFiyat = siparis.ToplamFiyat;
                    siparisDetayManager.Sil(_selectedItem.Id);
                    siparisManager.Guncelle(siparis);
                    Items.Remove(_selectedItem);
                    var siparisDetay = siparisDetayManager.SiparisDetaylar(siparis.Id);
                    if(siparisDetay.Count <= 0)
                    {
                        ToplamFiyat = 0;
                        siparisManager.Sil(siparis.Id);
                    }
                }
            }
        }

        private void OnUpdate()
        {
            MasaDetayView view = new MasaDetayView
            {
                Title = "Ürün Güncelle",
                DataContext = _selectedItem
            };

            if (view.ShowDialog() == true)
            {
                using (SiparisDetayManager siparisDetayManager = new SiparisDetayManager())
                using (SiparisManager siparisManager = new SiparisManager())
                using (UrunManager urunManager = new UrunManager())
                {
                    var siparis = siparisManager.GetSepetteSiparis(masaid);
                    siparis.ToplamFiyat -= _selectedItem.Tutar;
                    _selectedItem.SiparisDetay.Urun = urunManager.GetItem(_selectedItem.SiparisDetay.UrunId);
                    _selectedItem.SiparisDetay.Tutar = _selectedItem.SiparisDetay.Urun.Fiyat * _selectedItem.SiparisDetay.Adet;
                    var item = siparisDetayManager.Guncelle(_selectedItem.SiparisDetay);
                    siparis.ToplamFiyat += _selectedItem.SiparisDetay.Tutar;
                    siparis = siparisManager.Guncelle(siparis);
                    ToplamFiyat = siparis.ToplamFiyat;
                    OnRefresh();
                }
            }
        }
    }
}