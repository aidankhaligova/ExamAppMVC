using FluentValidation;

namespace ExamApp.Service.ViewModels.Student
{
    public class StudentViewModel
    {
        public short No { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public byte? Class { get; set; }
    }

    public class StudentViewModelValidator : AbstractValidator<StudentViewModel> 
    {
        public StudentViewModelValidator()
        {
            RuleFor(x=>x.No).NotNull().NotEmpty();
            RuleFor(x=>x.Name).MaximumLength(30);
            RuleFor(x=>x.Surname).MaximumLength(30);
            RuleFor(x => x).Custom((model, context) =>
            {
                if (model.Class <= 0)
                {
                    context.AddFailure(nameof(model.Class), "Class cannot be equal to or less than zero.");
                }
            }
            );
        }
    }
}
