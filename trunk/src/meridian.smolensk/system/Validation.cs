using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace meridian.smolensk.system
{
    public class NeedSelectEntityAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                return long.Parse(value.ToString()) > 0;
            }
            catch {

                return false;
            }
        }
    }

    public class NeedSelectEntityValidator : DataAnnotationsModelValidator<NeedSelectEntityAttribute>
    {
        private string m_message;

        public NeedSelectEntityValidator(ModelMetadata metadata, ControllerContext context, NeedSelectEntityAttribute attribute)
            : base(metadata, context, attribute)
        {
            m_message = attribute.ErrorMessage;
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = m_message,
                ValidationType = "needSelectEntity"
            };

            return new[] { rule };
        }
    }
}
