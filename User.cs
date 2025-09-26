namespace App;

public class User
{
  public string Name;
  public string Email;
  public string Password;

  public User(string name, string email, string password)
  {
    Name = name;
    Email = email;
    Password = password;
  }
}