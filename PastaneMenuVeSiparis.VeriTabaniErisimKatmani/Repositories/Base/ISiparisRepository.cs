using PastaneMenuVeSiparis.VarlikKatmani.Enums;
using PastaneMenuVeSiparis.VarlikKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaneMenuVeSiparis.VeriTabaniErisimKatmani.Repositories.Base
{
    public interface ISiparisRepository : IRepository<Siparis>
    {
        ICollection<Siparis> GetAllWithMasa(Masa masaid, Durumlar durum);
        ICollection<Siparis> GetAllTeslim();
        int GetAllSiparisCount();
        Siparis GetSiparisInSepette(Masa masaid);
    }
}
