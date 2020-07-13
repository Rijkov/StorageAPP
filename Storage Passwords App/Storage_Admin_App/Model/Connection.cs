namespace Storage_Admin_App.Model
{
    using System.Data.SqlClient;

    class Connection
    {
        public static string connectstr = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static SqlDataReader dreder;
    }
}
