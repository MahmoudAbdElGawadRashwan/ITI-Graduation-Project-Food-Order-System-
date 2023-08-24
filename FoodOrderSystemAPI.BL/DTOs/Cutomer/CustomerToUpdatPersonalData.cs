using FoodOrderSystemAPI.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL;

public class CustomerToUpdatPersonalData
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Email Properties 

    [EmailAddress]
    public string Email { get; set; }

    //Password Validation 

    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
      ErrorMessage = "The password must contain at least 8 characters, including one lowercase letter," +
        " one uppercase letter, one digit, and one special character.")]
    public string Password { get; set; }

    // Phone Number 

    [Phone]
    public string Phone { get; set; }

    // Date Of Birth Validation 
    [Display(Name = "Customer Birth")]
    [DataType(DataType.Date)]
    [DateInPast(ErrorMessage = "The {0} must be a date in the past.")]
    public DateTime CustomerBirth { get; set; }




}
