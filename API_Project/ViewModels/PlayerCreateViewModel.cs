using System.ComponentModel.DataAnnotations;

namespace API_Project.ViewModels
{
	public class PlayerCreateViewModel
	{
		[Required, MaxLength(50)]
		public string FirstName { get; set; }
		[Required, MaxLength(50)]
		public string LastName { get; set; }
		[Required]
		public int PlayerNumber { get; set; }
		[Required]
		public int ClubId { get; set; }

		public int SinglesRanking { get; set; }
		public int DoublesRanking { get; set; }
		public int MixedRanking { get; set; }
	}
}
