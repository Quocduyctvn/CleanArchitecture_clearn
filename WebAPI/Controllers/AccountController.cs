using Aplication.DTOs;
using Aplication.Features.Products.Commands;
using Aplication.Features.Products.Queries;
using Aplication.Interfaces;
using Application.Wrappers;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Persistance.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Models;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		protected readonly ApplicationDbContext _context;
		protected readonly IAccountService _accountService;
		protected readonly IConfiguration _configuration;
		protected readonly string _secretKey;
		public AccountController(IAccountService accountService, IConfiguration configuration, ApplicationDbContext context)
		{
			_accountService = accountService;
			_configuration = configuration;
			_secretKey = _configuration["AppSettings:SecretKey"];
			_context = context;
		}



		[HttpPost("Login")]
		public IActionResult Validate(LoginModel model)
		{
			var user = _context.AppUsers.FirstOrDefault(i => i.UserName == model.UserName && i.PassWord == i.PassWord);
			if (user == null)
			{
				return Ok(new ApiResponse
				{
					Success = false,
					Message = "InValid UserName/Pass"
				});
			}
			// cấp Token 
			return Ok(new ApiResponse
			{
				Success = true,
				Message = "Authenticatio Success",
				Data = GenerateToken(user),
			});
		}

		private string GenerateToken(AppUser user)
		{
			var JWTHandler = new JwtSecurityTokenHandler();
			var secretKeyBytes = Encoding.UTF8.GetBytes(_secretKey);
			var tokenDescriptor = new SecurityTokenDescriptor()
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Name, user.UserName),
					new Claim(ClaimTypes.Email, user.Email),
					new Claim("UserName", user.UserName),
					new Claim("Id", user.IdUser.ToString()),

					// Role 
					new Claim("TokenId", Guid.NewGuid().ToString())
				}),
				Expires = DateTime.UtcNow.AddMinutes(1),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
			};
			var token = JWTHandler.CreateToken(tokenDescriptor);

			return JWTHandler.WriteToken(token);
		}














		//[HttpPost("RegisterUser")]
		//public async Task<IActionResult> RegisterUser(RegisterRequest registerModel, CancellationToken cancellationToken)
		//{
		//	var result = _accountService.RegisterUser(registerModel);
		//	return Ok(result);
		//}

	}
}
