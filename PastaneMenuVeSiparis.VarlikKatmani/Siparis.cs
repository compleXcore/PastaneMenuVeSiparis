using PastaneMenuVeSiparis.VarlikKatmani.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaneMenuVeSiparis.VarlikKatmani
{
    [Table("tblSiparis")]
    public class Siparis
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Masa MasaId { get; set; }
        public Durumlar Durum { get; set; } = Durumlar.Sepette;
        public decimal ToplamFiyat { get; set; }
        public DateTime Tarih { get; set; }
    }
}
