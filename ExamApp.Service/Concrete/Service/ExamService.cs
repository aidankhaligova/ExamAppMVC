using AutoMapper;
using ExamApp.Data.Data;
using ExamApp.Service.Abstract.Repository;
using ExamApp.Service.Abstract.Service;
using ExamApp.Service.ViewModels.Exam;

namespace ExamApp.Service.Concrete.Service
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IUnitofWork<ExamDbContext> _unitofWork;
        private readonly IMapper _mapper;
        public ExamService(IExamRepository examRepository, IUnitofWork<ExamDbContext> unitofWork, IMapper mapper)
        {
            _examRepository = examRepository;
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task Create(CreateExamViewModel vm)
        {
            var model = _mapper.Map<Exam>(vm);
            await _examRepository.AddAsync(model);
            await _unitofWork.CommitAsync();
        }
        public async Task Update(ExamViewModel vm)
        {
            var dbModel = await _examRepository.GetByIdAsync(vm.Id);
            dbModel.LessonCode= vm.LessonCode;
            dbModel.StudentNo= vm.StudentNo;
            dbModel.ExamDate = vm.ExamDate;
            dbModel.Grade= vm.Grade;
            _examRepository.Update(dbModel);
            await _unitofWork.CommitAsync();
        }
        public async Task Delete(int id)
        {
            var model = await _examRepository.SingleOrDefaultAsync(x => x.Id == id);
            _examRepository.Remove(model);
            await _unitofWork.CommitAsync();
        }
        public async Task<List<ExamViewModel>> GetAll()
            => _mapper.Map<List<ExamViewModel>>(await _examRepository.GetAllAsync(null,null,nameof(Exam.LessonCodeNavigation)+","+nameof(Exam.StudentNoNavigation)));
        public async Task<ExamViewModel> GetById(int id)
            => _mapper.Map<ExamViewModel>(await _examRepository.SingleOrDefaultAsync(s => s.Id == id, nameof(Exam.LessonCodeNavigation) + "," + nameof(Exam.StudentNoNavigation)));
    }
}
