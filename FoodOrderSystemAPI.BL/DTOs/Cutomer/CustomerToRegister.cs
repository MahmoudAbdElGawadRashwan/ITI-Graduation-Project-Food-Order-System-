using FoodOrderSystemAPI.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL;

public class CustomerToRegister
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



    // Maintainance (1) => Remove Confirm Password Proberty 

    // Location Properties 

    public string CustomerAddress { get; set; }

    // Card Properties 

    // Maintainance (2) => Remove Validation On Card Number 
    public string? CardNumber { get; set; }


    public DateTime ExpirationDate  { get; set; }

    public string CvvNumber { get; set; }

    // Phone Number 

    public string Phone { get; set; }

    // Date Of Birth Validation 

    public DateTime CustomerBirth { get; set; }






}
