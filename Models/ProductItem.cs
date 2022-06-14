using System.ComponentModel.DataAnnotations;

namespace KMAstationeryStore.Models
{
    public class ProductItem
    {
        [Key] //makes itemID the pk for db
        public int itemId { get; set; }
        [Required] //makes itemtitle a required property in db - it cannot be null
        public string itemTitle { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        [Range(10, 10000, ErrorMessage ="Price must be greater than 10Rs and less than 10,000Rs!!!")]
        public float price { get; set; }
        

    } 
}
