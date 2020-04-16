using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using books.Annotations;
using books.Model;
using books.Utility;
using Newtonsoft.Json;

namespace books.ViewModel
{
    public sealed class BooksViewModel:INotifyPropertyChanged
    {
        private Book _selectedbook;
        private ObservableCollection<Book> _books;
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        
        public Book SelectedBook
        {
            get => _selectedbook;
            set
            {
                _selectedbook = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                RaisePropertyChanged();
            }
        }

        public void GetFromJson()
        {
            if (!File.Exists("source.json"))
            {
                File.WriteAllText("source.json", @"[]");
            }
            var jsn = File.ReadAllText("source.json");
            _books = JsonConvert.DeserializeObject<ObservableCollection<Book>>(jsn);
        }

        public BooksViewModel()
        {
            GetFromJson();
            LoadCommands();
        }

        private void LoadCommands()
        {
            AddCommand = new CustomCommand(AddBook, CanAddBook);
            RemoveCommand = new CustomCommand(RemoveBook, CanRemoveBook);
            SaveCommand = new CustomCommand(SaveBook, CanSaveBook);
        }

        private bool CanSaveBook(object obj)
        {
            return true;
        }

        private void SaveBook(object obj)
        {
            File.WriteAllText("source.json", JsonConvert.SerializeObject(Books, Formatting.Indented));
        }

        private bool CanRemoveBook(object obj)
        {
            return SelectedBook != null;
        }

        private void RemoveBook(object obj)
        {
            Books.Remove(SelectedBook);
        }

        private bool CanAddBook(object obj)
        {
            return true;
        }

        private void AddBook(object obj)
        {
            Books.Add(new Book());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}