using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DontEatAlone.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name required.")]
        [StringLength(50, ErrorMessage = "Name must be maximum of 50 characters.")]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Not valid format for name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required.")]
        [StringLength(50, ErrorMessage = "Name must be maximum of 50 characters.")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Not valid format for name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Street address required.")]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "City required.")]
        [StringLength(50, ErrorMessage = "City must be maximum of 50 characters.")]
        [Display(Name = "City Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Not valid format for name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Province required.")]
        [StringLength(25, ErrorMessage = "City must be maximum of 25 characters.")]
        [Display(Name = "Province Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Not valid format for name")]
        public string Province { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
