using Microsoft.Maui.Controls;
using System;

namespace Testing
{
    public partial class MainPage : ContentPage
    {
        // A variable to keep track of the favorite status
        private bool isFavorited = false;

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event for the Favorite button.
        /// It toggles the heart icon and color to show if the pet is favorited.
        /// </summary>
        private void OnFavoriteClicked(object sender, EventArgs e)
        {
            // Toggle the boolean state
            isFavorited = !isFavorited;

            // 'sender' is the button that was clicked. We cast it to a Button type.
            if (sender is Button favoriteButton)
            {
                if (isFavorited)
                {
                    // Update appearance for 'Favorited' state
                    favoriteButton.Text = "❤️"; // Using a filled heart emoji
                    favoriteButton.BackgroundColor = Colors.Pink;
                    favoriteButton.TextColor = Colors.White;
                    favoriteButton.BorderColor = Colors.Transparent;
                }
                else
                {
                    // Update appearance for 'Not Favorited' state (the default)
                    favoriteButton.Text = "♡";
                    favoriteButton.BackgroundColor = Colors.White;
                    favoriteButton.TextColor = Colors.Gray;
                    favoriteButton.BorderColor = Colors.LightGray;
                }
            }
        }

        /// <summary>
        /// Handles the click event for the Adoption button.
        /// It shows a confirmation pop-up message to the user.
        /// The 'async' keyword is needed because DisplayAlert is an asynchronous operation.
        /// </summary>
        private async void OnAdoptionClicked(object sender, EventArgs e)
        {
            // Display a simple pop-up alert
            await DisplayAlert("Adoption Request", "Thank you for your interest in adopting Robin Hood! We will contact you shortly.", "OK");
        }
    }
}
