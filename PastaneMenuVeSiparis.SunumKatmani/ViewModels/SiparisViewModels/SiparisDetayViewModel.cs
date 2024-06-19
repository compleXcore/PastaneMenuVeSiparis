using PastaneMenuVeSiparis.VarlikKatmani.Enums;
using PastaneMenuVeSiparis.VarlikKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaneMenuVeSiparis.SunumKatmani.ViewModels.SiparisViewModels
{
    public class SiparisDetayViewModel : BaseViewModel
    {
        private SiparisDetay _siparisDetay;

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
        public SiparisDetayViewModel() : this(new SiparisDetay()) { }
        public SiparisDetayViewModel(SiparisDetay siparisDetay)
        {
            this._siparisDetay = siparisDetay;
        }
    }
}
