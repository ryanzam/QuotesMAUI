using System.ComponentModel;

namespace QuotesMAUI.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
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
