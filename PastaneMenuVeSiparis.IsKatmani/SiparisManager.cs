using PastaneMenuVeSiparis.VarlikKatmani;
using PastaneMenuVeSiparis.VarlikKatmani.Enums;
using PastaneMenuVeSiparis.VeriTabaniErisimKatmani;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PastaneMenuVeSiparis.IsKatmani
{
    public class SiparisManager : IDisposable
    {
        private readonly UnitOfWork unitOfWork;
        public SiparisManager()
        {
            unitOfWork = new UnitOfWork();
        }

        public List<Siparis> Siparisler()
        {
            return unitOfWork.SiparisRepo.GetAllTeslim().OrderBy(x => x.Tarih).ToList();
        }
        public List<Siparis> SiparislerMasa(Masa masaid, Durumlar durum)
        {
            return unitOfWork.SiparisRepo.GetAllWithMasa(masaid, durum).ToList();
        }
        public Siparis GetSepetteSiparis(Masa masaid)
        {
            return unitOfWork.SiparisRepo.GetSiparisInSepette(masaid);
        }
        public Siparis Ekle(Siparis item)
        {
            var siparis = unitOfWork.SiparisRepo.Add(item);
            unitOfWork.Save();
            return siparis;
        }
        public Siparis Guncelle(Siparis item)
        {
            var siparis = unitOfWork.SiparisRepo.Update(item);
            unitOfWork.Save();
            return siparis;
        }
        public void Sil(int id)
        {
            unitOfWork.SiparisRepo.Remove(id);
            unitOfWork.Save();
        }
        public int TeslimEdilenSiparisSayisi()
        {
            return unitOfWork.SiparisRepo.GetAllSiparisCount();
        }
        public void GuncelleSepet(Masa masaid)
        {
            var sepet = SiparislerMasa(masaid, Durumlar.Sepette);
            if (sepet != null)
            {
                foreach (var item in sepet)
                {
                    item.Durum = Durumlar.TeslimEdildi;
                    item.Tarih = DateTime.Now;
                    var siparis = Guncelle(item);
                }
            }
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
