using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;

namespace SchoolProject.Core.Features.Students.Validations
{
    public class AddStudentValidation : AbstractValidator<AddStudentCommand>
    {
        public AddStudentValidation()
        {
            AddStudentCommandRules();
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
    }
}
