using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smolensk.Models.ModelValidators.Attributes;

namespace smolensk.Models.ModelValidators
{
    public class NeedOneValidator : DataAnnotationsModelValidator<NeedOneAttribute> 
    {
        private string m_message;

        public NeedOneValidator(ModelMetadata metadata, ControllerContext context, NeedOneAttribute attribute) 
            : base(metadata, context, attribute) 
        {
            m_message = attribute.ErrorMessage;
        }

        public override IEnumerable<ModelClientValidationRule>  GetClientValidationRules() 
        {
            var rule = new ModelClientValidationRule {
              ErrorMessage = m_message,
              ValidationType = "needOne"
            };
        
            return new[] { rule };
        }
    }
}