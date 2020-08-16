namespace Storage_Admin_App
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using Storage_Admin_App.Model;
    using Storage_Admin_App.Windows;
    using System.Collections.Generic;

    public partial class MainWindow : Window
    {
        MyContext db;
        UsersSessions session;
        int currrent_id, num_table;
        public bool flag = false;
        string token;
        public string TextLogin { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            db = new MyContext();
            session = new UsersSessions();

            int indx = ReadFromDatabase.ShowAllUsers().Count() - 1;

            try
            {
                User last_user = ReadFromDatabase.ShowAllUsers().ToArray()[indx];

                UsersSessions[] sessions = ReadFromDatabase.AllUsersSessions(last_user.Id_WorkArea).ToArray();
                if (sessions[sessions.Count() - 1].RememberMe == true)
                {
                    remeber_check.IsChecked = true;
                    login_txt.Text = last_user.Login;
                    passwd_txt.Password = last_user.Password;
                }
            }
            catch { }
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            login_txt.BorderBrush = Brushes.Silver;
            passwd_txt.BorderBrush = Brushes.Silver;
            if (login_txt.Text.Equals(string.Empty) && passwd_txt.Password.Equals(string.Empty))
            {
                login_txt.BorderBrush = Brushes.Red;
                passwd_txt.BorderBrush = Brushes.Red;
            }
            else if (login_txt.Text.Equals(string.Empty) || passwd_txt.Password.Equals(string.Empty))
            {
                if (login_txt.Text.Equals(""))
                    login_txt.BorderBrush = Brushes.Red;
                else passwd_txt.BorderBrush = Brushes.Red;
            }
            else
            {
                List<User> check_user = db.Users.ToList();

                for (int i = 0; i < check_user.Count; i++)
                {
                    if (login_txt.Text == check_user[i].Login && passwd_txt.Password == check_user[i].Password && check_user[i].Role == "admin")
                        EnteredAdminUser(check_user[i]);
                    else if (login_txt.Text == check_user[i].Login && passwd_txt.Password == check_user[i].Password && check_user[i].Role == "user")
                        EnteredAdminUser(check_user[i]);
                    else if (!flag)
                    {
                        if (login_txt.Text == "" && passwd_txt.Password == "") // if end session
                            return;
                        else
                        {
                            MessageBox.Show("This user does not exist", "Doesn't exist", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                    }
                }      
            }
        }

        private void reg_btn_Click(object sender, RoutedEventArgs e)
        {
            new Register().ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                session.DateLeave = DateTime.Now;
                Insert.AddUserSession(session, num_table);
            }
            catch { }
        }

        void EnteredAdminUser(User check_user)
        {
            flag = true;
            num_table = check_user.Id_WorkArea;
            currrent_id = check_user.Id;
            List<UsersSessions> list = null;
            try
            {
                list = ReadFromDatabase.AllUsersSessions(num_table).ToList();
            }
            catch { }
            if (list == null)
            {
                db.Database.ExecuteSqlCommand(
                 $"CREATE TABLE [dbo].[UserSessions_{num_table}] (" +
                 $"[Id]          INT           IDENTITY(1, 1) NOT NULL," +
                 $"[CurLogin]    NVARCHAR(50) NULL," +
                 $"[CurPassword] NVARCHAR(50)    NULL," +
                 $"[RememberMe]  Bit NULL," +
                 $"[IsActive]    Bit NULL," +
                 $"[AccessToken]    uniqueidentifier NULL," +
                 $"[DateEnter]   datetime NULL," +
                 $"[DateLeave]   datetime NULL)");

                session = new UsersSessions();
                session.CurLogin = login_txt.Text;
                session.CurPassword = passwd_txt.Password;
                session.RememberMe = Convert.ToBoolean(remeber_check.IsChecked);
                session.DateEnter = DateTime.Now;
                session.AccessToken = Guid.NewGuid();

                WorkAreas area_window = new WorkAreas(check_user.Id_WorkArea, check_user.Role, $"{check_user.First_Name} {check_user.Last_Name}", this);
                area_window.Owner = this;
                area_window.ShowDialog();
            }
            else
            {
                session = new UsersSessions();
                session.CurLogin = login_txt.Text;
                session.CurPassword = passwd_txt.Password;
                session.RememberMe = Convert.ToBoolean(remeber_check.IsChecked);
                session.DateEnter = DateTime.Now;
                session.AccessToken = Guid.NewGuid();

                new WorkAreas(check_user.Id_WorkArea, check_user.Role, $"{check_user.First_Name} {check_user.Last_Name}", this).ShowDialog();
            }
        }
    }
}
