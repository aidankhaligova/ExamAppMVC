using ExamApp.Service.Abstract.Service;
using ExamApp.Service.ViewModels.Student;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.API.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index(StudentViewModel vm)
        {
            var vms = await _studentService.GetAll();
            return View("Index",vms);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            return View("Create");
        }

        [HttpPost("CreateStudent")]
        public async Task<IActionResult> Create(StudentViewModel vm)
        {
            await _studentService.Create(vm);
            return RedirectToAction("Index");
        }

        [HttpGet("Update/{no}")]
        public async Task<IActionResult> Update(short no)
        {
            var vm = await _studentService.GetByNo(no);
            return View("Update", vm);
        }

        [HttpPost("UpdateStudent")]
        public async Task<IActionResult> Update(StudentViewModel vm)
        {
            await _studentService.Update(vm);
            return RedirectToAction("Index");
        }

        [HttpPost("Delete/{no}")]
        public async Task<IActionResult> Delete(short no)
        {
            await _studentService.Delete(no);
            return RedirectToAction("Index");
        }
    }
}
