namespace Storage_Admin_App.Model
{
    using System.Data.SqlClient;

    class DeleteRecord
    {
        public static string DeleteInfo(WorkArea d)
        {         
            string msg = "";
            using (var conn = Connection.conn = new SqlConnection(Connection.connectstr))
            {
                conn.Open();
                using (var cmd = Connection.cmd = new SqlCommand($"delete from WorkAreas where id = {d.Id}", conn))
                {
                    int res = cmd.ExecuteNonQuery();

                    if (res == 1)
                        msg = $"info about - {d.SiteName} was delete successfuly";
                    else if (res == 0)
                        msg = $"info about - {d.SiteName} has NOT delete...";
                }
            }

            return msg;
        }
    }
}
