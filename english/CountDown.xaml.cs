using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace english
{
    public partial class CountDown : ContentPage
    {
        private QuizViewModel quizViewModel;

        private readonly ProgressArc _progressArc;
        private DateTime _startTime;
        private readonly int _duration = 3;
        private double _progress;
        private CancellationTokenSource _cancellationTokenSource = new();

        public CountDown(QuizViewModel viewModel)
        {
            InitializeComponent();
            _progressArc = new ProgressArc();
            quizViewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ProgressButton.Text = "\uf144"; // Play icon - workaround because setting it in xaml broke the build for some reason
            ProgressButton.Text = $"{_duration}";

            ProgressView.Drawable = _progressArc;

            // Запускаем обратный отсчет при появлении страницы
            StartCountdown();
        }

        private void StartCountdown()
        {
            _startTime = DateTime.Now;
            _cancellationTokenSource = new CancellationTokenSource();
            UpdateArc();
        }

        // Handle button click events
        private void StartButton_OnClicked(object sender, EventArgs e)
        {
            StartCountdown();
        }
        private async void UpdateArc()
        {
            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                TimeSpan elapsedTime = DateTime.Now - _startTime;
                int secondsRemaining = (int)(_duration - elapsedTime.TotalSeconds);

                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    ProgressButton.Text = $"{secondsRemaining}"; // Обновляем текст кнопки
                });

                _progress = Math.Ceiling(elapsedTime.TotalSeconds);
                _progress %= _duration;
                _progressArc.Progress = _progress / _duration;
                ProgressView.Invalidate();

                if (secondsRemaining == 0)
                {
                    _cancellationTokenSource.Cancel();
                    await Navigation.PushAsync(new QuizPage(quizViewModel.QuizQuestions)); // Navigate to QuizPage
                    return;
                }

                await Task.Delay(1000); // Добавляем задержку на 1 секунду между обновлениями
            }
        }

        public class ProgressArc : IDrawable
        {
            public double Progress { get; set; } = 100;
            public void Draw(ICanvas canvas, RectF dirtyRect)
            {
                // Angle of the arc in degrees
                var endAngle = 90 - (int)Math.Round(Progress * 360, MidpointRounding.AwayFromZero);
                // Drawing code goes here
                // canvas.StrokeColor = Color.FromRgba("6599ff");
                canvas.StrokeColor = Color.FromRgba("6599ff");
                canvas.StrokeSize = 4;
                Debug.WriteLine($"The rect width is {dirtyRect.Width} and height is {dirtyRect.Height}");
                canvas.DrawArc(5, 5, (dirtyRect.Width - 10), (dirtyRect.Height - 10), 90, endAngle, false, false);
            }
        }
    }
}
