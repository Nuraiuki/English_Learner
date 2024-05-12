
namespace english;

public partial class LookPage : ContentPage
{
    public LookPage()
    {

        InitializeComponent();

        // Получаем список фразовых глаголов, начинающихся на "go", из базы данных
        List<PhrasalVerb> lookPhrasalVerbs = DatabaseManager.GetPhrasalVerbsStartingWithFromDatabase("look");

        // Привязываем список к CarouselView
        lookCarousel.ItemsSource = lookPhrasalVerbs;
    }

    private async void LearnButton_Clicked(object sender, EventArgs e)
    {
        // Получаем выбранный фразовый глагол из карусели
        PhrasalVerb selectedVerb = lookCarousel.CurrentItem as PhrasalVerb;

        if (selectedVerb != null)
        {
            // Получаем текущего пользователя (например, из системы аутентификации)
            int userId = GetCurrentUserId();

            bool progressExists = DatabaseManager.IsPhrasalVerbProgressExists(userId, selectedVerb.PhrasalVerbID);

            // Если запись уже существует
            if (progressExists)
            {
                // Вызываем асинхронный метод DisplayAlert для подтверждения удаления из словаря
                bool answer = await DisplayAlert("Уже изучено", "Хотите удалить из словаря?", "Да", "Нет");

                // Если пользователь выбрал "Да"
                if (answer)
                {
                    // Удаляем прогресс изучения выбранного глагола из базы данных
                    DatabaseManager.DeletePhrasalVerbProgress(userId, selectedVerb.PhrasalVerbID);

                    // Выводим сообщение об удалении
                    await DisplayAlert("Удалено", "Глагол удален из словаря", "OK");

                    // Возвращаемся из метода
                    return;
                }
                else
                {
                    // Пользователь отказался от удаления, поэтому просто выходим из метода
                    return;
                }
            }
            else
            {


                // Вызываем асинхронный метод DisplayAlert и ожидаем его завершения
                await DisplayAlert("Добавлено", "Глагол добавлен для изучения!", "OK");
            }

            // Сохраняем прогресс изучения выбранного глагола в базе данных
            SavePhrasalVerbProgress(userId, selectedVerb.PhrasalVerbID);

            // Изменяем текст кнопки на "Изучаю"
            ((Button)sender).Text = "Изучаю";

            // Создаем экземпляр объекта Color и устанавливаем зеленый цвет
            Microsoft.Maui.Graphics.Color greenColor = Microsoft.Maui.Graphics.Color.FromRgb(0, 255, 0);

            // Изменяем цвет кнопки
            ((Button)sender).BackgroundColor = greenColor;
        }
    }


    private int GetCurrentUserId()
    {
        // Ваша реализация получения ID текущего пользователя
        // Возвращаем ID текущего пользователя (может быть из системы аутентификации или сессии)
        return 1; // Пример
    }

    private void SavePhrasalVerbProgress(int userId, int PhrasalVerbID)
    {
        // Здесь нужно выполнить сохранение прогресса изучения фразового глагола в базе данных
        // Например, с помощью метода в вашем классе DatabaseManager
        DatabaseManager.SaveUserPhrasalVerbProgress(userId, PhrasalVerbID);
    }
}

