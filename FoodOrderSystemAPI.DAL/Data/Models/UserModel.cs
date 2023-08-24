using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FoodOrderSystemAPI;

public enum RoleOptions{
    Admin , 
    Customer , 
    Resturant 

}

public class UserModel: IdentityUser<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

   
    [DataType(DataType.Text,ErrorMessage =" Name Must Be Text ")]
    public override  string NormalizedUserName { get; set; } = string.Empty;

    [DataType(DataType.Text, ErrorMessage = " Name Must Be Text ")]
    public override  string UserName { get; set; } = string.Empty;

    [EmailAddress]
    
    public override string NormalizedEmail { get; set; } = string.Empty;
    [EmailAddress]
    public override string Email { get; set; } = string.Empty;

    public RoleOptions Role { get; set; }

}

