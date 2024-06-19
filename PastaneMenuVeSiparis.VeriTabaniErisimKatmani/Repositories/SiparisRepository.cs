using PastaneMenuVeSiparis.VarlikKatmani;
using PastaneMenuVeSiparis.VarlikKatmani.Enums;
using PastaneMenuVeSiparis.VeriTabaniErisimKatmani.DataBaseContext;
using PastaneMenuVeSiparis.VeriTabaniErisimKatmani.Repositories.Base;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PastaneMenuVeSiparis.VeriTabaniErisimKatmani.Repositories
{
    public class SiparisRepository : Repository<Siparis>, ISiparisRepository
    {
        public SiparisRepository(AppDbContext context) : base(context)
        {
        }
        public ICollection<Siparis> GetAllTeslim()
        {
            return context.Siparisler.Where(x => x.Durum == Durumlar.TeslimEdildi).ToList();
        }
        public ICollection<Siparis> GetAllWithMasa(Masa masaid, Durumlar durum)
        {
            return context.Siparisler.Where(x => x.MasaId == masaid && x.Durum == durum).ToList();
        }
        public Siparis GetSiparisInSepette(Masa masaid)
        {
            return context.Siparisler.FirstOrDefault(x => x.MasaId == masaid && x.Durum == Durumlar.Sepette);
        }
        public int GetAllSiparisCount()
        {
            return context.Siparisler.Where(x => x.Durum != Durumlar.Sepette).Count();
        }
    }
}
