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
    /// Логика взаимодействия для ParentsWin.xaml
    /// </summary>
    public partial class ParentsWin : Window, INotifyPropertyChanged
    {
        private Parent selectedParent;

        public Parent SelectedParent
        {
            get => selectedParent;
            set
            {
                selectedParent = value;
                Signal();
            }
        }
        public ObservableCollection<Parent> Parents
        {
            get => Data.Parents;
        }
        
        public ParentsWin()
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
        private void AddParents(object sender, RoutedEventArgs e)
        {
            Parents.Add(new Parent { Name = "Новый родитель" });
        }
        private void DeleteParents(object sender, RoutedEventArgs e)
        {
            if (SelectedParent == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранного родителя",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Parents.Remove(SelectedParent);
            }
        }
    }
}
