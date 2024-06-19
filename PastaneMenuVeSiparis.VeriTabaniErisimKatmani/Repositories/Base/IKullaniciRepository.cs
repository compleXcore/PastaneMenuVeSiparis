using PastaneMenuVeSiparis.VarlikKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaneMenuVeSiparis.VeriTabaniErisimKatmani.Repositories.Base
{
    public interface IKullaniciRepository : IRepository<Kullanici>
    {
        bool Login(string kullaniciad, string kullaniciparola);
    }
}
