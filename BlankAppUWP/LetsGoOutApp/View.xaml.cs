using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LetsGoOutApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class View : Page
    {
        private Task<StorageFile> storageFolder;

        public View()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {

            try
            {
                string fileName = "imagefile.jpg";
                StorageFolder myfolder = ApplicationData.Current.LocalFolder;


                BitmapImage bitmapImage = new BitmapImage();


                StorageFile sampleFile = await storageFolder.GetFileAsync("text.txt");
                string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
                result.Text = text.ToString();
                StorageFile file = await myfolder.GetFileAsync(fileName);


                if (file != null)
                {
                    var image = await Windows.Storage.FileIO.ReadBufferAsync(file);


                    Uri uri = new Uri(file.Path);


                    BitmapImage img = new BitmapImage(new Uri(file.Path));


                    myimage.Source = img;
                }
                else {
                    var messgeDialog = new MessageDialog("Something went Wrong ");
                    messgeDialog.Commands.Add(new UICommand("Yes"));
                    messgeDialog.Commands.Add(new UICommand("No"));
                    messgeDialog.DefaultCommandIndex = 0;
                    messgeDialog.CancelCommandIndex = 1;
                    var result = await messgeDialog.ShowAsync();
                    if (result.Label.Equals("Yes")) { }
                }
            }
            catch (Exception ex)
            {
                var messgeDialog = new MessageDialog("Theres no image to view :( ");
                messgeDialog.Commands.Add(new UICommand("ok"));


                messgeDialog.DefaultCommandIndex = 0;
                messgeDialog.CancelCommandIndex = 1;
                var result = await messgeDialog.ShowAsync();
                if (result.Label.Equals("ok"))
                {
                    if (this.Frame.CanGoBack)
                    {
                        this.Frame.GoBack();


                    }
                }
            }
        }
    }
}
