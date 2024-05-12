using Microsoft.Maui.Controls;

namespace english
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if (DatabaseManager.AuthenticateUser(username, password))
            {
                Navigation.PushAsync(new MainPage());
                DisplayAlert("Success", "Login successful", "OK");
            }
            else
            {
                DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }

        void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage());
        }
    }
}
