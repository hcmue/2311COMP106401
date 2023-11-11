using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoIdentity.Data
{
	[Table("Category")]
	public class Category
	{
		[Key]
		public int Id { get; set; }
		[MaxLength(100)]
		public string Name { get; set; }
	}
}
