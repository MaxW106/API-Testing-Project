using System.ComponentModel.DataAnnotations;

namespace API_Project.ViewModels
{
	public class ClubCreateViewModel
	{
		[Required, MaxLength(50)]
		public string Name { get; set; }
		[Required]
		public int LocationId { get; set; }
	}
}
