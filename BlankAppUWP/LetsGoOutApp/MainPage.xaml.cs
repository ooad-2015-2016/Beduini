using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Media.Capture;
using Windows.Media.Devices;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using ZXing;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LetsGoOutApp
{



    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MediaCapture mediaCapture;
        private byte[] imageBuffer;
        public int exit = 0;
        private MessageDialog dialog;
        private ApplicationView currentView = ApplicationView.GetForCurrentView();

        public object MyImage { get; private set; }

        public MainPage()
        {
            this.InitializeComponent();
        }

protected override void OnNavigatedTo(NavigationEventArgs e)  
{  
   exit = 0;  
   ScanQrCode();

    }  

private async void ScanQrCode() {  
    try {  
        await InitializeQrCode();  
  
  
        var imgProp = new ImageEncodingProperties {  
            Subtype = "BMP", Width = 380, Height = 380  
        };  
        var bcReader = new BarcodeReader();  
  
  
        while (exit == 0) {  
            var stream = new InMemoryRandomAccessStream();  
            await mediaCapture.CapturePhotoToStreamAsync(imgProp, stream);  
  
  
            stream.Seek(0);  
            var wbm = new WriteableBitmap(380, 380);  
            await wbm.SetSourceAsync(stream);  
            var result = bcReader.Decode(wbm);  
  
  
            if (result != null) {  
                var torch = mediaCapture.VideoDeviceController.TorchControl;  
                if (torch.Supported) torch.Enabled = false;  
                await mediaCapture.StopPreviewAsync();  
                var msgbox = new MessageDialog(result.Text);  
                await msgbox.ShowAsync();  
  
  
                try {  
                    StorageFolder folder = ApplicationData.Current.LocalFolder;  
                    if (folder != null) {  
                        //Spasi Scan Text  
                        StorageFile sampleFile = await folder.CreateFileAsync("sample.txt", CreationCollisionOption.ReplaceExisting);  
                        await Windows.Storage.FileIO.WriteTextAsync(sampleFile, "Swift as a shadow");  
  
                        //Spasi Scan Image  
  
                        StorageFile file = await folder.CreateFileAsync("imagefile" + ".jpg", CreationCollisionOption.ReplaceExisting);  
                        using(var storageStream = await file.OpenAsync(FileAccessMode.ReadWrite)) {  
                            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, storageStream);  
                            var pixelStream = wbm.PixelBuffer.AsStream();  
                            var pixels = new byte[pixelStream.Length];  
                            await pixelStream.ReadAsync(pixels, 0, pixels.Length);  
  
  
                            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint) wbm.PixelWidth, (uint) wbm.PixelHeight, 48, 48, pixels);  
                            await encoder.FlushAsync();  
                        }  
  
                    }  
                    MyImage = wbm;  
  
                    exit = 1;  
                } catch (Exception ex) {  
                    MessageDialog dialog = new MessageDialog("Error while initializing media capture device: " + ex.Message);  
                    dialog.ShowAsync();  
                    GC.Collect();  
                }  
  
  
                //  
            }  
        }  
    } catch {}  
}  
private async Task InitializeQrCode() {  
    string error = null;  
    try {  
         
  
        DeviceInformationCollection webcamList = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);  
  
  
        
        DeviceInformation backWebcam = (from webcam in webcamList where webcam.IsEnabled select webcam).FirstOrDefault();  
  
  
      
  
  
        mediaCapture = new MediaCapture();  
        await mediaCapture.InitializeAsync(new MediaCaptureInitializationSettings {  
            VideoDeviceId = backWebcam.Id,  
                AudioDeviceId = "",  
                StreamingCaptureMode = StreamingCaptureMode.Video,  
                PhotoCaptureSource = PhotoCaptureSource.VideoPreview  
        });  
  
  
        mediaCapture.SetPreviewRotation(VideoRotation.Clockwise90Degrees);  
        mediaCapture.SetRecordRotation(VideoRotation.Clockwise90Degrees);  
  
  
   
        captureElement.Source = mediaCapture;  
        await mediaCapture.StartPreviewAsync();  
  
  
        mediaCapture.FocusChanged += mediaCapture.FocusChanged;  
  
  
        // Seetting Focus & Flash(if Needed)  
  
  
        var torch = mediaCapture.VideoDeviceController.TorchControl;  
        if (torch.Supported) torch.Enabled = true;  
  
  
        await mediaCapture.VideoDeviceController.FocusControl.UnlockAsync();  
        var focusSettings = new FocusSettings();  
        focusSettings.AutoFocusRange = AutoFocusRange.FullRange;  
        focusSettings.Mode = FocusMode.Continuous;  
        focusSettings.WaitForFocus = true;  
        focusSettings.DisableDriverFallback = false;  
        mediaCapture.VideoDeviceController.FocusControl.Configure(focusSettings);  
        await mediaCapture.VideoDeviceController.FocusControl.FocusAsync();  
  
  
        //}  
    } catch (Exception ex) {  
        dialog = new MessageDialog("Error: " + ex.Message);  
        dialog.ShowAsync();  
    }  
}  


  
private async void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e) {  
    exit = 1;  
    mediaCapture.Dispose();  
    if (this.Frame.CanGoBack) {  
        e.Handled = true;  
        this.Frame.GoBack();  
    }  
}
          
    }
}
