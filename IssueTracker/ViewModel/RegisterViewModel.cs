using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IssueTracker.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [Remote(action: "IsEmailInUse", controller:"Account")]
        public string email { get; set; }

        [Required]
        [Display(Name ="Name")]

        public string name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("password", ErrorMessage = "Password and Confirm Password do not match. Try Again!")]
        public string confirmPassword { get; set; }
    }
}
