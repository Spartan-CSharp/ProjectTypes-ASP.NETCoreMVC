using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using SayHi.Models;

namespace SayHi.Controllers
{
	public class SayHiController : Controller
	{
		private readonly ILogger<SayHiController> _logger;

		[BindProperty]
		private PersonModel Person { get; set; } = new PersonModel();

		public SayHiController(ILogger<SayHiController> logger)
		{
			_logger = logger;
		}

		// GET: SayHi
		public ActionResult Index()
		{
			_logger.LogInformation("GET, SayHi Controller, Index View, Person Model");
			return View();
		}

		// GET: SayHi/Create
		public ActionResult Create()
		{
			_logger.LogInformation("GET, Say Hi Controller, Create View, Person Model");
			return View();
		}

		// GET: SayHi/Details
		public ActionResult Details(PersonModel person)
		{
			_logger.LogInformation("GET, Say Hi Controller, Details View, PersonModel Model: {person}", person);
			Person = person;
			return View(Person);
		}

		// POST: SayHi/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(PersonModel person)
		{
			_logger.LogInformation("POST, Say Hi Controller, Create View, Person Model: {person}", person);

			try
			{
				if ( ModelState.IsValid )
				{
					Person.FirstName = person.FirstName;
					Person.LastName = person.LastName;
					return RedirectToAction(nameof(Details), Person);
				}
				else
				{
					return RedirectToAction(nameof(Index));
				}
			}
			catch
			{
				return View();
			}
		}
	}
}
