namespace ProjectTemplate.DataAccess.Validators
{
    /// <summary>
    /// Abstract base class for validator rule     
    /// </summary>
    public abstract class ValidatorRule
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyName">The property name to which rule applies.</param>
        public ValidatorRule(string propertyName)
        {
            PropertyName = propertyName;
            ErrorMessage = propertyName + " is not valid";
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="propertyName">The property name to which rule applies.</param>
        /// <param name="errorMessage">The error message.</param>
        public ValidatorRule(string propertyName, string errorMessage)
            : this(propertyName)
        {
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Validation method. To be implemented in derived classes.
        /// </summary>
        /// <param name="validatorObject"></param>
        /// <returns></returns>
        public abstract bool Validate(ValidatorObject validatorObject);

        /// <summary>
        /// Gets value for given business object's property using reflection.
        /// </summary>
        /// <param name="validatorObject"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected object GetPropertyValue(ValidatorObject validatorObject)
        {
            return validatorObject.GetType().GetProperty(PropertyName).GetValue(validatorObject, null);
        }
    }
}


