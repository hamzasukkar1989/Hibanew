using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hiba.Models
{
    public class Contact
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int Phone { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string Education { get; set; }
        public string Work { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
