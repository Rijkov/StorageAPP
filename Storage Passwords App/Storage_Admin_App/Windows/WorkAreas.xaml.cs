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
    public partial class WorkAreas : Window
    {
        MyContext db = new MyContext();
        public WorkAreas()
        {
            InitializeComponent();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            lbox.Items.Clear();
            new Create("Add").ShowDialog();
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            if (lbox.SelectedItem != null)
            {
                WorkArea selected = lbox.SelectedItem as WorkArea;
                Create crate = new Create("Edit", selected);
                crate.Owner = this;
                crate.ShowDialog();
            }
            else
                MessageBox.Show("First you need to sellect any object!", "NOT Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            if (lbox.SelectedItem != null)
            {
                MessageBoxResult res = MessageBox.Show("Are you realy want to delete this info??", "Delete?",MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    WorkArea del = lbox.SelectedItem as WorkArea;
                    DeleteRecord.DeleteInfo(del);
                    lbox.Items.Remove(lbox.SelectedItem);
                    if (lbox.Items.Count == 0)
                        lbox.Items.Add("The table is empty. Try to add new info");
                }
                else return;
            }
            else
                MessageBox.Show("First you need to sellect any object!", "NOT Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int size = ReadFromDatabase.ShowAllAreas().Count();
            List<WorkArea> lArea = ReadFromDatabase.ShowAllAreas().ToList();
            for (int i = 0; i < size; i++)
            {
                lbox.Items.Add(lArea[i]);
            }
            if (lbox.Items.Count == 0)
                lbox.Items.Add("The table is empty. Try to add new info");
        }

        private void users_btn_Click(object sender, RoutedEventArgs e)
        {
            new UsersInfo().ShowDialog();
        }
    }
}
