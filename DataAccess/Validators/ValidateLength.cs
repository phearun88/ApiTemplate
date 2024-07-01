namespace ProjectTemplate.DataAccess.Validators
{
    /// <summary>
    ///  Length validation rule. 
    ///  Length must be between given min and max values.
    /// </summary>
    public class ValidateLength : ValidatorRule
    {
        private readonly int _min;
        private readonly int _max;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public ValidateLength(string propertyName, int min, int max)
            : base(propertyName)
        {
            _min = min;
            _max = max;

            ErrorMessage = $"{propertyName} must be between {_min} and {_max} characters long.";
        }

        public ValidateLength(string propertyName, string errorMessage, int min, int max)
            : this(propertyName, min, max)
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
            int length = GetPropertyValue(validatorObject).ToString()!.Length;
            return length >= _min && length <= _max;
        }
    }
}


