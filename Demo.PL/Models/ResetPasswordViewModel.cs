using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Password is Required !")]
        [MinLength(5, ErrorMessage = "Minimum Password Length is 5 ")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required !")]
        [Compare("Password", ErrorMessage = "Confirm Password does not match")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }


    }
}
