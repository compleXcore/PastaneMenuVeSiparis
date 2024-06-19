using PastaneMenuVeSiparis.VarlikKatmani;
using PastaneMenuVeSiparis.VarlikKatmani.Enums;
using PastaneMenuVeSiparis.VeriTabaniErisimKatmani;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaneMenuVeSiparis.SunumKatmani.ViewModels.SiparisViewModels
{
    public class SiparisViewModel : BaseViewModel
    {
        private Siparis _siparis;

        public Siparis Siparis { get { return _siparis; } }

        public int Id
        {
            get { return _siparis.Id; }
            set
            {
                if (_siparis.Id != value)
                {
                    _siparis.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public Masa MasaId
        {
            get { return _siparis.MasaId; }
            set
            {
                if (_siparis.MasaId != value)
                {
                    _siparis.MasaId = value;
                    OnPropertyChanged();
                }
            }
        }
        public Durumlar Durum
        {
            get { return _siparis.Durum; }
            set
            {
                if (_siparis.Durum != value)
                {
                    _siparis.Durum = value;
                    OnPropertyChanged();
                }
            }
        }
        public decimal ToplamFiyat
        {
            get { return _siparis.ToplamFiyat; }
            set
            {
                if (_siparis.ToplamFiyat != value)
                {
                    _siparis.ToplamFiyat = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime Tarih
        {
            get { return _siparis.Tarih; }
            set
            {
                if (_siparis.Tarih != value)
                {
                    _siparis.Tarih = value;
                    OnPropertyChanged();
                }
            }
        }
        public SiparisViewModel() : this(new Siparis()) { }
        public SiparisViewModel(Siparis siparis)
        {
            this._siparis = siparis;
        }
    }
}
