namespace english
{
    public partial class QuizResult : ContentPage
    {
        public QuizResult(int correctAnswers, int incorrectAnswers)
        {
            InitializeComponent();
            int currentUserId = GetCurrentUserId(); // Получаем идентификатор текущего пользователя
            BindingContext = new QuizResultViewModel(correctAnswers, incorrectAnswers, currentUserId);
        }

        void Main_Page(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        // Метод для получения идентификатора текущего пользователя
        private int GetCurrentUserId()
        {
            return 1; // Пример возврата идентификатора пользователя
        }
    }

    public class QuizResultViewModel
    {
        public string CorrectAnswersText { get; }
        public string IncorrectAnswersText { get; }
        public string TotalQuestionsText { get; }
        public string PercentageText { get; }
        public string LevelText { get; }
        public double LevelProgress { get; }


        public QuizResultViewModel(int correctAnswers, int incorrectAnswers, int currentUserId)
        {
            int totalQuestions = correctAnswers + incorrectAnswers;
            double percentage = (double)correctAnswers / totalQuestions * 100;
            string formattedPercentage = $"{percentage:F1}";

            CorrectAnswersText = $"Correct Answers: {correctAnswers}";
            IncorrectAnswersText = $"InCorrect Answers: {incorrectAnswers}";
            TotalQuestionsText = $"Total Questions: {totalQuestions}";
            PercentageText = $"Percentage: {formattedPercentage}%";

            // Определяем уровень на основе процента правильных ответов
            string level;
            if (percentage < 30)
            {
                level = "BEGINNER";
                LevelProgress = 0.3;
            }
            else if (percentage < 70)
            {
                level = "ELEMENTRY";
                LevelProgress = 0.5; // Для элементарных 50%

            }
            else
            {
                level = "PRE-INTERMEDIATE";
                LevelProgress = 0.8; // Для предварительных 80%

            }

            // Сохраняем значения в поля класса
            LevelText = level;

            // Передаем данные в метод сохранения результатов
            decimal percentageDecimal = new decimal(percentage); // Создание нового значения типа decimal

            DatabaseManager.SaveQuizResult(currentUserId, correctAnswers, incorrectAnswers, totalQuestions, percentageDecimal, level);
        }
    }
}