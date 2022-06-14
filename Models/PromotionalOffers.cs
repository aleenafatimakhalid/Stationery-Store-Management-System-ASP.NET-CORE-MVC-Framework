using System.ComponentModel.DataAnnotations;

namespace KMAstationeryStore.Models
{
    public class PromotionalOffers
    {
        [Key]
        public int offerID { get; set; }
        public string offerName { get; set; }
        public string offerDescription { get; set; }
        [Range(1, 300, ErrorMessage ="Offer duration must be greater than 1 hour and less than 300 hours!!")]
        public float offerDuration { get; set; }
     
    }
}

