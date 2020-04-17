namespace books.Model
{
    public class Book
    {
        private string _name;
        private string _author;
        private uint _pages;
        private double _price;
        public string Name
        { 
            get=>_name;
            set => _name = value;
        }

        public string Author
        {
            get=>_author;
            set => _author = value;
        }

        public uint Pages
        {
            get => _pages;
            set => _pages = value;
        }

        public double Price
        {
            get => _price;
            set => _price = value;
        }

        public Book()
        {
        }
        public Book(string name, string author, uint pages, double price)
        {
            Name = name;
            Author = author;
            Pages = pages;
            Price = price;
        }
    }
}