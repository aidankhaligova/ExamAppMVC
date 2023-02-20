using FluentValidation;

namespace ExamApp.Service.ViewModels.Lesson
{
    public class LessonViewModel
    {
        public string Code { get; set; }

        public string? Name { get; set; }

        public byte? Class { get; set; }

        public string? TeacherName { get; set; }

        public string? TeacherSurname { get; set; }
    }

    public class LessonViewModelValidator : AbstractValidator<LessonViewModel>
    {
        public LessonViewModelValidator()
        {
            RuleFor(x => x.Code).MaximumLength(3).NotNull().NotEmpty();
            RuleFor(x => x.Name).MaximumLength(30);
            RuleFor(x => x).Custom((model, context) =>
            {
                if (model.Class <= 0)
                {
                    context.AddFailure(nameof(model.Class), "Class cannot be equal to or less than zero.");
                }
            }
            );
            RuleFor(x => x.TeacherName).MaximumLength(20);
            RuleFor(x => x.TeacherSurname).MaximumLength(20);
        }
    }
}
