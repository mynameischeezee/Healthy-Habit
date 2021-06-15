namespace HealthyHabit.Models
{
    public class User : ModelTemplate
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }

        public User()
        {

        }
        public User(string name, string username, string mail, string passwordhash, string salt)
        {
            this.Name = name;
            this.UserName = username;
            this.Mail = mail;
            this.PasswordHash = passwordhash;
            this.Salt = salt;
        }

    }
}
