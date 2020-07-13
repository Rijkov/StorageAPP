namespace Storage_Admin_App.Model
{
    using System.Data.Entity;

    public class MyContext : DbContext
    {
        public MyContext() : base("name=connect") { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkArea> WorkAreas { get; set; }
    }
}


///INSERT INTO [dbo].[Users] ([Id], [Last_Name], [First_Name], [Age], [Login], [Password], [Email], [PhoneNumb], [Role], [Date_Registr]) VALUES (1, N'Vasia', N'Pupkin', 28, N'pupkinxd', N'qwerty1', N'pupxd@email.com', N'111111', N'admin', NULL)