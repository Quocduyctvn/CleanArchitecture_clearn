using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
	public  class RegisterRequest
	{
		public string LastName { get; set; }

		public string FirstName { get; set; }

		public string Gender { get; set; }

		public string Email { get; set; }

		public string UserName { get; set; }
		[Required]
		[MinLength(6)]
		public string Password { get; set; }
		[Required]
		[Compare("Password")]
		public string cf_Password { get; set; }

	}
}
