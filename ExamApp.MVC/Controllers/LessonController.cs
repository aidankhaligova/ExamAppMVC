using ExamApp.Service.Abstract.Service;
using ExamApp.Service.ViewModels.Lesson;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.API.Controllers
{
    [Route("[controller]")]  
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            List<LessonViewModel> lessons = await _lessonService.GetAll();
            return View("Index",lessons);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            return View("Create");
        }

        [HttpPost("CreateLesson")]
        public async Task<IActionResult> Create(LessonViewModel vm)
        {
            await _lessonService.Create(vm);
            return RedirectToAction("Index");
        }

        [HttpGet("Update/{code}")]
        public async Task<IActionResult> Update(string code)
        {
            var vm = await _lessonService.GetByCode(code);
            return View("Update", vm);
        }

        [HttpPost("UpdateLesson")]
        public async Task<IActionResult> Update(LessonViewModel vm)
        {
            await _lessonService.Update(vm);
            return RedirectToAction("Index");
        }

        [HttpPost("Delete/{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            await _lessonService.Delete(code);
            return RedirectToAction("Index");
        }
    }
}
