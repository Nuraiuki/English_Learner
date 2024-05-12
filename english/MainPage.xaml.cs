using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace english
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private int GetCurrentUserId()
        {
            return 1;
        }

        private async void ViewWordsButton_Clicked(object sender, EventArgs e)
        {
            int userId = GetCurrentUserId();

            List<PhrasalVerb> incompletePhrasalVerbs = DatabaseManager.GetIncompletePhrasalVerbsForUser(userId);

            UserPhrasalVerbProgressPage progressPage = new UserPhrasalVerbProgressPage(incompletePhrasalVerbs);

            await Navigation.PushAsync(progressPage);
        }
        private void VideoButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VideoPage());


        }


        private void LibraryButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Library());


        }

        private void MainButton_Clicked(object sender, EventArgs e)
        {

        }

        private void ProfileButton_Clicked(object sender, EventArgs e)
        {
      

            Navigation.PushAsync(new ProfilePage());
        }




        private async void ComePage_Clicked(object sender, EventArgs e)
        {
            // Выполнить навигацию на страницу Cards
            await Navigation.PushAsync(new ComePage());
        }

        private async void GoPage_Clicked(object sender, EventArgs e)
        {
            // Выполнить навигацию на страницу Cards
            await Navigation.PushAsync(new GoPage());
        }


        private async void take_Clicked(object sender, EventArgs e)
        {
            // Выполнить навигацию на страницу Cards
            await Navigation.PushAsync(new TakePage());
        }

        private async void look_Clicked(object sender, EventArgs e)
        {
            // Выполнить навигацию на страницу Cards
            await Navigation.PushAsync(new LookPage());
        }

        private async void put_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new PutPage());

        }


        void Main_Test(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MainQuiz());

        }



    }
}
//using System.Collections.Generic;
//using System.IO;
//using System.Threading.Tasks;
//using Microsoft.Maui;
//using Microsoft.Maui.Controls;
//using Microsoft.Maui.Controls.Compatibility;

//namespace eng
//{
//    public partial class MainPage : ContentPage
//    {

//        //private List<string> GetImagePathsFromDatabase()
//        //{
//        //    List<string> imagePaths = new List<string>();

//        //    // Your database logic to fetch image paths...

//        //    return imagePaths;
//        //}

//        private int GetCurrentUserId()
//        {
//            return 1; // Example: return the user ID
//        }


//        private async void ViewWordsButton_Clicked(object sender, EventArgs e)
//        {
//            // Get the current user ID
//            int userId = GetCurrentUserId();

//            // Get incomplete phrasal verbs for the current user from the database
//            List<PhrasalVerb> incompletePhrasalVerbs = DatabaseManager.GetIncompletePhrasalVerbsForUser(userId);

//            // Create a new page and pass the data of incomplete phrasal verbs
//            UserPhrasalVerbProgressPage progressPage = new UserPhrasalVerbProgressPage(incompletePhrasalVerbs);

//            // Display the new page
//            await Navigation.PushAsync(progressPage);
//        }



//        private void LibraryButton_Clicked(object sender, EventArgs e)
//        {


//        }

//        private void SettingsButton_Clicked(object sender, EventArgs e)
//        {
//            // Обработчик события для кнопки "Настройки"
//            // Ваш код здесь
//        }

//        private void ProfileButton_Clicked(object sender, EventArgs e)
//        {
//            Navigation.PushAsync(new ProfilePage());
//        }



//            private async void Button1_Clicked(object sender, EventArgs e)
//            {
//                // Выполнить навигацию на страницу Cards
//                await Navigation.PushAsync(new ComePage());
//            }

//        private async void Button2_Clicked(object sender, EventArgs e)
//        {
//            // Выполнить навигацию на страницу Cards
//            await Navigation.PushAsync(new GoPage());
//        }

//        void Main_Test(System.Object sender, System.EventArgs e)
//        {
//             Navigation.PushAsync(new MainQuiz());

//        }


//        //private async Task LoadImagesFromDatabaseAsync()
//        //{
//        //    // Get image paths from the database
//        //    List<string> imagePaths = GetImagePathsFromDatabase();

//        //    // Load and display images asynchronously
//        //    await LoadAndDisplayImagesAsync(imagePaths, stackLayout);
//        //}

//        //private async Task LoadAndDisplayImagesAsync(List<string> imagePaths, Microsoft.Maui.Controls.StackLayout stackLayout)
//        //{
//        //    foreach (string path in imagePaths)
//        //    {
//        //        // Create an image from the path
//        //        Image image = new Image
//        //        {
//        //            Source = ImageSource.FromFile(path),
//        //            WidthRequest = 200,
//        //            HeightRequest = 200,
//        //            Aspect = Aspect.AspectFit
//        //        };

//        //        // Add the image to the provided stack layout
//        //        stackLayout.Children.Add(image);
//        //    }
//        //}
//    }
//}