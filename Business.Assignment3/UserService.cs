using Assignment3;
using DataAccess.Assignment3;
using Entity.Assignment3;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Business.Assignment3
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IConfiguration _configuration;

        public UserService(IUserDal userDal, IConfiguration configuration)
        {
            _userDal = userDal;
            _configuration = configuration;
        }
        public ResponseDto Login(UserForLogin userforlogin)
        {
            ResponseDto response = new ResponseDto();
            var user = _userDal.GetUserByIdentity(userforlogin.IdentityNumber);

            if (user is null)
            {
                response.HasError = true;
                response.Message = "Wrong";
                return response;

            }

            else if (!VerifyPasswordHash(userforlogin.Password, user.PasswordHash, user.PasswordSalt))
            {
                response.HasError = true;
                response.Message = "User Not Found";
                return response;
            }
            else
            {

              
                response.HasError = false;
                response.Message = "User Found";
                response.IdentityNumber = user.IdentityNumber;
                
                return response;
            }
        }

        public ResponseDto VulnerableLogin(UserForLogin userforlogin)
        {
            ResponseDto response = new ResponseDto();
            var user = _userDal.GetNonSecuredUserByIdentity(userforlogin.IdentityNumber);

            if (user is null)
            {
                response.HasError = true;
                response.Message = "Wrong";
                return response;

            }

            else if ((userforlogin.Password != user.Password))
            {
                response.HasError = true;
                response.Message = "User Not Found";
                return response;
            }
            else
            {

               
                response.HasError = false;
                response.Message = "User Found";
                response.IdentityNumber = user.IdentityNumber;

                return response;
            }
        }

        public bool Register(UserForRegister userForRegister)
        {
            var user = _userDal.GetUserByIdentity(userForRegister.IdentityNumber);

            if (user is not null)
            {
                return false;
            }

            else

            {


                CreatePasswordHash(userForRegister.Password, out byte[] passwordHash, out byte[] passwordSalt);
                string dataToSave = Convert.ToBase64String(passwordHash);
                Console.WriteLine(dataToSave);

                user = new User()
                {
                    UserName = userForRegister.UserName,
                 
                    IdentityNumber = userForRegister.IdentityNumber,
                   
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };

                user.CreateDate = DateTime.Now;

            }
            var result = _userDal.Insert(user);
            return true;
        }
         


        // Hashing functions 
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())

            {

                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));


            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }



        public bool VulnerableRegister(UserForRegister userForRegister)
        {
            var user = _userDal.GetNonSecuredUserByIdentity(userForRegister.IdentityNumber);

            if (user is not null)
            {
                return false;
            }

            else

            {
                

                user = new NonSecuredUser()
                {
                    UserName = userForRegister.UserName,

                    IdentityNumber = userForRegister.IdentityNumber,

                    Password = userForRegister.Password
                };

                user.CreateDate = DateTime.Now;

            }
            var result = _userDal.InsertNonSecuredUser(user);
            return true;
        }



    }
}
