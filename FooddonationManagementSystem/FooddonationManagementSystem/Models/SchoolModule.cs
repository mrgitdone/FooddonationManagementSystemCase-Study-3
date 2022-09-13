using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooddonationManagementSystem.Models
{
    public class SchoolModule
    {
        [Key]
        public int DonarId { get; set; }
        public string DonarName { get; set; }
        public string VegOrNonVeg { get; set; }
    }
}
