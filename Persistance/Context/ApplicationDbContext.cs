using Aplication.Interfaces;
using Domain.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistance.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
	public  class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IApplicationDbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
		public DbSet<Product> Products { get; set; }
		public DbSet<AppUser> AppUsers { get; set; }
		public async Task<int> SaveChangesAsync()
		{
			return await base.SaveChangesAsync();
		}

	}
}
