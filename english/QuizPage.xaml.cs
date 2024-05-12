using System;
using System.Collections.Generic;
using System.Linq;

namespace english
{
    public partial class QuizPage : ContentPage
    {
        private int timeLeftInSeconds = 120; // 3 минуты * 60 секунд

        private List<Question> questions;
        private List<Question> selectedQuestions;
        private int currentQuestionIndex = 0;
        private int correctAnswers = 0;
        private int incorrectAnswers = 0;
        private bool quizFinished = false;


        public QuizPage(List<Question> quizQuestions)
        {
            InitializeComponent();
            StartTimer();

            Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false }); // Скрываем кнопку назад

            questions = quizQuestions;
            SelectRandomQuestions();
            LoadQuestion();

        }
        private void SelectRandomQuestions()
        {
            // Перемешиваем список вопросов
            var random = new Random();
            questions = questions.OrderBy(q => random.Next()).ToList();

            // Выбираем первые 7 вопросов
            selectedQuestions = questions.Take(7).ToList();
        }

        private void LoadQuestion()
        {
            var currentQuestion = selectedQuestions[currentQuestionIndex];
            questionLabel.Text = currentQuestion.Text;

            answersLayout.Children.Clear();
            foreach (var answer in currentQuestion.Answers)
            {
                var answerButton = new Button
                {
                    Text = answer.Text,
                    HorizontalOptions = LayoutOptions.Center
                };
                answerButton.Clicked += (sender, e) => CheckAnswer(answer.IsCorrect);
                answersLayout.Children.Add(answerButton);
            }
        }

        private void CheckAnswer(bool isCorrect)
        {
            if (isCorrect)
            {
                correctAnswers++;
            }
            else
            {
                incorrectAnswers++;
            }

            // Переход к следующему вопросу
            currentQuestionIndex++;
            if (currentQuestionIndex < selectedQuestions.Count)
            {
                LoadQuestion();
            }
            else
            {
                ShowResults();
            }
        }
        private async void StartTimer()
        {
            while (timeLeftInSeconds > 0 && !quizFinished)
            {
                // Обновляем значение Label с отсчетом времени
                timerLabell.Text = TimeSpan.FromSeconds(timeLeftInSeconds).ToString(@"mm\:ss");

                // Ждем 1 секунду
                await Task.Delay(1000);

                // Уменьшаем время на 1 секунду
                timeLeftInSeconds--;
            }

            if (!quizFinished)
            {
                // По истечении времени вызываем метод для завершения теста
                FinishQuiz();
            }
        }


        private void FinishQuiz()
        {
            quizFinished = true;
            // Вызываем метод для отображения результатов
            ShowResults();
        }

        private async void ShowResults()
        {
            // Pass the correct arguments to the QuizResult constructor
            await Navigation.PushAsync(new QuizResult(correctAnswers, incorrectAnswers));

            // You don't need to pass the username here unless it's a required parameter for QuizResult's constructor.
        }
    }
}