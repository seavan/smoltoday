using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace smolensk.Models.ModelValidators.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class EqualityAttribute : ValidationAttribute, ICrossFieldValidationAttribute
    {
        public string FieldForComparison { get; set; }

        public bool IsValid(ControllerContext controllerContext, object model, ModelMetadata modelMetadata)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            var propertyInfo = model.GetType().GetProperty(FieldForComparison);
            if (propertyInfo == null)
            {
                throw new InvalidOperationException(string.Format("Не найдено свойство '{0}' в модели '{1}'.", FieldForComparison, model));
            }
            var comparedValue = propertyInfo.GetGetMethod().Invoke(model, null);

            if (modelMetadata.Model == null) modelMetadata.Model = string.Empty;
            if (comparedValue == null) comparedValue = string.Empty;

            return modelMetadata.Model.ToString() == comparedValue.ToString();
        }
        public override bool IsValid(object value)
        {
            return true;
        }
    }
}