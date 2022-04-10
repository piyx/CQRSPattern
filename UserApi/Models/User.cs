using System.ComponentModel.DataAnnotations;

namespace UserApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "FirstName cannot be more than 50 characters long")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "LastName cannot be more than 50 characters long")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Email cannot be more than 100 characters long")]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
