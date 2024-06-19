using PastaneMenuVeSiparis.VarlikKatmani;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaneMenuVeSiparis.SunumKatmani.ViewModels.KategoriViewModels
{
    public class KategoriViewModel : BaseViewModel
    {
        private Kategori _kategori;

        public Kategori Kategori { get { return _kategori; } }

        public int Id
        {
            get { return _kategori.Id; }
            set
            {
                if(_kategori.Id != value)
                {
                    _kategori.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Ad
        {
            get { return _kategori.Ad; }
            set
            {
                if (_kategori.Ad != value)
                {
                    _kategori.Ad = value;
                    OnPropertyChanged();
                }
            }
        }

        public KategoriViewModel() : this(new Kategori()) { }
        public KategoriViewModel(Kategori kategori)
        {
            this._kategori = kategori;
        }
    }
}
