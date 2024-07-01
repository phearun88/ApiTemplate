namespace ProjectTemplate.DataAccess.Validators
{
    /// <summary>
    /// A validation rule to check the required value.
    /// </summary>
    public class ValidateRequired : ValidatorRule
    {

        public ValidateRequired(string propertyName)
            : base(propertyName)
        {
            ErrorMessage = propertyName + " is a required field.";
        }

        public ValidateRequired(string propertyName, string errorMessage)
            : base(propertyName)
        {
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validatorObject"></param>
        /// <returns></returns>
        public override bool Validate(ValidatorObject validatorObject)
        {
            try
            {
                return GetPropertyValue(validatorObject).ToString()!.Length > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}


