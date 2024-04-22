using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTOs;
using System.Security.Claims;
using DataAccessLayer.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PresentationLayer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly UserManager<Student> usermanger;
        private readonly IConfiguration configuration;
        public static IWebHostEnvironment _env;

        public UserController(IWebHostEnvironment env, UserManager<Student> usermanger,
            IConfiguration configuration)
        {
            this.usermanger = usermanger;
            this.configuration = configuration;
            _env = env;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterDto model)
        {
            
            try
            {
                if (ModelState.IsValid == true)
                {
                    var User = new Student
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Phone = model.Phone,
                        City = model.City,
                        Street = model.Street,
                        Gender = model.Gender,
                        DateOfBirthday = model.DateOfBirthday
                    };
                    if (await usermanger.FindByEmailAsync(User.Email) != null)
                    {
                        return BadRequest("This Email Already Exsists");
                    }
                    else if (await usermanger.FindByNameAsync(User.UserName) != null)
                    {
                        return BadRequest("This Name Is already Exsists");
                    }
                     IdentityResult result = await usermanger.CreateAsync(User, model.Password);

                    if (result.Succeeded)
                    {
                        return Ok("Account Add Succeeded");
                    }
                    else
                    {
                        var Errors = string.Empty;
                        foreach (var error in result.Errors)
                        {
                            Errors += $"{error.Description}'  '";
                        }
                        return BadRequest(Errors);
                    }
                }
                else
                    return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred during registration.");

            }

        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromForm] LoginDto userDto)
        //{
        //    if (ModelState.IsValid)
        //    {  //check + create token  
        //        Student user = await usermanger.FindByNameAsync(userDto.UserName);
        //        if (user != null)
        //        {
        //            bool found = await usermanger.CheckPasswordAsync(user, userDto.Password);
        //            if (found)
        //            {
        //                //claims token
        //                var claims = new List<Claim>();
        //                claims.Add(new Claim(ClaimTypes.Name, user.UserName));
        //                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
        //                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        //                //get role
        //                var roles = await usermanger.GetRolesAsync(user);
        //                foreach (var item in roles)
        //                {
        //                    claims.Add(new Claim(ClaimTypes.Role, item));

        //                }
        //                SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
        //                SigningCredentials signing = new SigningCredentials(securityKey,
        //                SecurityAlgorithms.HmacSha256
        //                );

        //                JwtSecurityToken MyToken = new JwtSecurityToken(
        //                issuer: configuration["JWT:ValidIssuer"],
        //                audience: configuration["JWT:ValidAudiance"],
        //                claims: claims,
        //                expires: DateTime.Now.AddDays(30),
        //                signingCredentials: signing
        //                );
        //                return Ok(new
        //                {
        //                    token = new JwtSecurityTokenHandler().WriteToken(MyToken),
        //                    expiration = MyToken.ValidTo
        //                });
        //            }
        //        }

        //        return Unauthorized();
        //    }
        //    return Unauthorized();
        //}
        ////...............................................................................
        //[HttpPost("ForgetPassword")]

        //public async Task<IActionResult> ForgetPassword([FromForm] ForgetPasswordDto _user)
        //{
        //    Student user = await usermanger.FindByNameAsync(_user.UserName);
        //    var token = await usermanger.GeneratePasswordResetTokenAsync(user);
        //    if (user != null)
        //    {

        //        var result = await usermanger.ResetPasswordAsync(user, token, _user.ChangePass);
        //        if (result.Succeeded)
        //        {

        //            return Ok("New PassWord Add Done");
        //        }
        //        else
        //        {
        //            var Errors = string.Empty;
        //            foreach (var error in result.Errors)
        //            {
        //                Errors += $"{error.Description}  +  ";
        //            }
        //            return BadRequest(Errors);
        //        }


        //    }
        //    return Unauthorized();
        //}
        ////..........................................................................
        //[HttpPost("changePassword")]
        //public async Task<IActionResult> changePassword([FromForm] ChangePasswordDto _user)
        //{
        //    Student user = await usermanger.FindByNameAsync(_user.UserName);
        //    if (user != null)
        //    {

        //        var result = await usermanger.ChangePasswordAsync(user, _user.OldPassword, _user.NewPassword);

        //        if (result.Succeeded)
        //        {

        //            return Ok("Password  Change Succeeded");
        //        }
        //        else
        //        {
        //            var Errors = string.Empty;
        //            foreach (var error in result.Errors)
        //            {
        //                Errors += $"{error.Description}  +  ";
        //            }
        //            return BadRequest(Errors);
        //        }


        //    }
        //    return Unauthorized();
        //}

        //[HttpGet("ShowUser")]
        //public async Task<IActionResult> getAccount()
        //{
        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    if (userId == null)
        //        return BadRequest("You must log in first");
        //    var user = await usermanger.FindByIdAsync(userId);
        //    ShowUserDto showUser = new ShowUserDto();
        //    showUser.UserName = user.UserName;
        //    showUser.FirstName = user.FirstName;
        //    showUser.LastName = user.LastName;
        //    showUser.Phone = user.Phone;
        //    showUser.Email = user.Email;
        //    showUser.Street = user.Street;
        //    showUser.City = user.City;
        //    return Ok(showUser);
        //}




    }
}
