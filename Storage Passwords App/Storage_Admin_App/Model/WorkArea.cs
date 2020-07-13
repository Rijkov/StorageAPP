namespace Storage_Admin_App.Model
{
    using System;

    public class WorkArea
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string URL { get; set; }
        public int Phone { get; set; }
        public string Coments { get; set; }
        public DateTime DateCreate { get; set; }

        public override string ToString()
        {
            return $"{Id} | {SiteName} | {Email} | {Login} | {Password} | {URL} | {Phone} | {Coments} | {DateCreate} ";
        }
    }
}
