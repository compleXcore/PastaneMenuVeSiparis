using PastaneMenuVeSiparis.VarlikKatmani;
using PastaneMenuVeSiparis.VeriTabaniErisimKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaneMenuVeSiparis.IsKatmani
{
    public class KullaniciManager : IDisposable
    {
        private readonly UnitOfWork _unitOfWork;
        public KullaniciManager()
        {
            _unitOfWork = new UnitOfWork();
        }
        public bool Giris(string kullaniciad, string kullaniciparola)
        {
            return _unitOfWork.KullaniciRepo.Login(kullaniciad, kullaniciparola);
        }
        public void Dispose()
        {
            _unitOfWork?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
