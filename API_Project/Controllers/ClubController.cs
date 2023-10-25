using API_Project.Models;
using API_Project.Services;
using API_Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API_Project.Controllers
{
	[Route("clubs")]
	public class ClubController : Controller
	{
		private IClubData _clubData;

		public ClubController(IClubData clubData)
		{
			_clubData = clubData;
		}

		[Route("")]
		public IActionResult Clubs()
		{
			return new ObjectResult(_clubData.GetAllClubs());
		}

		[Route("{id}")]
		public IActionResult Detail(int id)
		{
			var club = _clubData.GetClub(id);
			return club == null ? NotFound() : Ok(club);
		}

		[HttpPost]
		public IActionResult Create([FromBody] ClubCreateViewModel clubCreateViewModel)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var newClub = new Club
			{
				Name = clubCreateViewModel.Name,
				LocationId = clubCreateViewModel.LocationId,
			};

			_clubData.AddClub(newClub);
			return CreatedAtAction(nameof(Detail), new { newClub.Id }, newClub);
        }
	}
}
