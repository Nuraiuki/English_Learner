using Microsoft.Maui.Controls;
using System;

namespace english
{
    public partial class ProfilePage : ContentPage
    {
        public string CurrentUsername { get; set; }

        public ProfilePage()
        {
            InitializeComponent();
        }

        private async void OnChangePasswordButtonClicked(object sender, EventArgs e)
        {
            var changePasswordPage = new ChangePasswordPage();
            changePasswordPage.CurrentUsername = CurrentUsername; 
            await Navigation.PushModalAsync(changePasswordPage);
        }

        private async void OnLogoutButtonClicked(object sender, EventArgs e)
        {

           
                var registrationPage = new RegistrationPage();

                await Navigation.PushAsync(registrationPage);
            
        }

        private void OnAttempts(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PreviousAttempts());
        }
    }
}
