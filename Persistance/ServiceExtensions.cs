using Aplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.IdentityModels;
using Persistance.Seeds;
using Persistance.SharedServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
	public static class ServiceExtensions
	{
		public static async void AddPersistance(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(
				configuration.GetConnectionString("DefaultConnection")
			));


			services.AddIdentityCore<ApplicationUser>()
				.AddRoles<ApplicationRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>();
				
			services.AddScoped<IApplicationDbContext,  ApplicationDbContext>();


			services.AddTransient<IAccountService, AccountServices>();
			await DefaultRoles.SeedRolesAsync(services.BuildServiceProvider());
			await DefaultUsers.SeedUsersAsync(services.BuildServiceProvider());
		}
	}
}
