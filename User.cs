namespace App;

public class User
{
  public string Name;
  public string Email;
  string Password;

  public User(string name, string email, string password)
  {
    Name = name;
    Email = email;
    Password = password;
  }

  public bool TryLogin(string username, string password)
  {
    return username == Email && password == Password;
  }
}