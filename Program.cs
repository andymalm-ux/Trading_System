using App;



List<IAccount> myAccount = new List<IAccount>();

IAccount active_user = null;


bool running = true;

while (running)
{
  if (active_user == null)
  {
    bool logged_out = true;

    while (logged_out)
    {
      Console.WriteLine("New\nLogin\nQuit");
      string input = Console.ReadLine();

      switch (input)
      {
        case "new":
          Console.Write("Enter your name: ");
          string name = Console.ReadLine();
          Console.Write("Enter your email: ");
          string email = Console.ReadLine();
          Console.Write("Enter your password: ");
          string _password = Console.ReadLine();

          myAccount.Add(new User(name, email, _password));
          break;

        case "login":

          Console.Write("Username: ");
          string username = Console.ReadLine();
          Console.Write("Password: ");
          string password = Console.ReadLine();

          foreach (IAccount user in myAccount)
          {
            if (user.TryLogin(username, password))
            {
              active_user = user;
              logged_out = false;
              break;
            }
          }
          break;

        case "quit":
          logged_out = false;
          running = false;
          break;
      }
    }
  }

  else if (active_user is User u)
  {
    Console.WriteLine("Hej " + u.Name);
    Console.WriteLine("Logout");
    switch (Console.ReadLine())
    {
      case "logout":
        active_user = null;
        break;
    }
  }

}
