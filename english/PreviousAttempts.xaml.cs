namespace english;

public partial class PreviousAttempts : ContentPage
{
    public PreviousAttempts()
    {
        InitializeComponent();

        // Здесь вы можете выполнить запрос к базе данных и получить данные о предыдущих попытках пользователя
        List<MainQuizResult> previousAttempts = DatabaseManager.GetPreviousAttemptsByUserID(1); // Здесь 1 - это ID пользователя, для которого нужно получить попытки

        // Привязываем полученные данные к ListView
        previousAttemptsListView.ItemsSource = previousAttempts;
    }
}

public class MainQuizResult
{
    public int Results { get; set; }
    public DateTime Timedate { get; set; }
}