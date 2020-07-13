using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Storage_Admin_App.Model
{
    class DeleteRecord
    {
        public static string DeleteInfo(WorkArea d)
        {
            var conn = Connection.conn;
            var cmd = Connection.cmd;
            string msg = "";
            using (conn = new SqlConnection(Connection.connectstr))
            {
                conn.Open();
                using (cmd = new SqlCommand($"delete from WorkAreas where id = {d.Id}", conn))
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
