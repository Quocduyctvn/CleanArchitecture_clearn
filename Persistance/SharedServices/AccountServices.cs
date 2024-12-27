using Aplication.DTOs;
using Aplication.Enums;
using Aplication.Interfaces;
using Application.Exceptions;
using Application.Wrappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Persistance.IdentityModels;
using System;
using System.Threading.Tasks;

namespace Persistance.SharedServices
{
	public class AccountServices : IAccountService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IConfiguration _configuration;
		public AccountServices(UserManager<ApplicationUser> userManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_configuration = configuration;
		}


		public async Task<ApiResponse<Guid>> RegisterUser(RegisterRequest registerRequest)
		{
			var user = await _userManager.FindByEmailAsync(registerRequest.Email);
			if (user != null)
			{
				throw new ApiException($"User already taken {registerRequest.Email}");
			}

			var userModel = new ApplicationUser();

			userModel.UserName = registerRequest.UserName;
			userModel.Email = registerRequest.Email;
			userModel.FirstName = registerRequest.FirstName;
			userModel.LastName = registerRequest.LastName;
			userModel.Gender = registerRequest.Gender;
			userModel.EmailConfirmed = true;
			userModel.PhoneNumberConfirmed = true;

			var result = await _userManager.CreateAsync(userModel, registerRequest.Password);

			if (result.Succeeded)
			{
				await _userManager.AddToRoleAsync(userModel, Roles.Basic.ToString());
				return new ApiResponse<Guid>(userModel.Id, "User Register successfuly");
			}
			else
			{
					throw new ApiException(result.Errors.ToString());
			}


		}
	}
}
