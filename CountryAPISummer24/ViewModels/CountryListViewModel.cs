using System.Windows.Input;
using CountryAPISummer24.Models;
using CountryAPISummer24.Services;

namespace CountryAPISummer24.ViewModels
{
    public class CountryListViewModel : BasePageViewModel
    {
        private readonly ICountryService _countryService;
        private List<Country> _countries;
        private Country _selectedCountry;
        private string _searchText;

        public List<Country> Countries
        {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }
        public Country SelectedCountry
        {
            get => _selectedCountry;
            set => SetProperty(ref _selectedCountry, value);
        }

        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        public ICommand SearchCommand { get; }
        public ICommand DetailsCommand { get; }
        public ICommand RefreshCommand { get; }

        public CountryListViewModel(ICountryService countryService)
        {
            _countryService = countryService;
            Title = "Country List";

            SearchCommand = new Command(PerformSearch);
            DetailsCommand = new Command(ShowDetails, () => SelectedCountry != null);
            RefreshCommand = new Command(async () => await LoadCountriesAsync());
        }

        private void PerformSearch()
        {
            // Implement search logic
        }

        private void ShowDetails()
        {
            // Implement navigation to details page
        }

        public async Task LoadCountriesAsync()
        {
            await ExecuteAsync(async () =>
            {
                Countries = await _countryService.GetCountriesAsync();
            });
        }

        public override async Task InitializeAsync(object parameter)
        {
            await LoadCountriesAsync();
        }
    }
}
