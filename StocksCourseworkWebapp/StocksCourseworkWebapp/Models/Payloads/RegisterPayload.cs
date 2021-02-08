using System.ComponentModel.DataAnnotations;

namespace StocksCourseworkWebapp.Models.Payloads
{
    public class RegisterPayload
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [EmailAddress]
        [Compare(nameof(EmailAddress))]
        public string EmailAddressComparison { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string PasswordComparison { get; set; }

    }
}
