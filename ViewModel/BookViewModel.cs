using books.Model;

namespace books.ViewModel
{
    public class BookViewModel: BaseViewModel
    {
        private readonly Book _book;
        public string Name
        {
            get => _book.Name;
            set
            {
                _book.Name = value;
                RaisePropertyChanged();
            }
        }

        public string Author
        {
            get => _book.Author;
            set
            {
                _book.Author = value;
                RaisePropertyChanged();
            }
        }

        public uint Pages
        {
            get => _book.Pages;
            set
            {
                _book.Pages = value;
                RaisePropertyChanged();
            }
        }

        public double Price
        {
            get => _book.Price;
            set
            {
                _book.Price = value;
                RaisePropertyChanged();
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
    }
}