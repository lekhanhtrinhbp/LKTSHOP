using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LKTShop.Model.Models
{
    [Table("Menus")]
    public class Menu
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required, MaxLength(500)]
        public string Name { get; set; }
        [Required, MaxLength(500)]
        public string URL { get; set; }
        public int? DisplayOrder { get; set; }
        [Required]
        public int GroupID { get; set; }
        [Column(TypeName ="varchar"), MaxLength(10)]
        public string Target { get; set; }
        [Required]
        public bool Status { get; set; }
        [ForeignKey("GroupID")]
        public virtual MenuGroup MenuGroup { get; set; }
    }
}