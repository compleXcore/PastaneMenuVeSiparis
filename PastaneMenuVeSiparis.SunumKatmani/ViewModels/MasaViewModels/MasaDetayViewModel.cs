using PastaneMenuVeSiparis.IsKatmani;
using PastaneMenuVeSiparis.VarlikKatmani;
using PastaneMenuVeSiparis.VeriTabaniErisimKatmani;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaneMenuVeSiparis.SunumKatmani.ViewModels.MasaViewModels
{
    public class MasaDetayViewModel : BaseViewModel
    {
        private SiparisDetay _siparisDetay;
        private ObservableCollection<Urun> _urunler;

        public SiparisDetay SiparisDetay { get { return _siparisDetay; } }

        public int Id
        {
            get { return _siparisDetay.Id; }
            set
            {
                if (_siparisDetay.Id != value)
                {
                    _siparisDetay.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public int UrunId
        {
            get { return _siparisDetay.UrunId; }
            set
            {
                if (_siparisDetay.UrunId != value)
                {
                    _siparisDetay.UrunId = value;
                    OnPropertyChanged();
                }
            }
        }

        public Urun Urun
        {
            get { return _siparisDetay.Urun; }
            set
            {
                if (_siparisDetay.Urun != value)
                {
                    _siparisDetay.Urun = value;
                    OnPropertyChanged();
                }
            }
        }
        public int SiparisId
        {
            get { return _siparisDetay.SiparisId; }
            set
            {
                if (_siparisDetay.SiparisId != value)
                {
                    _siparisDetay.SiparisId = value;
                    OnPropertyChanged();
                }
            }
        }

        public Siparis Siparis
        {
            get { return _siparisDetay.Siparis; }
            set
            {
                if (_siparisDetay.Siparis != value)
                {
                    _siparisDetay.Siparis = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Adet
        {
            get { return _siparisDetay.Adet; }
            set
            {
                if (_siparisDetay.Adet != value)
                {
                    _siparisDetay.Adet = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Tutar
        {
            get { return _siparisDetay.Tutar; }
            set
            {
                if (_siparisDetay.Tutar != value)
                {
                    _siparisDetay.Tutar = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Urun> Urunler
        {
            get { return _urunler; }
            set
            {
                if (_urunler != value)
                {
                    _urunler = value;
                    OnPropertyChanged();
                }
            }
        }
        public MasaDetayViewModel() : this(new SiparisDetay()) { }
        public MasaDetayViewModel(SiparisDetay siparisDetay)
        {
            using (var urunManager = new UrunManager())
                Urunler = new ObservableCollection<Urun>(urunManager.ListeleKategori());

            this._siparisDetay = siparisDetay;
        }
    }
}
