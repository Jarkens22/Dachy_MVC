using System.ComponentModel.DataAnnotations;

namespace Dachy.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Nip { get; set; }
        public string? StreetAddres { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set;}
        public string? PhoneNumber { get; set; }
    }
}
