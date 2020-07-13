using Storage_Admin_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Storage_Admin_App.Windows
{
    public partial class UsersInfo : Window
    {
        public UsersInfo()
        {
            InitializeComponent();
            int size = ReadFromDatabase.ShowAllUsers().Count();
            List<User> lArea = ReadFromDatabase.ShowAllUsers().ToList();
            for (int i = 0; i < size; i++)
            {
                listusers.Items.Clear();
                listusers.Items.Add(lArea[i]);
            }
            if (listusers.Items.Count == 0)
                listusers.Items.Add("The table is empty. Try to add new info");
        }
    }
}
