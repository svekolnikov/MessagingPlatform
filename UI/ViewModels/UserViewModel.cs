using System.ComponentModel.DataAnnotations;

namespace MessagingPlatform.MVC.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "The length must be from 2 to 255 characters")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "All characters must be russian or english. The first letter is capitalized")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Last name")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "The length must be from 2 to 255 characters")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "All characters must be russian or english. The first letter is capitalized")]
        public string LastName { get; set; } = null!;

        [Required]
        [Display(Name = "E-mail")]
        [RegularExpression(@"(^[^@\s]+@[^@\s]+\.[^@\s]+$)", ErrorMessage = "This is not e-mail address")]
        public string Email { get; set; } = null!;
    }
}
