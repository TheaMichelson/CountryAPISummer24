using CountryAPISummer24.ViewModels;

namespace CountryAPISummer24.Views;

public partial class WordsListPage : ContentPage
{
    private WordsListViewModel _viewModel;

    public WordsListPage(WordsListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync(null);
    }
}