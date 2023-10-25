using API_Project.Models;

namespace API_Project.Services
{
	public interface IPlayerData
	{
		IEnumerable<Player> GetAllPlayers();
		Player GetPlayer(int id);
		Player AddPlayer(Player newPlayer);
	}

	public interface IClubData
	{
		IEnumerable<Club> GetAllClubs();
		Club GetClub(int id);
		Club AddClub(Club newClub);
	}

	public interface ILocationData
	{
		IEnumerable<Location> GetAllLocations();
		Location GetLocation(int id);
		Location AddLocation(Location newLocation);
	}

	public class Data : IPlayerData, IClubData, ILocationData
	{
		private static List<Player> _players;
		private static List<Club> _clubs;
		private static List<Location> _locations;

		static Data()
		{
			_players = new List<Player>()
			{
				new Player { Id = 1, FirstName = "Max", LastName = "Wiercx", PlayerNumber = 50801988, ClubId = 1, SinglesRanking = 12, DoublesRanking = 10, MixedRanking = 12 },
				new Player { Id = 2, FirstName = "Wendolien", LastName = "Dockx", PlayerNumber = 50109834, ClubId = 3, SinglesRanking = 12, DoublesRanking = 11, MixedRanking = 12 },
				new Player { Id = 3, FirstName = "Jari", LastName = "Maes", PlayerNumber = 50088445, ClubId = 2, SinglesRanking = 10, DoublesRanking = 10, MixedRanking = 11 }
			};

			_locations = new List<Location>
			{
				new Location { Id = 1, Name = "Sportoase Elshout", Address = "Zwembadweg 7, 2930 Brasschaat", NumberOfCourts = 12 },
				new Location { Id = 2, Name = "Edu-sport", Address = "Broeder Frederikstraat 3, 2170 Merksem", NumberOfCourts = 7},
				new Location { Id = 3, Name = "Sporthal 't Venneke", Address = "Den Geer 21, 2180 Ekeren", NumberOfCourts = 9 },
			};

			_clubs = new List<Club>
			{
				new Club() {Id = 1, Name = "BBC", LocationId = 1},
				new Club() {Id = 2, Name = "Smash", LocationId = 3},
				new Club() {Id = 3, Name = "Bacss", LocationId = 2},
			};
		}

		public IEnumerable<Player> GetAllPlayers()
		{
			return _players;
		}

		public Player GetPlayer(int id)
		{
			return _players.FirstOrDefault(x => x.Id == id);
		}

		public Player AddPlayer(Player newPlayer)
		{
			newPlayer.Id = _players.Max(x => x.Id) + 1;
			_players.Add(newPlayer);
			return newPlayer;
		}

		public IEnumerable<Club> GetAllClubs()
		{
			return _clubs;
		}

		public Club GetClub(int id)
		{
			return _clubs.FirstOrDefault(x => x.Id == id);
		}

		public Club AddClub(Club newClub)
		{
			newClub.Id = _clubs.Max(x => x.Id) + 1;
			_clubs.Add(newClub);
			return newClub;
		}

		public IEnumerable<Location> GetAllLocations()
		{
			return _locations;
		}

		public Location GetLocation(int id)
		{
			return _locations.FirstOrDefault(x => x.Id == id);
		}

		public Location AddLocation(Location newLocation)
		{
			newLocation.Id = _locations.Max(x => x.Id) + 1;
			_locations.Add(newLocation);
			return newLocation;
		}
	}
}

