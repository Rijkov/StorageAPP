namespace Storage_Admin_App.Model
{
    using System.Data.Entity;

    public class MyContext : DbContext
    {
        public MyContext() : base("connection") { }

        public virtual DbSet<User> Users { get; set; }
    }
}