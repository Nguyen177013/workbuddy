using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WorkBuddyServer.Entity;

namespace WorkBuddyServer.Utils
{
    public class UserSecurity
    {
        private readonly IConfiguration _configuration;

        public UserSecurity(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public string MD5Hash(string password)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder stringBuilder = new StringBuilder();
            for(int i=0; i<data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString());
            }
            return stringBuilder.ToString();
        }
        public bool CompareMD5Hash(string password, string hashedPassword)
        {
            string hashPassword = MD5Hash(password);
            return string.Equals(hashPassword, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }

        public string CreateToken(User user)
        {
            string secretKey = _configuration.GetValue<string>("JWTSecretKey");
            if(secretKey == null)
            {
                throw new ArgumentNullException();
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.UTF8.GetBytes(secretKey);
            var tokenDescription = new SecurityTokenDescriptor 
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserName", user.UserName),
                    new Claim("UserId", user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
