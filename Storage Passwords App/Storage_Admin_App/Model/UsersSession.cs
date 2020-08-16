namespace Storage_Admin_App.Model
{
    using System;

    public class UsersSessions
    {
        public int Id { get; set; }
        public string CurLogin { get; set; }
        public string CurPassword { get; set; } 
        public bool RememberMe { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateEnter { get; set; }
        public DateTime DateLeave { get; set; }
        public Guid AccessToken { get; set; }
    }
}
