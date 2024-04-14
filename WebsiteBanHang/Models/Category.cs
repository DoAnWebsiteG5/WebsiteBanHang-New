using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebsiteBanHang.Models
{
    public class Category
    {
        [Key]
        [DisplayName("Mã hãng xe")]
        public int CategoryId { get; set; }

        [StringLength(100)]
        [DisplayName("Tên hãng xe")]
        public string CategoryName { get; set; }

        [StringLength(100)]
        [DisplayName("Ảnh")]
        public string CategoryImage { get; set; }

        public int CategoryOrder { get; set; }
    }
}
