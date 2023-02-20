using AutoMapper;
using ExamApp.Data.Data;
using ExamApp.Service.Abstract.Repository;
using ExamApp.Service.Abstract.Service;
using ExamApp.Service.ViewModels.Lesson;

namespace ExamApp.Service.Concrete.Service
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IUnitofWork<ExamDbContext> _unitofWork;
        private readonly IMapper _mapper;
        public LessonService(ILessonRepository lessonRepository, IUnitofWork<ExamDbContext> unitofWork, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task Create(LessonViewModel vm)
        {
            var model = _mapper.Map<Lesson>(vm);
            await _lessonRepository.AddAsync(model);
            await _unitofWork.CommitAsync();
        }
        public async Task Update(LessonViewModel vm)
        {
            var dbModel = await _lessonRepository.SingleOrDefaultAsync(l => l.Code == vm.Code);
            dbModel.Name = vm.Name;
            dbModel.Class = vm.Class;
            dbModel.TeacherName = vm.TeacherName;
            dbModel.TeacherSurname = vm.TeacherName;
            _lessonRepository.Update(dbModel);
            await _unitofWork.CommitAsync();
        }
        public async Task Delete(string code)
        {
            var model = await _lessonRepository.SingleOrDefaultAsync(l => l.Code == code);
            _lessonRepository.Remove(model);
            await _unitofWork.CommitAsync();
        }
        public async Task<List<LessonViewModel>> GetAll()
            => _mapper.Map<List<LessonViewModel>>(await _lessonRepository.GetAllAsync());
        public async Task<LessonViewModel> GetByCode(string code)
            => _mapper.Map<LessonViewModel>(await _lessonRepository.SingleOrDefaultAsync(x => x.Code == code));
    }
}
