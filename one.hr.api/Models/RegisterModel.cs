using System.ComponentModel.DataAnnotations;

namespace one.hr.api.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage ="password is required")]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
