using System;
using Prism.Mvvm;
using Prism.Commands;
using Prism.Services;
using FluentValidationDemo.Validators;
namespace FluentValidationDemo.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { SetProperty(ref _confirmPassword, value); }
        }

        private IPageDialogService _pageDialogService;
        private InputFormValidator _validator;

        public DelegateCommand SendCommand { get; set; }

        public MainPageViewModel(IPageDialogService pageDialogService, InputFormValidator validator)
        {
            _pageDialogService = pageDialogService;
            _validator = validator;

            SendCommand = new DelegateCommand(SendExecute);
        }

        private async void SendExecute()
        {
            var validationResult = await _validator.ValidateAsync(this);

            string message = validationResult.IsValid ? "Success!" : string.Join(Environment.NewLine, validationResult.Errors);

            await _pageDialogService.DisplayAlertAsync("Fluent Validation Demo", message, "Close");
        }
    }
}
