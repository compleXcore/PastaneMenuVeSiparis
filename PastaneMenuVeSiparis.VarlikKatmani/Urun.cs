using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaneMenuVeSiparis.VarlikKatmani
{
    [Table("tblUrun")]
    public class Urun
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Urun Adi Bos Gecilemez"), MinLength(3, ErrorMessage = "Urun adi en az 3 karakterli olmalidir")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Urun fiyati bos gecilmez")]
        public decimal Fiyat { get; set; }
        public int KategoriId { get; set; }
        [ForeignKey("KategoriId")]
        public Kategori Kategori { get; set; }
    }
}