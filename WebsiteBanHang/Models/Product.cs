using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteBanHang.Models
{
    public class Product
    {
        [Key]
        [DisplayName("Mã sản phẩm")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên sản phẩm")]
        public string? ProductName { get; set; }

        [StringLength(1000)]
        [DisplayName("Mô tả")]
        public string? ProductDescription { get; set;}

        [ForeignKey("Category")]

        public int CategoryId { get; set; }

        [DisplayName("Tên hãng xe")]
        public Category? Category { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        [DisplayName("Giá")]
        public decimal? ProductPrice { get; set; }

        [Column(TypeName = "decimal(2,2)")]
        [DisplayName("Giảm ")]
        public decimal? ProductDiscount { get; set;}

        [DisplayName("Ảnh")]
        public string? ProductImage { get; set; }

        [ForeignKey("Color")]
        public int ColorId {  get; set; }
        
        public Color? Color { get; set; }

        [DisplayName("Thịnh hành")]
        public bool IsTrandy {  get; set; }

        [DisplayName("Mới ra mắt")]
        public bool IsArrived { get; set; }

    }
}
