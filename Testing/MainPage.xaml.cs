using Testing.ViewModels.Pages; 

namespace Testing
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(); // now it will find it
        }
    }
}
