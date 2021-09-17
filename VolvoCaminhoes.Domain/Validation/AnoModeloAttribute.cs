using System;
using System.ComponentModel.DataAnnotations;

namespace VolvoCaminhoes.Domain.Validation
{
    public class AnoModeloAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var ano = Convert.ToInt32(value);
            return ano == DateTime.Now.Year || ano == DateTime.Now.AddYears(1).Year;
        }
    }
}
