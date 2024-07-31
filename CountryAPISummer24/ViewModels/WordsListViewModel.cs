using CountryAPISummer24.Models;
using CountryAPISummer24.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CountryAPISummer24.ViewModels
{
    public class WordsListViewModel : BasePageViewModel
    {
        private readonly IWordService _wordService;
        private List<Words> _words;
        private Words _selectedWord;
        private string _searchText;

        public List<Words> Words
        {
            get => _words;
            set => SetProperty(ref _words, value);
        }
        public Words SelectedWord
        {
            get => _selectedWord;
            set => SetProperty(ref _selectedWord, value);
        }

        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        public ICommand SearchCommand { get; }
        public ICommand DetailsCommand { get; }
        public ICommand RefreshCommand { get; }

        public WordsListViewModel(IWordService wordService)
        {
            _wordService = wordService;
            Title = "Word List";

            SearchCommand = new Command(PerformSearch);
            DetailsCommand = new Command(ShowDetails, () => SelectedWord != null);
            RefreshCommand = new Command(async () => await LoadWordsAsync());
        }

        private void PerformSearch()
        {
            // Implement search logic
        }

        private void ShowDetails()
        {
            // Implement navigation to details page
        }

        public async Task LoadWordsAsync()
        {
            await ExecuteAsync(async () =>
            {
                Words = await _wordService.GetWordsAsync();
            });
        }

        public override async Task InitializeAsync(object parameter)
        {
            await LoadWordsAsync();
        }
    }
}
