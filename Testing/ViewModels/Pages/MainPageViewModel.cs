using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Testing.ViewModels.Pages
{
    // Lightweight base implementing INotifyPropertyChanged
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool Set<T>(ref T storage, T value, [CallerMemberName] string name = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            return true;
        }
        protected void Raise([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class MainPageViewModel : BindableBase
    {
        private Models.Pet _pet = new();
        private bool _isFavorite;
        private string _adoptionText = "Adoption";

        public MainPageViewModel()
        {
            ToggleFavoriteCommand = new Command(() =>
            {
                // Toggle favorite state
                IsFavorite = !IsFavorite;
                // Update UI-related properties
                Raise(nameof(FavoriteIcon));
                Raise(nameof(FavoriteBackground));
                Raise(nameof(FavoriteTextColor));
                Raise(nameof(FavoriteBorderColor));
            });

            AdoptCommand = new Command(async () =>
            {
                // Use Shell to show alert from ViewModel (no Page reference needed)
                await (Shell.Current?.DisplayAlert(
                    "Adoption Request",
                    "Thank you for your interest in adopting Robin Hood! We will contact you shortly.",
                    "OK") ?? Task.CompletedTask);

                AdoptionText = "Requested ✔";
            });
        }

        // Expose the model to XAML
        public Models.Pet Pet
        {
            get => _pet;
            set => Set(ref _pet, value);
        }

        // Favorite state & derived UI properties
        public bool IsFavorite
        {
            get => _isFavorite;
            set
            {
                if (Set(ref _isFavorite, value))
                {
                    Raise(nameof(FavoriteIcon));
                    Raise(nameof(FavoriteBackground));
                    Raise(nameof(FavoriteTextColor));
                    Raise(nameof(FavoriteBorderColor));
                }
            }
        }

        public string FavoriteIcon => IsFavorite ? "❤️" : "♡";
        public Color FavoriteBackground => IsFavorite ? Colors.Pink : Colors.White;
        public Color FavoriteTextColor => IsFavorite ? Colors.White : Colors.Gray;
        public Color FavoriteBorderColor => IsFavorite ? Colors.Transparent : Colors.LightGray;

        // Adoption button text
        public string AdoptionText
        {
            get => _adoptionText;
            set => Set(ref _adoptionText, value);
        }

        // Commands bound from XAML
        public ICommand ToggleFavoriteCommand { get; }
        public ICommand AdoptCommand { get; }
    }
}