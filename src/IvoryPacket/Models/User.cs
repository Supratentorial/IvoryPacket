using System.ComponentModel.DataAnnotations;

namespace IvoryPacket.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string GivenName { get; set; }
        [Required]
        public string FamilyName { get; set; }
        public string Title { get; set; }
        [Required]
        public string Role { get; set; }
        public string ProviderNumber { get; set; }



    }
}
