using FoodOrderSystemAPI.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL;

public class CustomerManager:ICustomerManager

{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<CustomerModel> _UserMangager;
    private readonly IConfiguration _configuration;
    private readonly ICustomerRepo _CustomerRepo;
    private readonly IAuthenticationManager _AuthenticationManager;


    public CustomerManager(IUnitOfWork unitOfWork, UserManager<CustomerModel> UserMangager, IConfiguration configuration, ICustomerRepo customerRepo, IAuthenticationManager authenticationManager)
    {
        _unitOfWork = unitOfWork;
        _UserMangager = UserMangager;
        _configuration = configuration;
        _CustomerRepo = customerRepo;
        _AuthenticationManager = authenticationManager;
    }



    public List<CustomerModel> GetAllCutomers()
    {
        
        return _unitOfWork.Customers.GetAllWithNavProp().ToList();

    }

    public CustomerToRead GetById(int CustomerID)
    {
       var CustomerFromDb =  _CustomerRepo.GetCustomerByIdWithNavprop(CustomerID);
        // Return Cutomer TO read TO avoid Cyrcular referance
        if(CustomerFromDb == null)
        {
            return null; 
        }
        return new CustomerToRead()
        {

            FullName = CustomerFromDb.UserName,
            Email = CustomerFromDb.Email,
            Role = CustomerFromDb.Role.ToString(),
            Phone = CustomerFromDb.PhoneNumber,
            CustomerBirth = CustomerFromDb.BirthDate,
            // Set Card

            CardNumber = CustomerFromDb.CustomerCreditCard.Card_Number,
            ExpirationDate = CustomerFromDb.CustomerCreditCard.Card_Expiration_Date,
            CvvNumber = CustomerFromDb.CustomerCreditCard.CVV,
            // Set Address 

            CustomerAddress = CustomerFromDb.CustomerAddress


        };
    }

    public async Task<TokenDto> Register(CustomerToRegister RegisterdCustomer)
    {
        // Map to CutomerModel To Add To List 

        var CustomerToAdd = new CustomerModel()
        {
            UserName = $"{RegisterdCustomer.FirstName}{RegisterdCustomer.LastName}",
            Email = RegisterdCustomer.Email,
            Role = RoleOptions.Customer,
            PhoneNumber = RegisterdCustomer.Phone,
            BirthDate = RegisterdCustomer.CustomerBirth,
            // Set Card
            CustomerCreditCard = new CreditCard()
            {
                Card_Number = RegisterdCustomer.CardNumber,
                Card_Expiration_Date = RegisterdCustomer.ExpirationDate,
                CVV = RegisterdCustomer.CvvNumber

            },

            // Set Address 
            CustomerAddress = RegisterdCustomer.CustomerAddress
        };

        // Hashing The Password 
        var CreationResult = await _UserMangager.CreateAsync(CustomerToAdd, RegisterdCustomer.Password);

        // Add To Table 
        if (CreationResult.Succeeded)
        {
            var CustomerClaims = new List<Claim>()
            {

                new Claim(ClaimTypes.Name, CustomerToAdd.UserName),
                new Claim(ClaimTypes.Email, CustomerToAdd.Email),
                new Claim(ClaimTypes.NameIdentifier, CustomerToAdd.Id.ToString()),
                new Claim(ClaimTypes.Role, CustomerToAdd.Role.ToString())
            };

            await _UserMangager.AddClaimsAsync(CustomerToAdd, CustomerClaims);
            //_unitOfWork.Customers.Add(CustomerToAdd);
            _unitOfWork.Save();
            // Instantiate An New User to Login from the user that Register
            UserLogin RegisteredCustomerToLogin = new UserLogin()
            {
                UserName = CustomerToAdd.UserName,
                Password = RegisterdCustomer.Password
            };
            return await _AuthenticationManager.LoginAsCustomer(RegisteredCustomerToLogin);
             
        }
        return null;
    }



    public List<CustomerToRead> ReadAllCutomerProperties() {

      var CutomersToRead =  _unitOfWork.Customers.GetAllWithNavProp().Select(c => new CustomerToRead() {
          FullName = c.UserName,
          Email = c.Email,
          Role = c.Role.ToString(),
          Phone = c.PhoneNumber,
          CustomerBirth = c.BirthDate,
          // Set Card
         
           CardNumber = c.CustomerCreditCard.Card_Number,
           ExpirationDate = c.CustomerCreditCard.Card_Expiration_Date,
           CvvNumber = c.CustomerCreditCard.CVV,
          // Set Address 

          CustomerAddress = c.CustomerAddress

          });


        return CutomersToRead.ToList();


    }

