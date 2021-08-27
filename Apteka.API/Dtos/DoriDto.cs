using Apteka.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apteka.API.Dtos
{
    public class CustomDoriDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "Berilgan uzunlikdagi nomni kiriting")]

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
    
    public class DoriDto : CustomDoriDto
    {
        public Guid Id { get; set; }

        public ICollection<FirmaDto> Firmalar { get; set; }
    }



    public class DoriForCreationDto : CustomDoriDto
    {
        public IList<Guid> Ids { get; set; }
    }
}
