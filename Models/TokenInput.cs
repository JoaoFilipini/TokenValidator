using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TokenValidator.Models
{
    public class TokenInput : IValidatableObject
    {
        public int CustomerId { get; set; }
        public int CardId { get; set; }
        public long Token { get; set; }
        public int CVV { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CVV.ToString().Length > 5)
            {
                yield return new ValidationResult("CVV has 05 characteres max", new[] { nameof(CVV) });
            }
        }
    }
}
