using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apteka.API.Models
{
    public class DoriFirma
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Dori> Dorilar { get; set; }
            = new List<Dori>();
    }
}
