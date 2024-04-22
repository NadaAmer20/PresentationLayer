//using BusinessLayer.Interfaces;
//using DataAccessLayer.Models;
//using Microsoft.AspNetCore.Identity; // Update this using statement
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using PresentationLayer.DTOs;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.AspNet.Identity;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace BusinessLayer.Services
//{
//    internal class AuthenticationUserServices : IAuthenticationUserServices
//    {
//        private readonly UserManager<Student> userManager;

//        public AuthenticationUserServices(UserManager<Student> userManager)
//        {
//            this.userManager = userManager;
//        }

//        public Task ChangePassword(ChangePasswordDto changePasswordDto)
//        {
//            throw new NotImplementedException();
//        }

//        public Task Login(LoginDto userDto)
//        {
             
//                 Student user = await userManager.FindByNameAsync(userDto.UserName);
//                if (user != null)
//                {
//                    bool found = await userManager.CheckPasswordAsync(user, userDto.Password);
//                    if (found)
//                    {
//                        //claims token
//                        var claims = new List<Claim>();
//                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
//                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
//                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
//                        //get role
//                        var roles = await userManager.GetRolesAsync(user);
//                        foreach (var item in roles)
//                        {
//                            claims.Add(new Claim(ClaimTypes.Role, item));

//                        }
//                        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
//                        SigningCredentials signing = new SigningCredentials(securityKey,
//                        SecurityAlgorithms.HmacSha256
//                        );

//                        JwtSecurityToken MyToken = new JwtSecurityToken(
//                        issuer: configuration["JWT:ValidIssuer"],
//                        audience: configuration["JWT:ValidAudiance"],
//                        claims: claims,
//                        expires: DateTime.Now.AddDays(30),
//                        signingCredentials: signing
//                        );
//                        return Ok(new
//                        {
//                            token = new JwtSecurityTokenHandler().WriteToken(MyToken),
//                            expiration = MyToken.ValidTo
//                        });
//                    }
//                }

//             }
//         }

//        public async Task Register(RegisterDto registerDto)
//        { 
//            var user = new Student
//            {
//                UserName = registerDto.UserName,
//                Email = registerDto.Email,
//                FirstName = registerDto.FirstName,
//                LastName = registerDto.LastName,
//                Phone = registerDto.Phone,
//                City = registerDto.City,
//                Street = registerDto.Street,
//                Gender = registerDto.Gender,
//                DateOfBirthday = registerDto.DateOfBirthday

//            };

//            var result = await userManager.CreateAsync(user, registerDto.Password);
//            if (!result.Succeeded)
//            {
//                var errors = new List<string>();

//                foreach (var error in result.Errors)
//                {
//                    errors.Add(error.Description);
//                }

//            }
//        }
//    }
//}
