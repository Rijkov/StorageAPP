namespace Storage_Admin_App.Model
{
    using System;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    class ReadFromDatabase
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        static SqlDataReader dreder;
        public static IEnumerable<WorkArea> ShowAllAreas()
        {
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


    }
}
