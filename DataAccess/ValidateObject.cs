using ProjectTemplate.DataAccess.Validators;
using System.Collections.Generic;

namespace ProjectTemplate.DataAccess
{
    /// <summary>
    /// Abstract base class for Validator objects
    /// </summary>
    public abstract class ValidatorObject
    {
        /// <summary>
        /// Default value for version number (used in LINQ's optimistic concurrency)
        /// </summary>
        protected static readonly string _versionDefault = "NotSet";

        // List of validator rules
        private List<ValidatorRule> _validatorRules = new List<ValidatorRule>();

        // List of validation errors (following validation failure)
        private List<string> _validationErrors = new List<string>();

        /// <summary>
        /// Gets list of validations errors.
        /// </summary>
        public List<string> ValidationErrors
        {
            get { return _validationErrors; }
        }

        /// <summary>
        /// Adds a validator rule to the validator object.
        /// </summary>
        /// <param name="rule"></param>
        protected void AddRule(ValidatorRule rule)
        {
            _validatorRules.Add(rule);
        }

        /// <summary>
        /// Determines whether validator rules are valid or not.
        /// Creates a list of validation errors when appropriate.
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            bool isValid = true;

            _validationErrors.Clear();

            foreach (ValidatorRule rule in _validatorRules)
            {
                if (!rule.Validate(this))
                {
                    isValid = false;
                    _validationErrors.Add(rule.ErrorMessage);
                }
            }
            return isValid;
        }
    }
}

