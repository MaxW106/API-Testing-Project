using System.ComponentModel.DataAnnotations;

namespace API_Project.ViewModels
{
	public class LocationCreateViewModel
	{
		[Required, MaxLength(50)]
		public string Name { get; set; }
		[Required, MaxLength(50)]
		public string Address { get; set; }
		[Required]
		public int NumberOfCourts { get; set; }
	}
}
