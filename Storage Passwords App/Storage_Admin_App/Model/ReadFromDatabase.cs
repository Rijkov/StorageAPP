namespace Storage_Admin_App.Model
{
    using System;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    class ReadFromDatabase
    {
        public static IEnumerable<WorkArea> ShowAllAreas()
        {
            var conn = Connection.conn;
            var cmd = Connection.cmd;
            var dreder = Connection.dreder;
            List<WorkArea> list = new List<WorkArea>();
            using (conn = new SqlConnection(Connection.connectstr))
            {
                conn.Open();
                using (cmd = new SqlCommand("select * from WorkAreas", conn))
                {
                    dreder = cmd.ExecuteReader();
                    while (dreder.Read())
                    {
                        WorkArea area = new WorkArea();
                        area.Coments = dreder["Coments"].ToString();
                        area.DateCreate = Convert.ToDateTime(dreder["DateCreate"].ToString());
                        area.SiteName = dreder["SiteName"].ToString();
                        area.Login = dreder["Login"].ToString();
                        area.Password = dreder["Password"].ToString();
                        area.Phone = Convert.ToInt32(dreder["Phone"].ToString());
                        area.URL = dreder["URL"].ToString();
                        area.Id = Convert.ToInt32(dreder["Id"].ToString());

                        list.Add(area);

                    }
                }
                return list;
            }
        }


        public static IEnumerable<User> ShowAllUsers()
        {
            var conn = Connection.conn;
            var cmd = Connection.cmd;
            var dreder = Connection.dreder;
            List<User> list = new List<User>();
            using (conn = new SqlConnection(Connection.connectstr))
            {
                conn.Open();
                using (cmd = new SqlCommand("select * from Users", conn))
                {
                    dreder = cmd.ExecuteReader();
                    while (dreder.Read())
                    {
                        User area = new User();
                        area.Last_Name = dreder["Last_Name"].ToString();
                        area.First_Name = dreder["First_Name"].ToString();
                        area.Age = Convert.ToInt32(dreder["Age"]);
                        area.Date_Registr = Convert.ToDateTime(dreder["Date_Registr"].ToString());
                        area.Email = dreder["Email"].ToString();
                        area.Login = dreder["Login"].ToString();
                        area.Password = dreder["Password"].ToString();
                        area.Phone = Convert.ToInt32(dreder["Phone"].ToString());
                        area.Role = dreder["Role"].ToString();
                        list.Add(area);

                    }
                }
                return list;
            }
        }

    }
}
