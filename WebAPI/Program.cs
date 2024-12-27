using Aplication;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Persistance;
using System.Globalization;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// thêm dịch vụ từ tầng Application 
builder.Services.AddApplication();
// thêm dịch vụ từ tầng Infrastructure 
builder.Services.AddInfrastructure();
// thêm dịch vụ từ tầng Persistance 
builder.Services.AddPersistance(builder.Configuration);


var secretKey = builder.Configuration["AppSettings:SecretKey"];
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
	opt.TokenValidationParameters = new TokenValidationParameters
	{
		// tự cấp Token 
		ValidateIssuer = false,  // nếu ValidateIssuer = true thì bên appsetting.js pãi có thuộc tính Issuer có giá trị 
		ValidateAudience = false,

		// Ký vào Token 
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

		ClockSkew = TimeSpan.Zero

	};
});
builder.Services.AddAuthorization();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
