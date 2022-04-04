using System.ComponentModel.DataAnnotations;

namespace Backend.Application.Authentications.Models
{
    public class ForgotPasswordResource
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
