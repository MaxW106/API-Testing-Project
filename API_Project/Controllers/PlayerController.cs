using API_Project.Models;
using API_Project.Services;
using API_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
	[Route("players")]
	public class PlayerController : Controller
	{
		private IPlayerData _playerData;

		public PlayerController(IPlayerData playerData)
		{
			_playerData = playerData;
		}

		[Route("")]
		public IActionResult Players()
		{
			return new ObjectResult(_playerData.GetAllPlayers());
		}

		[Route("{id}")]
		public IActionResult Detail(int id)
		{
			var player = _playerData.GetPlayer(id);
			return player == null ? NotFound() : Ok(player);
		}

		[HttpPost]
		public IActionResult Create([FromBody] PlayerCreateViewModel playerCreateViewModel)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var newPlayer = new Player
			{
				FirstName = playerCreateViewModel.FirstName,
				LastName = playerCreateViewModel.LastName,
				ClubId = playerCreateViewModel.ClubId,
				PlayerNumber = playerCreateViewModel.PlayerNumber,

				SinglesRanking = playerCreateViewModel.SinglesRanking > 0 ? playerCreateViewModel.SinglesRanking : 12,
				DoublesRanking = playerCreateViewModel.DoublesRanking > 0 ? playerCreateViewModel.DoublesRanking : 12,
				MixedRanking = playerCreateViewModel.MixedRanking > 0 ? playerCreateViewModel.MixedRanking : 12,
			};

			_playerData.AddPlayer(newPlayer);
			return CreatedAtAction(nameof(Create), new { newPlayer.Id }, newPlayer);
		}
	}
}
