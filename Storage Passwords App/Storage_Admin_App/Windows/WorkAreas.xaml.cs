namespace Storage_Admin_App.Windows
{
    using System.Linq;
    using System.Windows;
    using Storage_Admin_App.Model;
    using System.Windows.Threading;
    using System.Collections.Generic;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Media;

    public partial class WorkAreas : Window
    {
        MyContext db = new MyContext();
        DispatcherTimer timer = null;
        int num_table;
        string role, user_name;
        int time_end;
        MainWindow owner;

        public WorkAreas(int num_table, string role, string user_name, MainWindow main)
        {
            InitializeComponent();
            owner = main;
            timer = new DispatcherTimer();  // если надо, то в скобках указываем приоритет, например DispatcherPriority.Render
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Start();
            time_end = 1;
            this.num_table = num_table;
            this.role = role; 
            this.user_name = user_name;
            welcome_lbl.Content = $"Welcome {user_name}";
            if (role.Equals("user"))
                users_btn.Visibility = Visibility.Hidden;
        }
        Random rand = new Random();

        SolidColorBrush[] GetColor()
        {
            SolidColorBrush[] b = new SolidColorBrush[]
            {
                Brushes.Yellow, Brushes.Blue,Brushes.Maroon,Brushes.Magenta,Brushes.BurlyWood,Brushes.MediumAquamarine
            };
            return b;
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            time_end++;
            this.Title = time_end.ToString();
            this.Background = GetColor()[rand.Next(1, 6)];
            if(time_end == 60)
            {
                MessageBoxResult res = MessageBox.Show("Are you still here?", "End Session?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    timer.Tick += Timer_Tick;
                    time_end = 0;
                    return;
                }
                else // NO
                {
                    (this.owner as MainWindow).login_txt.Text = "";
                    (this.owner as MainWindow).passwd_txt.Password = "";
                    (this.owner as MainWindow).remeber_check.IsChecked = false;
                    (this.owner as MainWindow).flag = false;
                    time_end = 0;
                    this.Close();
                }
                (this.owner as MainWindow).login_txt.Text = "";
                (this.owner as MainWindow).passwd_txt.Password = "";
                (this.owner as MainWindow).remeber_check.IsChecked = false;
                (this.owner as MainWindow).flag = false;
                this.Close();
                timer.Stop();
            }
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            lbox.Items.Clear();
            new Create("Add", num_table).ShowDialog();
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            if (lbox.SelectedItem != null)
            {
                WorkArea selected = lbox.SelectedItem as WorkArea;
                if (selected == null) return; 
                else
                {
                    Create crate = new Create("Edit", selected, num_table);
                    crate.Owner = this;
                    crate.ShowDialog();
                }
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
            int size = ReadFromDatabase.ShowAllAreas(num_table).Count();
            List<WorkArea> lArea = ReadFromDatabase.ShowAllAreas(num_table).ToList();
            for (int i = 0; i < size; i++)
            {
                lbox.Items.Add(lArea[i]);
            }
            if (lbox.Items.Count == 0)
                lbox.Items.Add("The table is empty. Try to add new info");
        }

        private void Load_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
        }

        private void users_btn_Click(object sender, RoutedEventArgs e)
        {
            new UsersInfo().ShowDialog();
        }
    }
}
