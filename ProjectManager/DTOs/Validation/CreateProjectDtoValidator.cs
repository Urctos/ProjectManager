using FluentValidation;

namespace ProjectManager.DTOs.Validation
{
    public class CreateProjectDtoValidator : AbstractValidator<CreateProjectDto>
    {
        public CreateProjectDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(" Name must not empty.")
                .MinimumLength(3).WithMessage("Name must to have at last 3 signs")
                .MaximumLength(30).WithMessage("Name can't be lnger than 30 signs")
                .Matches(@"^[a-zA-Z0-9\s]+$").WithMessage("Name can't have special characters");

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("Description can't be lnger than 500 signs");
        }
    }
}
