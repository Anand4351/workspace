using ManPowerProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
namespace ManPowerProject.Controllers
{
  
    public class AppDBContex : DbContext
    {
        public AppDBContex( DbContextOptions<AppDBContex> options ):base(options) { }
        public DbSet <Tasks> tasks { get; set; }
    }

}
