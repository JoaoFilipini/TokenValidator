using System;

namespace TokenValidator.Models
{
    public class CardRegisterApiResponse
    {
        public int Id { get; set; }
        public long Token { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
