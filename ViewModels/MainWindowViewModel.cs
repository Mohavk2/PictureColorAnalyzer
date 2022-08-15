using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PictureColorAnalyzer.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        BitmapImage? _image;
        public BitmapImage? Image
        {
            get => _image;
            set
            {
                _image = value;
                RaisePropertyChanged(nameof(Image));
            }
        }

        public ICommand OpenImage
        {
            get => new UICommand(ExecuteOpenImage);
        }

        void ExecuteOpenImage(object parameter)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Image";
            dialog.DefaultExt = ".bmp";
            dialog.Filter = "Image (.jpg)|*.jpg";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;

                Image = new BitmapImage();
                Image.BeginInit();
                Image.UriSource = new Uri(filename, UriKind.Absolute);
                Image.EndInit();
            }
        }
    }
}
