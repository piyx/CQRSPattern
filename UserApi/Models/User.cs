using System.ComponentModel.DataAnnotations;

namespace UserApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
