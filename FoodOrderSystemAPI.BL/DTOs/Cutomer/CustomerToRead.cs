using FoodOrderSystemAPI.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL;

public class CustomerToRead
{
    public string FullName  { get; set; }

    // Email Properties 
    public string Role { get; set; }

    public string Email { get; set; }

    //Password prop 





    // Location Properties 
    public String CustomerAddress { get; set; }

    // Card Properties 

    public string? CardNumber { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public string CvvNumber { get; set; }

    // Phone Number 

    [Phone]
    public string Phone { get; set; }

    // Date Of Birth  

    public DateTime CustomerBirth { get; set; }


}
