using System.ComponentModel.DataAnnotations;

namespace KMAstationeryStore.Models
{
    public class Bill
    {
        [Key]
        public int billId { get; set; }
        [Required]
        public float billAmount { get; set; }
    }
}
