using FluentValidation;
using TASKManager.Domain.Entities;

namespace TASKManager.Domain.Validators
{
    public class TaskValidator : AbstractValidator<Task>
    {
        public TaskValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("The title cannot be empty.")
                .NotNull().WithMessage("The title cannot be null.")
                .MaximumLength(30).WithMessage("The maximum length of title is 30.");

            RuleFor(x => x.Descripton)
                .MaximumLength(250).WithMessage("The maximum length of description is 250.");
        }
    }
}
