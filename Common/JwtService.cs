using ProjectTemplate.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Runtime.Intrinsics.X86;

namespace ProjectTemplate.Common
{
    public class JwtService : IJwtService
    {
        private static readonly string _secretKey = ConfigurationSettingService.GetAppSetting(Consts.APP_SETTINGS_SECRET_KEY); //TODO: move to configuration server/service
        private static readonly string _securityAlgorithm = SecurityAlgorithms.HmacSha256Signature;
        private static readonly int _expireMinutes = 4320; // 3 days
                                                           
        private static readonly SymmetricSecurityKey _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        private static readonly TokenValidationParameters _tokenValidationParams = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = _symmetricSecurityKey
        };

        /// <summary>
        /// Create a new token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public string CreateToken(User user)
        {
            Claim[] claims = new Claim[] { new Claim(ClaimTypes.Name, user.UserName) };
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_expireMinutes)),
                SigningCredentials = new SigningCredentials(_symmetricSecurityKey,

            _securityAlgorithm)
            };
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken =
            jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            string token = jwtSecurityTokenHandler.WriteToken(securityToken);
            return token;
        }
        /// <summary>
        /// Validate Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException(Consts.MSG_TOKEN_IS_REQUIRED);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(token,

                _tokenValidationParams, out SecurityToken validatedToken);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Claim> GetTokenClaims(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException(Consts.MSG_TOKEN_IS_REQUIRED);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(token,

                _tokenValidationParams, out SecurityToken validatedToken);

                return tokenValid.Claims;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public interface IJwtService
    {
        /// <summary>
        /// Create a new token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string CreateToken(User user);
        /// <summary>
        /// Validate Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        bool ValidateToken(string token);

        /// <summary>
        ///
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        IEnumerable<Claim> GetTokenClaims(string token);
    }

}