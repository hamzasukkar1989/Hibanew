using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Hiba.Common.Enums;

namespace Hiba.Models
{
    public class AddToYourInformation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public AddToYourInformationType AddToYourInformationType { get; set; }
    }
}
