namespace Storage_Admin_App
{
    using System.Linq;
    using System.Windows;
    using Storage_Admin_App.Model;
    using Storage_Admin_App.Windows;
    using System.Collections.Generic;

    public partial class MainWindow : Window
    {
        MyContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new MyContext();
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            if (login_txt.Text.Equals(string.Empty) && passwd_txt.Password.Equals(string.Empty))
                MessageBox.Show("All fields is empty... Try to fill out this!", "empty", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (login_txt.Text.Equals(string.Empty) || passwd_txt.Password.Equals(string.Empty))
                MessageBox.Show("Some of the field is empty... Try to fill out this!", "empty",
                   MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                List<User> check_user = db.Users.ToList();
                for (int i = 0; i < check_user.Count; i++) 
                {
                    if (login_txt.Text == check_user[i].Login && passwd_txt.Password == check_user[i].Password && check_user[i].Role == "admin")
                    {
                        // MessageBox.Show("Congratulation! You Are Welcome", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        new WorkAreas().ShowDialog();
                    }
                    else MessageBox.Show("This user does not exist");
                }

            }
        }
    }
}
