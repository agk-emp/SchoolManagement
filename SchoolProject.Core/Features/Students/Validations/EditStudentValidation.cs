using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Validations
{
    public class EditStudentValidation : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;
        public EditStudentValidation(IStudentService studentService)
        {
            _studentService = studentService;
            EditStudentCommandRules();
            AddCustomValidation();
        }

        private void EditStudentCommandRules()
        {
            RuleFor(stud => stud.EditStudentCommandBody.Name).
               NotEmpty().WithMessage("{PropertyName can not be empty}").
               NotNull().WithMessage("{PropertyValue} can not be null").
               MaximumLength(20).WithMessage("Excedeed maximum length which is 20");

            RuleFor(stud => stud.EditStudentCommandBody.Address)
                .NotEmpty()
                .NotNull();
        }

        public void AddCustomValidation()
        {
            RuleFor(stud => stud.EditStudentCommandBody.Name)
                .MustAsync(async (model, key, CancellationToken) =>
                {
                    return !await _studentService
                    .DoesExistWithNameExcludeSelf(key, model.id);
                }).WithMessage("Name already exists");
        }
    }
}
