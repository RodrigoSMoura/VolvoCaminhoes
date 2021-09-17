using System;
using System.ComponentModel.DataAnnotations;

namespace VolvoCaminhoes.Domain.Validation
{
    public class AnoFabricacaoAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var ano = Convert.ToInt32(value);
            return ano == DateTime.Now.Year;
        }
    }
}
