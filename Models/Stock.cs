using System.ComponentModel.DataAnnotations;

namespace KMAstationeryStore.Models
{
    public class Stock
    {
        [Key]
        public int stockID { get; set; }

        public string itemID { get; set; }
        public string itemTitle { get; set; }
        [Range(1,10000, ErrorMessage = "Quanity must be greater than 1 and less than 10,000!!!")]
        public int quantity { get; set; }
    }
}
