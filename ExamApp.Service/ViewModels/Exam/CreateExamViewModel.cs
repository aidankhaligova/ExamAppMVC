using FluentValidation;

namespace ExamApp.Service.ViewModels.Exam
{
    public class CreateExamViewModel
    {
    //    public List<LessonViewModel> Lessons { get; set; }
    //    public List<StudentViewModel> Students { get; set; }
        public string LessonCode { get; set; }

        public short StudentNo { get; set; }

        public DateTime? ExamDate { get; set; }

        public bool? Grade { get; set; }
    }

    public class CreateExamViewModelValidator : AbstractValidator<CreateExamViewModel>
    {
        public CreateExamViewModelValidator()
        {
            RuleFor(x => x.LessonCode).MaximumLength(3).NotNull().NotEmpty();
            RuleFor(x => x.StudentNo).NotNull().NotEmpty();
        }
    }
}
