using FoodOrderSystemAPI.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL;

    public class AuthenticationManger : IAuthenticationManager
    {


    private readonly UserManager<CustomerModel> _CustomerManger;
    private readonly UserManager<RestaurantModel> _ResturantManger;

    private readonly IConfiguration _configuration;

    public AuthenticationManger( UserManager<CustomerModel> CustomerManager, UserManager<RestaurantModel> ResturantManager  , IConfiguration configuration)
    {
        _CustomerManger = CustomerManager;
        _ResturantManger = ResturantManager;
        _configuration = configuration;
    }


    public async Task<TokenDto> LoginAsCustomer(UserLogin NewLoginCustomer)
    {
        var Customer = await _CustomerManger.FindByNameAsync(NewLoginCustomer.UserName);
        if (Customer is null || await _CustomerManger.IsLockedOutAsync(Customer))
        {
            return null;
        }
        bool isAuthenticated = await _CustomerManger.CheckPasswordAsync(Customer, NewLoginCustomer.Password);
        if (!isAuthenticated)
        {
            _CustomerManger.AccessFailedAsync(Customer);
            return null;
        }

        var CustomerClaims = await _CustomerManger.GetClaimsAsync(Customer);

        // Generate Tkey 
        var secretkey = _configuration["secretkey"];
        var secretkeyinbytes = Encoding.ASCII.GetBytes(secretkey);
        var key = new SymmetricSecurityKey(secretkeyinbytes);

        // Generate Hashing Result 
        var HashingResult = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        //Generate JWt Token 
        // Calc Expiration Date 
        var ExpirationDate = DateTime.Now.AddMinutes(30);
        var Jwt = new JwtSecurityToken(
            claims: CustomerClaims,
            notBefore: DateTime.Now,
            expires: ExpirationDate,
            signingCredentials: HashingResult
            );

        var TokenHandler = new JwtSecurityTokenHandler();
        string TokenString = TokenHandler.WriteToken(Jwt);

        return new TokenDto()
        {
            Token = TokenString,
            ExpirationDate = ExpirationDate
        };
    }
    
    
    
    public async Task<TokenDto> LoginAsResturant(UserLogin ResturantLogin)
    {
        var Resturant = await _ResturantManger.FindByNameAsync(ResturantLogin.UserName);

        if (Resturant is null || await _ResturantManger.IsLockedOutAsync(Resturant))
        {
            return null;
        }
        bool isAuthenticated = await _ResturantManger.CheckPasswordAsync(Resturant, ResturantLogin.Password);
        if (!isAuthenticated)
        {
          _ResturantManger.AccessFailedAsync(Resturant);
            return null;
        }

        var ResturantClaims = await _ResturantManger.GetClaimsAsync(Resturant);

        // Generate Tkey 
        var secretkey = _configuration["secretkey"];
        var secretkeyinbytes = Encoding.ASCII.GetBytes(secretkey);
        var key = new SymmetricSecurityKey(secretkeyinbytes);

        // Generate Hashing Result 
        var HashingResult = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        //Generate JWt Token 
        // Calc Expiration Date 
        var ExpirationDate = DateTime.Now.AddMinutes(30);
        var Jwt = new JwtSecurityToken(
            claims: ResturantClaims,
            notBefore: DateTime.Now,
            expires: ExpirationDate,
            signingCredentials: HashingResult
            );

        var TokenHandler = new JwtSecurityTokenHandler();
        string TokenString = TokenHandler.WriteToken(Jwt);

        return new TokenDto()
        {
            Token = TokenString,
            ExpirationDate = ExpirationDate
        };
    }


    public async Task<TokenDto> LoginAsUser(UserLogin _UserLogin)
    {
       var customerResult =  LoginAsCustomer(_UserLogin);
        if (customerResult.Result != null)
            return await customerResult;
        else
        {
            var resutrantResult = LoginAsResturant(_UserLogin);
            return await resutrantResult;
        }

    }


}

