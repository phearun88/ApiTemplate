using ProjectTemplate.DataAccess.Validators;

namespace ProjectTemplate.DataAccess.Models
{
    public class User: ValidatorObject
    {
        /// <summary>
        /// Default constructor for user class
        /// </summary>
        public User() {
            // Validator rules

            AddRule(new ValidateRequired("UserName"));
            AddRule(new ValidateLength("UserName", 1, 30));

            AddRule(new ValidateRequired("Password"));
            AddRule(new ValidateLength("Password", 1, 30));
        }

        /// <summary>
        /// Overloaded constructor for the user class
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public User(string userName, string password)
            : this ()
        {
            UserName = userName;
            Password = password;
        }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the user password.
        /// </summary>
        public string Password { get; set; }
    }
}


