namespace Storage_Admin_App.Windows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Documents;
    using Storage_Admin_App.Model;

    public partial class Create : Window
    {
        MyContext db = new MyContext();
        WorkArea update_Area;
        string mode;
        public Create(string mode) // Add
        {
            InitializeComponent();
            text_btn.Content = "Add New";
            this.mode = mode;
        }

        public Create(string mode, WorkArea update_Area) // Edit
        {
            InitializeComponent();
            text_btn.Content = "Update";
            this.update_Area = update_Area;
            this.mode = mode;

            name_txt.Text = update_Area.SiteName;
            login_txt.Text = update_Area.Login;
            paswd_txt.Text = update_Area.Password;
            email_txt.Text = update_Area.Email;
            phone_txt.Text = update_Area.Phone.ToString();
            url_txt.Text = update_Area.URL;
            coments_txt.Text = update_Area.Coments;
        }

        private void text_btn_Click(object sender, RoutedEventArgs e)
        {
            if (mode == "Add")
            {
                AddArea();
            }
            else if (mode == "Edit")
            {
                EditArea();
            }
        }

        void EditArea()
        {
            int index = (this.Owner as WorkAreas).lbox.Items.IndexOf(this.update_Area);
            int idTable = update_Area.Id;

            List<WorkArea> all = ReadFromDatabase.ShowAllAreas().ToList();
            WorkArea update = all.Where(i => i.Id == idTable).FirstOrDefault();
            update.SiteName = name_txt.Text;
            update.Login = login_txt.Text;
            update.Password = paswd_txt.Text;
            update.Phone = Convert.ToInt32( phone_txt.Text);
            update.URL = url_txt.Text;
            update.Email = email_txt.Text;
            update.Coments = coments_txt.Text;
            update.DateCreate = DateTime.Now;

            db.Entry(update).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            (this.Owner as WorkAreas).lbox.Items.RemoveAt(index);
            (this.Owner as WorkAreas).lbox.Items.Insert(index, update);

            this.Close();
        }

        void AddArea()
        {
            if (name_txt.Text == null && login_txt.Text == null && paswd_txt.Text == null && email_txt.Text == null &&
               phone_txt.Text == null && url_txt.Text == null && coments_txt.Text == null)
            {
                MessageBox.Show("All fields is empty", "empty", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (name_txt.Text == null || login_txt.Text == null || paswd_txt.Text == null || email_txt.Text == null ||
                phone_txt.Text == null || url_txt.Text == null || coments_txt.Text == null)
            {
                MessageBox.Show("Some of field are empty", "empty", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                WorkArea add_wa = new WorkArea
                {
                    SiteName = name_txt.Text,
                    Login = login_txt.Text,
                    Password = paswd_txt.Text,
                    Email = email_txt.Text,
                    Phone = System.Convert.ToInt32(phone_txt.Text),
                    URL = url_txt.Text,
                    Coments = coments_txt.Text,
                    DateCreate = DateTime.Now

                };

                db.WorkAreas.Add(add_wa);
                db.SaveChanges();
                MessageBox.Show($"SiteName-{name_txt.Text} was add sucsesfule");
                name_txt.Text = login_txt.Text = paswd_txt.Text = email_txt.Text = url_txt.Text = coments_txt.Text = phone_txt.Text = "";
            }
        }
    }
}
