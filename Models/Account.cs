using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCaNhan.Models
{
    public class Account
    {
        [DisplayName("Id")]
       public int Id { get; set; }
       [DisplayName("Email")]
       [EmailAddress(ErrorMessage ="In valid email address")]
       [Required(ErrorMessage ="Email can't banlk")]
       [StringLength(50, ErrorMessage = "Email must greater than 6 character", MinimumLength = 6)]
       public string Email { get; set; }
       [Required(ErrorMessage = "Username can't blank")]
        [DisplayName("Username")]
        [StringLength(25, ErrorMessage = "Username must greater than 5 character", MinimumLength = 5)]
       public string Username { get; set; }
       [Required(ErrorMessage = "Password can't blank")]
       [DisplayName("Password")]
       [StringLength(25, ErrorMessage = "Password must greater than 5 character", MinimumLength = 5)]
       public string Password { get; set; }
       [DisplayName("ConfirmPassword")]
       [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
       
       public string ConfirmPassword { get; set; }
       [DisplayName("Fullname")]
       [Required(ErrorMessage = "Fullname can't blank")]
       [StringLength(30, ErrorMessage = "Fullname must greater than 8 character", MinimumLength = 8)]
       public string  Fullname{ get; set; }
       [Required(ErrorMessage = "DateOfBirth can't blank")]
       [DisplayName("DateOfBirth: ")]
       public string DateOfBirth { get; set; }
       [DisplayName("Gender: ")]
       [Required(ErrorMessage = "Gender can't blank")]
       
       public string Gender { get; set; }
       [Required(ErrorMessage = "Address can't blank")]
       [StringLength(30, ErrorMessage = "Address must greater than 8 character", MinimumLength = 8)]
       [DisplayName("Address:")]
       public string Address { get; set; }
       [Required(ErrorMessage = "Phonenumber can't blank")]
       [DisplayName("Phonenumber:")]
    
       public int Phonenumber { get; set; }
       [Required(ErrorMessage = "IdCard can't blank")]
       [DisplayName("IdCard: ")]
       public int IdCard { get; set; }
       [DisplayName("Height: ")]
      
       public int  Height { get; set; }
       [DisplayName("Weight: ")]
       
       public int Weight { get; set; }
       public int Roles { get; set; }
    }
}