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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace League
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Legends selectedLegends;
        

        public ObservableCollection<Legends> Legends
        {
            get => Data.Legends;
        }
        public ObservableCollection<Group> Groups
        {
            get => Data.Groups;
        }
        public ObservableCollection<Parent> Parents
        {
            get => Data.Parents;
        }
        public ObservableCollection<Bond> Bonds
        {
            get => Data.Bonds;
        }
        public Legends SelectedLegends
        {
            get => selectedLegends;
            set
            {
                selectedLegends = value;
                Signal();
            }

        }

        public MainWindow()
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

        private void AddLegends(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.PaleGreen);
            Legends.Add(new Legends
            {
                Name = "Новый герой",
                Birthday = DateTime.Today
            });
        }

        private void DeleteLegends(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.PaleGreen);
            if (SelectedLegends == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранного героя?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Legends.Remove(SelectedLegends);
                SelectedLegends = null;
            }
        }

        private void OpenRole(object sender, RoutedEventArgs e)
        {
            RoleWin win = new RoleWin();
            win.ShowDialog();
        }

        private void OpenGroups(object sender, RoutedEventArgs e)
        {
            GroupWin win = new GroupWin();
            win.ShowDialog();
        }

        private void OpenImage(object sender, RoutedEventArgs e)
        {
            ImageWin win = new ImageWin();
            win.ShowDialog();
        }
        private void OpenParents(object sender, RoutedEventArgs e)
        {
            ParentsWin win = new ParentsWin();
            win.ShowDialog();
        }
        private void OpenBonds(object sender, RoutedEventArgs e)
        {
            BondsWin win = new BondsWin();
            win.ShowDialog();
        }
    }
}
