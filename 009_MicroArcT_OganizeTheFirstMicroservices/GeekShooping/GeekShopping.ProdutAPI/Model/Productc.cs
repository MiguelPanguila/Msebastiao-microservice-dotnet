using GeekShopping.ProdutAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProdutAPI.Model
{
    [Table("Product")]
    public class Productc:BaseEntity
    {
        [Column("name")]
        [Required]
        [MaxLength(150)]
        public string? Name {  get; set; }

        [Column("price")]
        [Required]
        [Range(1,1000)]
        public decimal Price {  get; set; }
        [Column("description")]
        
        [StringLength(500)]
        public string? Description { get; set; }

        [Column("category_name")]
        [StringLength(50)]
        public string? CategoryName {  get; set; }
        [Column("image_url")]
        [StringLength(300)]
        public string? ImageUrl { get; set; }
    }
}
