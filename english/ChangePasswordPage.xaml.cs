namespace english
{
    public partial class ChangePasswordPage : ContentPage
    {
        // Свойство для передачи текущего имени пользователя
        public string CurrentUsername { get; set; }

        public ChangePasswordPage()
        {
            InitializeComponent();
        }
        private async void OnOkButtonClicked(object sender, EventArgs e)
        {
            string oldPassword = oldPasswordEntry.Text;
            string username = usernameEntry.Text;
            string newPassword = newPasswordEntry.Text;

            // Вызываем метод смены пароля из DatabaseManager
            bool passwordChanged = DatabaseManager.ChangePassword(username, oldPassword, newPassword);

            if (passwordChanged)
            {
                await DisplayAlert("Success", "Password changed successfully", "OK");
                await Navigation.PopModalAsync(); // Закрыть текущую модальную страницу
            }
            else
            {
                await DisplayAlert("Error", "Failed to change password. Please check your old password and try again.", "OK");
            }

            usernameEntry.Text = string.Empty;
            oldPasswordEntry.Text = string.Empty;
            newPasswordEntry.Text = string.Empty;
        }

    }
}
