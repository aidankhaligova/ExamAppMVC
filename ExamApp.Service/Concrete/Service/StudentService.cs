using AutoMapper;
using ExamApp.Data.Data;
using ExamApp.Service.Abstract.Repository;
using ExamApp.Service.Abstract.Service;
using ExamApp.Service.ViewModels.Student;

namespace ExamApp.Service.Concrete.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitofWork<ExamDbContext> _unitofWork;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepository, IUnitofWork<ExamDbContext> unitofWork, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task Create(StudentViewModel vm)
        {
            var model = _mapper.Map<Student>(vm);
            await _studentRepository.AddAsync(model);
            await _unitofWork.CommitAsync();
        }
        public async Task Update(StudentViewModel vm)
        {
            var dbModel = await _studentRepository.SingleOrDefaultAsync(x => x.No == vm.No);
            dbModel.Name = vm.Name;
            dbModel.Surname = vm.Surname;
            dbModel.Class = vm.Class;
            _studentRepository.Update(dbModel);
            await _unitofWork.CommitAsync();
        }
        public async Task Delete(short no)
        {
            var model = await _studentRepository.SingleOrDefaultAsync(x => x.No == no);
            _studentRepository.Remove(model);
            await _unitofWork.CommitAsync();
        }
        public async Task<List<StudentViewModel>> GetAll()
            => _mapper.Map<List<StudentViewModel>>(await _studentRepository.GetAllAsync());
        public async Task<StudentViewModel> GetByNo(short no)
            => _mapper.Map<StudentViewModel>(await _studentRepository.SingleOrDefaultAsync(s => s.No == no));
    }
}
