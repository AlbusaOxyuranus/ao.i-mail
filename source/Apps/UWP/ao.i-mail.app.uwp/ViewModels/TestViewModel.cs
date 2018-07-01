namespace ao.i_mail.app.uwp.ViewModels
{
    public class TestViewModel:ViewModelBase
    {
        private string _key;
        private string _value;

        public string Key
        {
            get => _key;
            set
            {
                if (value == _key) return;
                _key = value;
                OnPropertyChanged();
            }
        }

        public string Value
        {
            get => _value;
            set
            {
                if (value == _value) return;
                _value = value;
                OnPropertyChanged();
            }
        }
    }
}
