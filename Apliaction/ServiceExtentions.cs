using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
	public static class ServiceExtensions
	{
		public static void AddApplication(this IServiceCollection services)
		{
			//Auto Mapper 
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			// thêm dịch vụ MediatR vào trong project 
			services.AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			// Fluent validations 
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());	
		}
	}
}
