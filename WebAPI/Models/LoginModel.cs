using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
	public class LoginModel
	{
		[Required]
		[StringLength(50)]
		public string UserName { get; set; }
		[Required]
		[StringLength(50)]
		public string PassWord { get; set; }
	}
}
