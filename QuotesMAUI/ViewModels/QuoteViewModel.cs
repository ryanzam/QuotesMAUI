using System.ComponentModel;

namespace QuotesMAUI.ViewModels
{
    public class QuoteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id == value) return;

                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        string _quotetext;
        public string QuoteText
        {
            get { return _quotetext; }
            set
            {
                if (_quotetext == value) return;

                _quotetext = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuoteText)));
            }
        }

        int _categoryId;
        public int CategoryId
        {
            get { return _categoryId; }
            set
            {
                if (_categoryId == value) return;

                _categoryId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CategoryId)));
            }
        }

        string _categoryName;
        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                if (_categoryName == value) return;

                _categoryName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CategoryName)));
            }
        }
    }
}
