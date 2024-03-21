using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComputerAccessories.Model
{
    [Table("MouseDetails")]

    public class Mouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Mouse Name is required.")]
        [MaxLength(30, ErrorMessage = "Mouse name cannot be greater tha 30 chars long.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mouse Brand is required")]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Mouse Price is required.")]
        public decimal Price { get; set; }
    }
}
