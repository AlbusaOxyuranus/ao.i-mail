using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ao.i_mail.app.uwp.i_MailService;
using ao.i_mail.app.uwp.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ao.i_mail.app.uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = new TestViewModel();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var client = new MailServiceClient();
            var config = new Config() { Key = (DataContext as TestViewModel).Key, Value = (DataContext as TestViewModel).Value};
            var resultConfig = client.CreateConfigAsync(new User(){Id = 1}, config);
        }
    }
}
