namespace SOLIDPrinciples.SingleResponsibility.Good
{
    /// <summary>
    /// Represents a user entity.
    /// Responsibility: Hold user data.
    /// </summary>
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public User(string email, string password, string name)
        {
            Email = email;
            Password = password;
            Name = name;
        }
    }
}
