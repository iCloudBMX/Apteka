using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apteka.API.Dtos
{
    public class DoriDto : DoriForCreationDto
    {
        public Guid Id { get; set; }
    }

    public class DoriForCreationDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "Berilgan uzunlikdagi nomni kiriting")]

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
