using System.ComponentModel;
using books.Model;

namespace books.ViewModel
{
    public class BookViewModel:INotifyPropertyChanged
    {
        private Book _book;
        public string Name
        {
            get => _book.Name;
            set
            {
                _book.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Author
        {
            get => _book.Author;
            set
            {
                _book.Author = value;
                RaisePropertyChanged("Author");
            }
        }

        public uint Pages
        {
            get => _book.Pages;
            set
            {
                _book.Pages = value;
                RaisePropertyChanged("Pages");
            }
        }

        public double Price
        {
            get => _book.Price;
            set
            {
                _book.Price = value;
                RaisePropertyChanged("Price");
            }
        }

        public BookViewModel()
        {
            _book = new Book();
        }

        public BookViewModel(Book book)
        {
            _book = new Book(book.Name, book.Author, book.Pages, book.Price);
        }
        
        public BookViewModel(string name, string author, uint pages, double price)
        {
            _book = new Book();
            Name = name;
            Author = author;
            Pages = pages;
            Price = price;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}