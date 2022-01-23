using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace League
{
    static class Data
    {
        public static ObservableCollection<Role> Roles = new ObservableCollection<Role>();
        public static ObservableCollection<Legends> Legends = new ObservableCollection<Legends>();
        public static ObservableCollection<Group> Groups = new ObservableCollection<Group>();
        public static ObservableCollection<Image> Images = new ObservableCollection<Image>();
        public static ObservableCollection<Parent> Parents = new ObservableCollection<Parent>();
        public static ObservableCollection<Bond> Bonds = new ObservableCollection<Bond>();
    }
}
