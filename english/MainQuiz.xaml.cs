using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Linq;

namespace english
{
    public partial class MainQuiz : ContentPage
    {
        private List<MainQuestion> _questions;
        private int _currentQuestionIndex;

        public MainQuiz()
        {
            InitializeComponent();

            _questions = new MainQuizViewModel().MainQuizQuestions;
            _currentQuestionIndex = 0;

            DisplayQuestion(_currentQuestionIndex);
            SelectRandomQuestions();
        }
        private void SelectRandomQuestions()
        {
            // Перемешиваем список вопросов
            var random = new Random();
            _questions = _questions.OrderBy(q => random.Next()).ToList();

            // Выбираем первые 7 вопросов
            _questions = _questions.Take(5).ToList();
        }

        private void DisplayQuestion(int index)
        {
            if (index >= 0 && index < _questions.Count)
            {
                var question = _questions[index];
                QuestionLabel.Text = question.Texts;

                // Clear previous answer buttons
                AnswersLayout.Children.Clear();

                // Add answer buttons
                foreach (var answer in question.MainAnswers)
                {
                    var button = new Button
                    {
                        Text = answer.Text,
                        CommandParameter = answer.IsCorrect,
                        Margin = new Thickness(0, 5, 0, 0)
                    };
                    button.Clicked += AnswerButton_Clicked;
                    AnswersLayout.Children.Add(button);
                }
            }
        }
        private async void AnswerButton_Clicked(object sender, System.EventArgs e)
        {
            var button = (Button)sender;
            bool isCorrect = (bool)button.CommandParameter;

            // Set the IsSelected property of the selected answer to true
            var selectedAnswer = _questions[_currentQuestionIndex].MainAnswers.FirstOrDefault(a => a.Text == button.Text);
            if (selectedAnswer != null)
            {
                selectedAnswer.IsSelected = true;
            }

            // Show result
            await DisplayResult(isCorrect);
        }


        private async Task DisplayResult(bool isCorrect)
        {
            string resultMessage = isCorrect ? "Correct!🥳" : "Incorrect😔";
            await DisplayAlert("", resultMessage, "Next");
            // Переход к следующему вопросу только после нажатия на кнопку "Next"
            MoveToNextQuestion();
        }

        private void MoveToNextQuestion()
        {
            _currentQuestionIndex++;
            if (_currentQuestionIndex < _questions.Count)
            {
                DisplayQuestion(_currentQuestionIndex);
            }
            else
            {
                // No more questions, quiz completed
                DisplayQuizCompletion();
            }
        }

        private void DisplayQuizCompletion()
        {
            int correctAnswersCount = 0;

            foreach (var question in _questions)
            {
                foreach (var answer in question.MainAnswers)
                {
                    if (answer.IsCorrect && answer.IsSelected)
                    {
                        correctAnswersCount++;
                        break; // Break the inner loop once a correct answer is found for the current question
                    }
                }
            }

            int percentage = (int)((double)correctAnswersCount / _questions.Count * 100);
            QuestionLabel.Text = $"Correct answers: {correctAnswersCount}/{_questions.Count} ({percentage}% )";
            AnswersLayout.Children.Clear();
            DatabaseManager.SaveMainQuizResult(percentage);
        }


    }
}
