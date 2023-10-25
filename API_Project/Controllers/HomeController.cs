using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
	[Route("")]
	public class HomeController : Controller
	{
		[Route("")]
		public string Index()
		{
			return "Home";
		}
	}
}
