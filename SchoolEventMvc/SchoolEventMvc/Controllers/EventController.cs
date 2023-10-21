using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolEventMvc.Models.Domain;
using SchoolEventMvc.Repositories.Abstract;

namespace SchoolEventMvc.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IFileService _fileService;
        private readonly IGenreService _genService;

        public EventController(IGenreService genService, IEventService EventService, IFileService fileService)
        {
            _eventService = EventService;
            _fileService = fileService;
            _genService = genService;
        }
        public IActionResult Add()
        {
            var model = new Event();
            model.GenreList = _genService.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() });
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Event model)
        {
            model.GenreList = _genService.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() });


            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileResult = this._fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 == 0)
                {
                    TempData["msg"] = "File could not be saved";
                }
                var imageName = fileResult.Item2;
                model.EventImage = imageName;
            }
            var result = _eventService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult Edit(int id)
        {
            var model = _eventService.GetById(id);
            // model.GenreList = _genService.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() });
            var selectGenres = _eventService.GetGenreByEventId(model.Id);
            MultiSelectList multiGenreList = new MultiSelectList(_genService.List(), "Id", "GenreName", selectGenres);
            model.MultiGenreList = multiGenreList;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Event model)
        {
            // model.GenreList = _genService.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() });
            var selectGenres = _eventService.GetGenreByEventId(model.Id);
            MultiSelectList multiGenreList = new MultiSelectList(_genService.List(), "Id", "GenreName", selectGenres);
            model.MultiGenreList = multiGenreList;

            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileResult = this._fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 == 0)
                {
                    TempData["msg"] = "File could not be saved";
                    return View(model);
                }
                var imageName = fileResult.Item2;
                model.EventImage = imageName;
            }
            var result = _eventService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(EventList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult EventList()
        {
            var data = this._eventService.List();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var result = _eventService.Delete(id);
            return RedirectToAction(nameof(EventList));
        }
    }
}
