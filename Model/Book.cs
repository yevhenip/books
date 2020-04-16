using System.ComponentModel;

namespace books.Model
{
    public class Book : INotifyPropertyChanged
    {
        private string _name;
        private string _author;
        private uint _pages;
        private double _price;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                RaisePropertyChanged("Author");
            }
        }

        public uint Pages
        {
            get => _pages;
            set
            {
                _pages = value;
                RaisePropertyChanged("Pages");
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                RaisePropertyChanged("Price");
            }
        }

        public Book()
        {
        }

        Book(string name, string author, uint pages, double price)
        {
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