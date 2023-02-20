using FluentValidation;

namespace ExamApp.Service.ViewModels.Exam
{
    public class ExamViewModel
    {
        public string LessonCode { get; set; }
        public string LessonName { get; set; }

        public short StudentNo { get; set; }
        public string StudentFullname { get; set; }

        public DateTime? ExamDate { get; set; }

        public bool? Grade { get; set; }

        public int Id { get; set; }
    }

    public class ExamViewModelValidator : AbstractValidator<ExamViewModel>
    {
        public ExamViewModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(x => x.LessonCode).MaximumLength(3).NotNull().NotEmpty();
            RuleFor(x => x.StudentNo).NotNull().NotEmpty();
        }
    }
}
