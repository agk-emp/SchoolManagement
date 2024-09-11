using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Validations
{
    public class AddStudentValidation : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        public AddStudentValidation(IStudentService studentService)
        {
            AddStudentCommandRules();
            AddCustomValidation();
            _studentService = studentService;
        }

        private void AddStudentCommandRules()
        {
            RuleFor(stud => stud.Name).
                NotEmpty().WithMessage("{PropertyName can not be empty}").
                NotNull().WithMessage("{PropertyValue} can not be null").
                MaximumLength(20).WithMessage("Excedeed maximum length which is 20");

            RuleFor(stud => stud.Address)
                .NotEmpty()
                .NotNull();
        }

        private void AddCustomValidation()
        {
            RuleFor(stud => stud.Name)
                .MustAsync(async (Key, CancellationToken) =>
                !await _studentService.DoesExistWithName(Key))
                .WithMessage("Name already exists");

        }
    }
}
