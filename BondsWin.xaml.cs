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
    /// Логика взаимодействия для BondsWin.xaml
    /// </summary>
    public partial class BondsWin : Window, INotifyPropertyChanged
    {
        private Bond selectedBond;

        public Bond SelectedBond
        {
            get => selectedBond;
            set
            {
                selectedBond = value;
                Signal();
            }
        }
        public ObservableCollection<Bond> Bonds
        {
            get => Data.Bonds;
        }
        public BondsWin()
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
        private void AddBonds(object sender, RoutedEventArgs e)
        {
            Bonds.Add(new Bond { Name = "Новый бро" });
        }
        private void DeleteBonds(object sender, RoutedEventArgs e)
        {
            if (SelectedBond == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранного бро",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Bonds.Remove(SelectedBond);
            }
        }
    }
}
