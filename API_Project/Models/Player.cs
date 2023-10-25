namespace API_Project.Models
{
	public class Player
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
		public int PlayerNumber { get; set; }
        public int ClubId { get; set; }

		public int SinglesRanking { get; set; }
		public int DoublesRanking { get; set; }
		public int MixedRanking { get; set; }

		public void setRankings(int[] rankings)
		{
			SinglesRanking = rankings[0];
			DoublesRanking = rankings[1];
			MixedRanking = rankings[2];
		}
	}
}
