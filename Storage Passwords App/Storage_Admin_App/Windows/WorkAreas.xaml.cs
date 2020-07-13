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
            int size = ReadFromDatabase.ShowAllAreas().Count();
            List<WorkArea> lArea = ReadFromDatabase.ShowAllAreas().ToList();
            for (int i=0; i < size; i++)
            {
                lbox.Items.Add(lArea[i]);
            }
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            new Create("Add").ShowDialog();
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {

            if (lbox.SelectedItems != null)
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

            //WorkArea del = lbox.SelectedItem as WorkArea;
            //db.WorkAreas.Remove(del);
            //db.SaveChanges();
            lbox.Items.Remove(lbox.SelectedItem);
        }
    }
}
