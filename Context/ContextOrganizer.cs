using Microsoft.EntityFrameworkCore;
using DotNet_API_MVC.Models;

namespace DotNet_API_MVC.Context
{
    public class ContextOrganizer : DbContext
    {
        public ContextOrganizer(DbContextOptions<ContextOrganizer> options) : base(options)
        {
            
        }

        public DbSet<Assignment> Assignments { get; set; }
    }
}