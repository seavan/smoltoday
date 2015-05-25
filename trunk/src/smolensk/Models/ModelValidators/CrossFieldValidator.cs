using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smolensk.Models.ModelValidators.Attributes;

namespace smolensk.Models.ModelValidators
{
    public abstract class CrossFieldValidator<TAttribute> : DataAnnotationsModelValidator<TAttribute> where TAttribute : ValidationAttribute, ICrossFieldValidationAttribute
    {
        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            var attribute = Attribute as ICrossFieldValidationAttribute;

            if (!attribute.IsValid(ControllerContext, container, Metadata))
            {
                yield return new ModelValidationResult { Message = ErrorMessage };
            }
        }

        public CrossFieldValidator(ModelMetadata modelMetadata, ControllerContext controllerContext, TAttribute _attribute)
            : base(modelMetadata, controllerContext, _attribute)
        {
        }
    }
}