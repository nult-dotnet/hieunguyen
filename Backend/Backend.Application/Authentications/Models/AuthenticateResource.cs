using System.ComponentModel.DataAnnotations;

namespace Backend.Application.Authentications.Models
{
    public class AuthenticateResource
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        [RegularExpression("(?=^.{8,30}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+}{\":;'?/>.<,])(?!.*\\s).*$",
            ErrorMessage = "Validation for 8-30 characters with characters,numbers,1 upper case letter and special characters.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
