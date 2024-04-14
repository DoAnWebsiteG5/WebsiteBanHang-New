using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebsiteBanHang.Models
{
    public class Color
    {
        [Key]
        [DisplayName("Mã màu")]
        public int ColorId {  get; set; }

        [DisplayName("Tên màu")]
        public string ColorName { get; set; }
    }
}
