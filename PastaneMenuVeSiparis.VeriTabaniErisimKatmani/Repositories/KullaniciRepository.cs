using PastaneMenuVeSiparis.VarlikKatmani;
using PastaneMenuVeSiparis.VeriTabaniErisimKatmani.DataBaseContext;
using PastaneMenuVeSiparis.VeriTabaniErisimKatmani.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaneMenuVeSiparis.VeriTabaniErisimKatmani.Repositories
{
    public class KullaniciRepository : Repository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(AppDbContext context) : base(context)
        {
        }

        public bool Login(string kullaniciadi, string kullaniciparola)
        {
            if (context.Kullanicilar.FirstOrDefault(x =>
            x.KullaniciAdi.ToLower().Equals(kullaniciadi.ToLower()) &&
            x.KullaniciSifre.Equals(kullaniciparola)) != null)
                return true;
            else
                return false;
        }
    }
}
