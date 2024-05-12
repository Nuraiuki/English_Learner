using Microsoft.Maui.Controls;

namespace english
{
    public partial class LogoutPage : ContentPage
    {
        private int userId;
        private RegistrationPage registrationPage; // Поле для хранения ссылки на страницу регистрации

        public LogoutPage(int userId, RegistrationPage registrationPage)
        {
            InitializeComponent();
            this.userId = userId;
            this.registrationPage = registrationPage; // Сохраняем ссылку на страницу регистрации
        }

       
    }
}
