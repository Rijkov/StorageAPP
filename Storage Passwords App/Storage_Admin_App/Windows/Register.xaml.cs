namespace Storage_Admin_App.Windows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using Storage_Admin_App.Model;

    public partial class Register : Window
    {
        MyContext db;
        public Register()
        {
            InitializeComponent();
            role_txt.IsReadOnly = true;
            db = new MyContext();
            int size = ReadFromDatabase.ShowAllUsers().Count();
            if (size == 0)
            {
                MessageBox.Show("To get startet you should create an aplication owner with tha Admin role. Jast you will have this role./nAll" +
                    "subsequent users will play the role 'user'", "Create 1st Owner", MessageBoxButton.OK, MessageBoxImage.Information);
                role_txt.Text = "admin";
            }
            else role_txt.Text = "user";
        }

        private void text_btn_Click(object sender, RoutedEventArgs e)
        {
            AddUser();
        }

        void AddUser()
        {
            
            if (name_txt.Text == null && login_txt.Text == null && paswd_txt.Text == null && email_txt.Text == null &&
               phone_txt.Text == null && fname_txt.Text == null && role_txt.Text == null && age_txt.Text == null)
            {
                MessageBox.Show("All fields is empty", "empty", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (name_txt.Text == null || login_txt.Text == null|| paswd_txt.Text == null || email_txt.Text == null ||
               phone_txt.Text == null || fname_txt.Text == null || role_txt.Text == null || age_txt.Text == null)
            {
                MessageBox.Show("Some of field are empty", "empty", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                //try
                //{
                    List<User> users = ReadFromDatabase.ShowAllUsers().ToList();
                    int num_table = users.Count + 1;

                    User add_wa = new User
                    {
                        Last_Name = name_txt.Text,
                        First_Name = fname_txt.Text,
                        Login = login_txt.Text,
                        Password = paswd_txt.Text,
                        Email = email_txt.Text,
                        Phone = Convert.ToInt32(phone_txt.Text),
                        Role = role_txt.Text,
                        Id_WorkArea = num_table,
                        Age = Convert.ToInt32(age_txt.Text),
                        Date_Registr = DateTime.Now
                    };

                    db.Users.Add(add_wa);
                    db.SaveChanges();

                    db.Database.ExecuteSqlCommand(
                         $"CREATE TABLE [dbo].[WorkAreas_{num_table}] (" +
                         $"[Id]         INT           IDENTITY(1, 1) NOT NULL," +
                         $"[SiteName]   NVARCHAR(50) NULL," +
                         $"[Email]      NVARCHAR(50) NULL," +
                         $"[Login]      NVARCHAR(50) NULL," +
                         $"[Password]   NVARCHAR(50) NULL," +
                         $"[URL]        NVARCHAR(50) NULL," +
                         $"[Phone]      NVARCHAR(50) NULL," +
                         $"[Coments]    NVARCHAR(50) NULL," +
                         $"[DateCreate] DATETIME      NULL)");

                    MessageBox.Show($"User - {name_txt.Text} has created!");
                    this.Close();
                //}
                //catch(Exception ex) { MessageBox.Show(ex.Message, "Something went wrong..", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }
    }
}
