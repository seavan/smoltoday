using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smolensk.Models.ModelValidators.Attributes;

namespace smolensk.Models.ModelValidators
{
    public class UniqueEMailValidator : DataAnnotationsModelValidator<UniqueEMailAttribute>
    {
        private string m_message;

        public UniqueEMailValidator(ModelMetadata metadata, ControllerContext context, UniqueEMailAttribute attribute)
            : base(metadata, context, attribute)
        {
            m_message = attribute.ErrorMessage;
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = m_message,
                ValidationType = "uniqueEMail"
            };

            return new[] { rule };
        }
    }
}