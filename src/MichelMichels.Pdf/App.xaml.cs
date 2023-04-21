using MichelMichels.Pdf.Services;
using System.Text;
using System.Windows;

namespace MichelMichels.Pdf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            MainWindow window = new()
            {
                DataContext = new MainViewModel(new PdfMerger()),
            };

            window.Show(); 
        }
    }
}
