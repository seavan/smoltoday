using System;
using System.Collections.Generic;
using System.Linq;
using smolensk.Models.ModelValidators.Attributes;
using System.Web.Mvc;

namespace smolensk.Models.ModelValidators
{
    public class EqualityValidator: CrossFieldValidator<EqualityAttribute>
    {
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "fieldEquality",
                ErrorMessage = Attribute.FormatErrorMessage(Metadata.PropertyName),
            };
            rule.ValidationParameters.Add("fieldForComparison", Attribute.FieldForComparison);
            return new[] { rule };
        }

        public EqualityValidator(ModelMetadata modelMetadata, ControllerContext controllerContext, EqualityAttribute _attribute)
            : base(modelMetadata, controllerContext, _attribute)
        {
        }
    }
}