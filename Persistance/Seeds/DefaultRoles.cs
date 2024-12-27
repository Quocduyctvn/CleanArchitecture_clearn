using Aplication.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Persistance.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Seeds
{
	public static class DefaultRoles
	{
		public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
		{
			var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

			var SuperAdmin = new ApplicationRole();
			SuperAdmin.Name = Roles.SuperAdmin.ToString();
			SuperAdmin.NormalizedName = Roles.SuperAdmin.ToString().ToUpper();
			await roleManager.CreateAsync(SuperAdmin);

			var Admin = new ApplicationRole();
			Admin.Name = Roles.Admin.ToString();
			Admin.NormalizedName = Roles.Admin.ToString().ToUpper();
			await roleManager.CreateAsync(Admin);


			var Basic = new ApplicationRole();
			Basic.Name = Roles.Basic.ToString();
			Admin.NormalizedName = Roles.Basic.ToString().ToUpper();
			await roleManager.CreateAsync(Basic);
		}
	}
}
