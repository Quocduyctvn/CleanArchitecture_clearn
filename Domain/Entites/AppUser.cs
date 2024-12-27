using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
	[Table("AppUSer")]
	public class AppUser
	{
		[Key]
		public int IdUser { get; set; }
		[Required]
		[StringLength(50)]
		public string UserName { get; set; }
		[Required]
		[StringLength(50)]
		public string PassWord { get; set; }
		[Required]
		[StringLength(50)]
		public string HoTen { get; set; }
		[Required]
		[StringLength(50)]
		public string Email { get; set; }


	}
}
