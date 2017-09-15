using FluentValidation;
using FluentValidationDemo.ViewModels;

namespace FluentValidationDemo.Validators
{
    public class InputFormValidator : AbstractValidator<MainPageViewModel>
    {
        public InputFormValidator()
        {
            RuleFor(vm => vm.Email).NotEmpty().WithMessage("Email shouldn't be empty.");
            RuleFor(vm => vm.Email).EmailAddress().WithMessage("Email is not valid.");
            RuleFor(vm => vm.Password).NotEmpty().WithMessage("Password shouldn't be empty.");
            RuleFor(vm => vm.Password).Must(p => !string.IsNullOrWhiteSpace(p) && p.Length >= 6).WithMessage("Password must be at least 6 characters");
            RuleFor(vm => vm.ConfirmPassword).NotEmpty().WithMessage("Confirm password shouldn't be empty.");
            RuleFor(vm => vm.ConfirmPassword).Equal(vm => vm.Password).WithMessage("Password does not match the confirm password");
        }
    }
}
