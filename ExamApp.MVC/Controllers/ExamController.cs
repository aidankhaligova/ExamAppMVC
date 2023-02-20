using ExamApp.Service.Abstract.Service;
using ExamApp.Service.ViewModels.Exam;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.MVC.Controllers
{
    [Route("[controller]")]
    public class ExamController : Controller
    {
        private readonly IExamService _examService;
        private readonly IStudentService _studentService;
        private readonly ILessonService _lessonService;
        public ExamController(IExamService examService, IStudentService studentService, ILessonService lessonService)
        {
            _examService = examService;
            _studentService = studentService;
            _lessonService = lessonService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var vms = await _examService.GetAll();
            return View("Index", vms);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            var lessons = (await _lessonService.GetAll()).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Code
            });
            var students = (await _studentService.GetAll()).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.No.ToString()
            });
            ViewBag.Lessons = lessons;
            ViewBag.Students = students;
            return View("Create");
        }

        [HttpPost("CreateExam")]
        public async Task<ActionResult> Create(CreateExamViewModel vm)
        {
            await _examService.Create(vm);
            return RedirectToAction("Index");
        }

        [HttpGet("Update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var vm = await _examService.GetById(id);
            var lessons = (await _lessonService.GetAll()).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Code
            });
            var students = (await _studentService.GetAll()).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.No.ToString()
            });
            ViewBag.Lessons = lessons;
            ViewBag.Students = students;
            return View("Update", vm);
        }

        [HttpPost("UpdateExam")]
        public async Task<IActionResult> Update(ExamViewModel vm)
        {
            await _examService.Update(vm);
            return RedirectToAction("Index");
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _examService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
