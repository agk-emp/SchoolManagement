﻿using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Validations
{
    public class AddStudentValidation : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public AddStudentValidation(IStudentService studentService, IStringLocalizer<SharedResources> localizer)
        {
            _studentService = studentService;
            _localizer = localizer;
            AddStudentCommandRules();
            AddCustomValidation();
        }


        private void AddStudentCommandRules()
        {
            RuleFor(stud => stud.NameEn).
                NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.PropertyName]]).
            NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.PropertyName]]).
            MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLength, SharedResourcesKeys.StudentNameMaxLength]);


            RuleFor(stud => stud.NameAr).
                NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.PropertyName]]).
            NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.PropertyName]]).
            MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.MaxLength, SharedResourcesKeys.StudentNameMaxLength]);

            RuleFor(stud => stud.Address)
                .NotEmpty()
                .NotNull();
        }

        private void AddCustomValidation()
        {
            RuleFor(stud => stud.NameAr)
                .MustAsync(async (Key, CancellationToken) =>
                !await _studentService.DoesExistWithName(Key))
                .WithMessage(_localizer[SharedResourcesKeys.AlreadyExists, _localizer[SharedResourcesKeys.PropertyValue]]);

            RuleFor(stud => stud.NameEn)
                .MustAsync(async (Key, CancellationToken) =>
                !await _studentService.DoesExistWithName(Key))
                .WithMessage(_localizer[SharedResourcesKeys.AlreadyExists, _localizer[SharedResourcesKeys.PropertyValue]]);
        }
    }
}
