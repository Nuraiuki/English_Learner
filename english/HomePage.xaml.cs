using english;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace english
{
    public partial class HomePage : ContentPage
    {
        private QuizViewModel quizViewModel;

        public HomePage()
        {
            InitializeComponent();
            quizViewModel = new QuizViewModel();
        }

        private async void StartTestButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CountDown(quizViewModel));
        }
    }
}

// Начинаем обратный отсчет перед началом теста
//            await StartCountdown();
//        }

//        private async Task StartCountdown()
//        {
//            int countdownDurationSeconds = 3; // 3 секунды
//            while (countdownDurationSeconds > 0)
//            {
//                // Отображаем обратный отсчет
//                timerLabel.Text = $"{countdownDurationSeconds / 60:D2}:{countdownDurationSeconds % 60:D2}";
//                await Task.Delay(1000); // Ожидаем 1 секунду
//                countdownDurationSeconds--;
//            }

//            // По завершении обратного отсчета переходим на страницу теста
//            timerLabel.Text = "00:00";
//            await Navigation.PushAsync(new QuizPage(quizViewModel.QuizQuestions));
//        }
//    }
//}
