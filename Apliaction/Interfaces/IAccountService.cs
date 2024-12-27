using Aplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Wrappers;

namespace Aplication.Interfaces
{
	public interface IAccountService
	{
		Task<ApiResponse<Guid>> RegisterUser(RegisterRequest registerRequest);
	}
}
