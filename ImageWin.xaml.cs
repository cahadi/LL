using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace League
{
    /// <summary>
    /// Логика взаимодействия для ImageWin.xaml
    /// </summary>
    public partial class ImageWin : Window, INotifyPropertyChanged
    {
        private Image selectedImage;
        public Image SelectedImage
        {
            get => selectedImage;
            set
            {
                selectedImage = value;
                Signal();
            }
        }
        public ObservableCollection<Image> Images
        {
            get => Data.Images;
        }
        public ImageWin()
        {
            this.Background = new SolidColorBrush(Colors.PaleGreen);
            InitializeComponent();
            DataContext = this;
        }
        void Signal([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this,
                      new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void AddImage(object sender, RoutedEventArgs e)
        {
            Images.Add(new Image { Name = "Наименование" });
        }
        private void DeleteImage(object sender, RoutedEventArgs e)
        {
            if (SelectedImage == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранный образ?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Images.Remove(SelectedImage);
            }
        }

    }
}
