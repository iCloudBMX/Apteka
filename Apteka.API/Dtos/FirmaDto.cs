using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apteka.API.Dtos
{
    public class FirmaDto : FirmaForCreationDto
    {
        public Guid Id { get; set; }
    }

    public class FirmaForCreationDto
    {
        public string Name { get; set; }
    }
}
