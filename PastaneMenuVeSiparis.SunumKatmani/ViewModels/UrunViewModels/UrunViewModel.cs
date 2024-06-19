using PastaneMenuVeSiparis.VarlikKatmani;
using PastaneMenuVeSiparis.VeriTabaniErisimKatmani;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaneMenuVeSiparis.SunumKatmani.ViewModels.UrunViewModels
{
    public class UrunViewModel : BaseViewModel
    {
        private Urun _urun;
        private ObservableCollection<Kategori> _kategoriler;

        public Urun Urun { get { return _urun; } }

        public int Id
        {
            get { return _urun.Id; }
            set
            {
                if (_urun.Id != value)
                {
                    _urun.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Ad
        {
            get { return _urun.Ad; }
            set
            {
                if (_urun.Ad != value)
                {
                    _urun.Ad = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Fiyat
        {
            get { return _urun.Fiyat; }
            set
            {
                if(_urun.Fiyat != value)
                {
                    _urun.Fiyat = value;
                    OnPropertyChanged();
                }
            }
        }
        public int KategoriId
        {
            get { return _urun.KategoriId; }
            set
            {
                if (_urun.KategoriId != value)
                {
                    _urun.KategoriId = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<Kategori> Kategoriler
        {
            get { return _kategoriler; }
            set
            {
                if (_kategoriler != value)
                {
                    _kategoriler = value;
                    OnPropertyChanged();
                }
            }
        }


        public Kategori Kategori
        {
            get { return _urun.Kategori; }
            set
            {
                if (_urun.Kategori != value)
                {
                    _urun.Kategori = value;
                    OnPropertyChanged();
                }
            }
        }

        public UrunViewModel() : this(new Urun()) { }
        public UrunViewModel(Urun urun)
        {
            using (var unitOfWork = new UnitOfWork())
                Kategoriler = new ObservableCollection<Kategori>(unitOfWork.KategoriRepo.GetAll());

            this._urun = urun;
        }
    }
}
