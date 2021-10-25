using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiba.Models
{
    public class AddToYourInformationTag
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<AddToYourInformation> AddToYourInformations { get; set; }
    }
}
