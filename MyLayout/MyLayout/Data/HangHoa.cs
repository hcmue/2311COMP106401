using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLayout.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public int MaHh { get; set; }

        [MaxLength(100)]
        public string TenHH { get; set; }

        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }
        [MaxLength(100)]
        public string Hinh { get; set; }
        [Range(0, int.MaxValue)]
        public int SoLuong { get; set; }

        public int MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }
    }
}
