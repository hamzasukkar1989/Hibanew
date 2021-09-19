using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiba.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string Education { get; set; }
        public string Work { get; set; }
        public string Message { get; set; }
    }
}