    //public async Task<TokenDto> Login(CustomerToLogin NewLoginCustomer )
    //{
    //    var Customer =await _UserMangager.FindByNameAsync(NewLoginCustomer.UserName);
    //    if (Customer is null ||await  _UserMangager.IsLockedOutAsync(Customer))
    //    {
    //    return null;
    //    }
    //    bool isAuthenticated = await _UserMangager.CheckPasswordAsync(Customer , NewLoginCustomer.Password);
    //    if (! isAuthenticated ) {
    //    _UserMangager.AccessFailedAsync(Customer);
    //        return null;
    //    }

    //    var CustomerClaims = await _UserMangager.GetClaimsAsync(Customer);

    //    // Generate Tkey 
    //    var secretkey = _configuration["secretkey"];
    //    var secretkeyinbytes = Encoding.ASCII.GetBytes(secretkey);
    //    var key = new SymmetricSecurityKey(secretkeyinbytes);
       
    //    // Generate Hashing Result 
    //    var HashingResult = new SigningCredentials(key , SecurityAlgorithms.HmacSha256Signature);

    //    //Generate JWt Token 
    //    // Calc Expiration Date 
    //    var ExpirationDate = DateTime.Now.AddMinutes(30);
    //    var Jwt = new JwtSecurityToken(
    //        claims: CustomerClaims,
    //        notBefore:DateTime.Now,
    //        expires: ExpirationDate,
    //        signingCredentials: HashingResult 
    //        );

    //    var TokenHandler = new JwtSecurityTokenHandler();
    //    string TokenString  = TokenHandler.WriteToken(Jwt);

    //    return new TokenDto()
    //    { Token = TokenString,
    //        ExpirationDate = ExpirationDate
    //    };
    //}

    public CreditToRead UpdateCardCutomerData(int Customerid, CreditToUpdate creditCard)
    {
        var DbCreditCard  = _unitOfWork.Customers.GetCustomerByIdWithNavprop(Customerid).CustomerCreditCard;
        if (DbCreditCard != null) {
            DbCreditCard.Card_Number = creditCard.Card_Number;
            DbCreditCard.Card_Expiration_Date = creditCard.Card_Expiration_Date;
            DbCreditCard.CVV = creditCard.CVV;
            _unitOfWork.Save();

        }
        return new CreditToRead() {CustomerId= DbCreditCard.CreditId ,
                    Card_Number = DbCreditCard.Card_Number,
            Card_Expiration_Date = DbCreditCard.Card_Expiration_Date,
            CVV = DbCreditCard.CVV
        };


    }

    //public Location UpdateAddressCutomer(int Customerid, LocationToUpadate NewLocation)
    //{
    //    var DbCustomerAddress  = _unitOfWork.Customers.GetCustomerByIdWithNavprop(Customerid).CustomerAddress;
    //    if (DbCustomerAddress != null)
    //    {
    //        DbCustomerAddress.Latitude = NewLocation.Latitude;
    //        DbCustomerAddress. Longitude= NewLocation.Longitude;
    //        _unitOfWork.Save();
    //    }
    //    return DbCustomerAddress;


    //}

    public async Task< CustomerModel> UpdateCustomerPersonalData(int Customerid , CustomerToUpdatPersonalData UpdatedCustomer )
    {
       var DbCustomer =  _unitOfWork.Customers.GetById(Customerid);
        if (DbCustomer != null)
        {
            DbCustomer.PhoneNumber = UpdatedCustomer.Phone;
            DbCustomer.UserName = $"{UpdatedCustomer.FirstName}{UpdatedCustomer.LastName}";
            DbCustomer.Email = UpdatedCustomer.Email;
            DbCustomer.BirthDate = UpdatedCustomer.CustomerBirth;
            var newPasswordHash = _UserMangager.PasswordHasher.HashPassword(DbCustomer, UpdatedCustomer.Password);
            DbCustomer.PasswordHash = newPasswordHash;
            _unitOfWork.Save();
        }
        return DbCustomer;
    }

    public bool Delete(int Customerid)
    {
        var deletedCustomer = _unitOfWork.Customers.GetById( Customerid);
        if (deletedCustomer != null) {
            _unitOfWork.Customers.Delete(deletedCustomer);
            _unitOfWork.Save();
            return true;
        }
        return false;
    }
}
