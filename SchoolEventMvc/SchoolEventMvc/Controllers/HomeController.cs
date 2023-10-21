using Microsoft.AspNetCore.Mvc;
using SchoolEventMvc.Repositories.Abstract;

namespace SchoolEventMvc.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IEventService _eventService;
        public HomeController(IEventService eventService)
        {
            _eventService = eventService;
        }
        public IActionResult Index()
        {
            var events = _eventService.List();
            return View(events);
        }
        public IActionResult About() 
        {
            return View();
        }
    }
}
