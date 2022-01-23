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
    /// Логика взаимодействия для RoleWin.xaml
    /// </summary>
    public partial class RoleWin : Window, INotifyPropertyChanged
    {
        private Role selectedRole;

        public Role SelectedRole
        {
            get => selectedRole;
            set
            {
                selectedRole = value;
                Signal();
            }
        }
        public ObservableCollection<Role> Roles
        {
            get => Data.Roles;
        }
        public RoleWin()
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
        private void AddRole(object sender, RoutedEventArgs e)
        {
            Roles.Add(new Role { Title = "Новая роль" });
        }

        private void DeleteRole(object sender, RoutedEventArgs e)
        {
            if (SelectedRole == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранную роль",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Roles.Remove(SelectedRole);
            }
        }
    }
}
