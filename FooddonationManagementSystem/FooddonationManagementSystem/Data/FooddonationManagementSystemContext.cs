using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FooddonationManagementSystem.Models;

namespace FooddonationManagementSystem.Data
{
    public class FooddonationManagementSystemContext : DbContext
    {
        public FooddonationManagementSystemContext (DbContextOptions<FooddonationManagementSystemContext> options)
            : base(options)
        {
        }

        public DbSet<FooddonationManagementSystem.Models.SchoolModule> SchoolModule { get; set; }
    }
}
