using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace AutomobileLibrary.Models
    {
        public class Car
        {
            [Key]
            public int CarId { get; set; }
            [Required]
            public string CarName { get; set; }
            [Required]
            public string Manufacturer { get; set; }
            [Column(TypeName = "decimal(18,2)")]
            public decimal Price { get; set; }
            public int ReleasedYear { get; set; }
        }
    }

}
