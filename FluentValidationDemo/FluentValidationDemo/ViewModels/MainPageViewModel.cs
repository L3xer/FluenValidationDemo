using Prism.Mvvm;
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

        private InputFormValidator _validator;

        public MainPageViewModel(InputFormValidator validator)
        {
            _validator = validator;
        }
    }
}
