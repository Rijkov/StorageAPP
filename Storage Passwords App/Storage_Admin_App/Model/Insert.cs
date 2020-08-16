using System.Windows;
using System.Windows.Interop;

namespace Storage_Admin_App.Model
{
    class Insert
    {
        public static string AddWorkArea(WorkArea area, int num)
        {
            string msg = string.Empty,
                query = $"insert into WorkAreas_{num}(SiteName, Email, Login, Password, URL, Phone, Coments, DateCreate) " +
                    $"values(@SiteName, @Email, @Login, @Password, @URL, @Phone, @Coments, @DateCreate)";
            using (var c = Connection.conn = new System.Data.SqlClient.SqlConnection(Connection.connectstr))
            {
                c.Open();
                using(var cmd = Connection.cmd = new System.Data.SqlClient.SqlCommand(query, c))
                {
                    cmd.Parameters.AddWithValue("@SiteName", area.SiteName);
                    cmd.Parameters.AddWithValue("@Email", area.Email);
                    cmd.Parameters.AddWithValue("@Login", area.Login);
                    cmd.Parameters.AddWithValue("@Password", area.Password);
                    cmd.Parameters.AddWithValue("@URL", area.URL);
                    cmd.Parameters.AddWithValue("@Phone", area.Phone);
                    cmd.Parameters.AddWithValue("@Coments", area.Coments);
                    cmd.Parameters.AddWithValue("@DateCreate", area.DateCreate = System.DateTime.Now);

                    int res = cmd.ExecuteNonQuery();

                    if (res == 1)
                        msg = "Info about Website has inserted Successfuly!!!";
                    else msg = "Something went wrong...";
                }
            }

            return msg;
        }

        public static string AddUserSession(UsersSessions usses, int num_table)
        {
            string msg = string.Empty,
                query = $"insert into UserSessions_{num_table}(CurLogin, CurPassword, RememberMe, IsActive, AccessToken, DateEnter, DateLeave)" +
                $"values(@CurLogin, @CurPassword, @RememberMe, @IsActive, @AccessToken, @DateEnter, @DateLeave)";
            using (var c = Connection.conn = new System.Data.SqlClient.SqlConnection(Connection.connectstr))
            {
                c.Open();
                using (var cmd = Connection.cmd = new System.Data.SqlClient.SqlCommand(query, c))
                {
                    cmd.Parameters.AddWithValue("@CurLogin", usses.CurLogin);
                    cmd.Parameters.AddWithValue("@CurPassword", usses.CurPassword);
                    cmd.Parameters.AddWithValue("@RememberMe", usses.RememberMe);
                    cmd.Parameters.AddWithValue("@IsActive", usses.IsActive);
                    cmd.Parameters.AddWithValue("@AccessToken", usses.AccessToken);
                    cmd.Parameters.AddWithValue("@DateEnter", usses.DateEnter);
                    cmd.Parameters.AddWithValue("@DateLeave", usses.DateLeave);

                    int res = cmd.ExecuteNonQuery();

                    if (res == 1)
                        msg = "Info about Website has inserted Successfuly!!!";
                    else msg = "Something went wrong...";
                }
                
            }

            return msg;
        }
    }
}
