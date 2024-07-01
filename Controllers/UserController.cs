
using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Common;
using ProjectTemplate.DataAccess;
using ProjectTemplate.DataAccess.Models;

namespace ProjectTemplate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // Create data access object
        private IUserDao _userDao;
        private IJwtService _jwtService;
        #region " Contructors "
        /// <summary>
        /// User contructor
        /// </summary>
        public UserController()
        {
            _userDao = DataAccessObject.UserDao;
            _jwtService = new JwtService();
        }
        ///// <summary>
        ///// Contructor for test
        ///// </summary>
        ///// <param name="userDao"></param>
        ///// <param name="jwtService"></param>
        //public UserController(IUserDao userDao, IJwtService jwtService)
        //{
        //    this._userDao = userDao;
        //    this._jwtService = jwtService;
        //}
        #endregion

         

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns>return token if succeed, throw unauthorized message for failure</returns>
        [HttpGet("{name}/{pass}")]
        public string Login(string name, string pass)
        {
            User user = new User(name, pass);
            if (!user.Validate())
            {
                // return bad request - invalid inputs
            }
            // hashed password should be stored in database instead of the actual password for security
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(pass);
            if (_userDao.Login(name, passwordHash))
            {
                string token = _jwtService.CreateToken(user);
                return token;
            }
            else
            {
                throw new UnauthorizedAccessException(Consts.MSG_INCORRECT_USER_NAME_OR_PASSWORD);
            }
        }
        /// <summary>
        /// Validate token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("{token}")]
        public bool ValidateToken(string token)
        {
            if (!_jwtService.ValidateToken(token))
                throw new UnauthorizedAccessException(Consts.MSG_TOKEN_IS_INVALID);
            else

            {
                // List<Claim> claims = _jwtService.GetTokenClaims(token).ToList();
                return true;
            }
        }
    }
}
