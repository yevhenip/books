using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using books.Utility;
using Newtonsoft.Json;

namespace books.ViewModel
{
    public class BooksViewModel : BaseViewModel
    {
        private BookViewModel _selectedbook;
        private ObservableCollection<BookViewModel> _books;
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public BookViewModel SelectedBook
        {
            get => _selectedbook;
            set
            {
                _selectedbook = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<BookViewModel> Books
        {
            get => _books;
            set
            {
                _books = value;
                RaisePropertyChanged();
            }
        }

        private void GetBooks()
        {
            if (!File.Exists("source.json"))
            {
                File.WriteAllText("source.json", @"[]");
            }

            var jsn = File.ReadAllText("source.json");
            _books = JsonConvert.DeserializeObject<ObservableCollection<BookViewModel>>(jsn);
        }

        public BooksViewModel()
        {
            GetBooks();
            LoadCommands();
        }

        private void LoadCommands()
        {
            AddCommand = new CustomCommand(obj => _books.Add(new BookViewModel()), obj => true);
            RemoveCommand = new CustomCommand(obj => _books.Remove(SelectedBook), obj => SelectedBook != null);
            SaveCommand =
                new CustomCommand(
                    obj => File.WriteAllText("source.json", JsonConvert.SerializeObject(_books, Formatting.Indented)),
                    obj => true);
        }
    }
}