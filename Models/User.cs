namespace LaundryFinal.Models
{
    public class User
    {
        public String Name { get; set; }
        public String Email { get; set; }

        public String Password { get; set; }

        public int User_id { get; set; }
        public bool is_admin { get; set; }
        public User() { }
        public User(String name, String email, String password, bool is_admin)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.is_admin = is_admin;
        }
        public User(String name, String email, String password, int User_id,bool is_admin)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.User_id = User_id;
            this.is_admin = is_admin;

        }
    }
}
