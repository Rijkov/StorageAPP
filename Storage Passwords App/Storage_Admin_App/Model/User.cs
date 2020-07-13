namespace Storage_Admin_App.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Last_Name { get; set; }
        public string First_Name { get; set; }
        public int Age { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Role { get; set; }
        public System.DateTime Date_Registr { get; set; }
        public override string ToString()
        {
            return $"{Id} | {Last_Name} | {First_Name} | {Age} | {Login} | {Password} | {Email} | {Phone} | {Role} | {Date_Registr}";
        }
    }
}
