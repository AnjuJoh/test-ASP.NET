using System.ComponentModel.DataAnnotations;

namespace Event.Models.Entity
{
    public class Register
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }
        public string BusinessName { get; set; }
        public string PhoneNumber { get; set; }
        public string ModeOfBusiness { get; set; }
        public string Category { get; set; }

        
    }
}
