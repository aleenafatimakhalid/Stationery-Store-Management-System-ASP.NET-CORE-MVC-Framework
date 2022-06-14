using System.ComponentModel.DataAnnotations;

namespace KMAstationeryStore.Models
{
    public class Customer
    {
        [Key]
        public int customerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerStreet { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerSector { get; set; }
        public string CustomerCountry { get; set; }
    }
}
