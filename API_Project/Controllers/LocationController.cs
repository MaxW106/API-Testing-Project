using API_Project.Models;
using API_Project.Services;
using API_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers {

	[Route("locations")]
	public class LocationController : Controller
	{
		private ILocationData _locationData;

		public LocationController(ILocationData locationData)
		{
			_locationData = locationData;
		}

		[Route("")]
		public IActionResult Locations()
		{
			return new ObjectResult(_locationData.GetAllLocations());
		}

		[Route("{id}")]
		public IActionResult Detail(int id)
		{
			var location = _locationData.GetLocation(id);
			return location == null ? NotFound() : Ok(location);
		}

		[HttpPost]
		public IActionResult Create([FromBody] LocationCreateViewModel locationCreateViewModel)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var newLocation = new Location
			{
				Name = locationCreateViewModel.Name,
				Address = locationCreateViewModel.Address,
				NumberOfCourts = locationCreateViewModel.NumberOfCourts,
			};

			_locationData.AddLocation(newLocation);
			return CreatedAtAction(nameof(Detail), new { newLocation.Id }, newLocation);
		}
	}
}
