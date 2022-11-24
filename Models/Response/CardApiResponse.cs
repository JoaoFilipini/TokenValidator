using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenValidator.Models
{
    public class CardApiResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }
    }
}
