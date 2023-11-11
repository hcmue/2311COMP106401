using System.ComponentModel.DataAnnotations;

namespace MyStoreLab.Models
{
	public class LoginVM
	{
		[MaxLength(20)]
		public string Username { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
