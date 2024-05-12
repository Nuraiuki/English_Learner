using Microsoft.Maui.Controls;

namespace english
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;
            string repeatPassword = repeatPasswordEntry.Text;
            string email = emailEntry.Text;

            if (password != repeatPassword)
            {
                DisplayAlert("Error", "Passwords do not match", "OK");
                return;
            }
            else if (!DatabaseManager.IsValidEmail(email))
            {
                DisplayAlert("Error", "Invalid email address", "OK");
                return;
            }

            bool success = DatabaseManager.RegisterUser(username, password, email);

            if (success)
            {
                DisplayAlert("Success", "Registration successful", "OK");
                Navigation.PushAsync(new HomePage());
            }
            else
            {
                DisplayAlert("Error", "Registration failed", "OK");
            }
        }
    
        void OnLoginButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}
