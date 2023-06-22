using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Wizardsoft.Models
{
	public class HierarchContext : IdentityDbContext
	{
		public HierarchContext(DbContextOptions<HierarchContext> options) 
			: base(options)
    	{
		}

		public DbSet<Hierarch> HierarchItems { get; set; }

		protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder)  
        {  
            if (!optionsBuilder.IsConfigured)
  			{ 
				optionsBuilder.UseSqlServer("server=localhost;port=3306;user=root;password=1212;database=db1");
  			}  
        }  

	}
}
