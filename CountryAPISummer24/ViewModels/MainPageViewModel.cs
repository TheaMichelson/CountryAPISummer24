using System.Windows.Input;
using CountryAPISummer24.Views;

namespace CountryAPISummer24.ViewModels
{
    public class MainPageViewModel : BasePageViewModel
    {
        public ICommand NavigateToCountryListCommand { get; }
        public ICommand NavigateToCountrySearchCommand { get; }
        public ICommand NavigateToWordListCommand { get; }

        public MainPageViewModel()
        {
            Title = "Country Explorer";

            NavigateToCountryListCommand = new Command(async () => await NavigateToCountryList());
            NavigateToWordListCommand = new Command(async () => await NavigateToWordList());
            NavigateToCountrySearchCommand = new Command(async () => await NavigateToCountrySearch());
        }

        private async Task NavigateToWordList()
        {
            await Shell.Current.GoToAsync(nameof(WordsListPage));
        }

        private async Task NavigateToCountryList()
        {
            await Shell.Current.GoToAsync(nameof(CountryListPage));
        }

        private async Task NavigateToCountrySearch()
        {
            // You can implement this method later when you create a CountrySearchPage
            await Shell.Current.DisplayAlert("Coming Soon", "Country search feature is coming soon!", "OK");
        }
    }
}