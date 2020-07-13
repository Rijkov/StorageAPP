namespace Storage_Admin_App.Model
{
    class Connection
    {
        public static string connectstr = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    }
}
