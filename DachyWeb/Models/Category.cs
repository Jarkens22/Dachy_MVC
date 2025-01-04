using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DachyWeb.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę kategorii.")]
        [DisplayName("Nazwa kategorii")]
        public string? Name { get; set; }
        [DisplayName("Kolejność wyświetlania")]
        [Range(1,100, ErrorMessage ="Liczba musi znajdować się w przedziale 1-100.")]
        public int DisplayOrder { get; set; }
    }
}
