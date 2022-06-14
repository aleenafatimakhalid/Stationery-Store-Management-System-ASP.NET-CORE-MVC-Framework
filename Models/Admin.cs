using System.ComponentModel.DataAnnotations;

namespace KMAstationeryStore.Models
{
    public class Admin { 


        [Key]
    public int adminId { get; set; }
    [Required]
    public string adminName { get; set; }
    public string adminPassword { get; set; }
    public string adminEmail { get; set; }
    public int adminPhone { get; set; }
    public string adminStreet { get; set; }
    public string adminCity { get; set; }
    public string adminSector { get; set; }
    public string adminCountry { get; set; }
}
}
