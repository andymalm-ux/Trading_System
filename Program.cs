using App;

List<Item> user_items = new List<Item>();
List<User> myUser = new List<User>();

string[] users_csv = File.ReadAllLines("Users.csv");
string path_u = "Users.csv";

foreach (string user in users_csv)
{
  string[] values = user.Split(",");
  myUser.Add(new User(values[0], values[1], values[2]));
}

string[] items_csv = File.ReadAllLines("Items.csv");
string path_i = "Items.csv";

foreach (string item in items_csv)
{
  string[] values = item.Split(",");

  user_items.Add(new Item(values[0], values[1], values[2]));
}

User active_user = null;

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

          myUser.Add(new User(name, email, _password));

          string[] account = { name + "," + email + "," + _password };

          File.AppendAllLines(path_u, account);

          break;

        case "login":

          Console.Write("Username: ");
          string username = Console.ReadLine();
          Console.Write("Password: ");
          string password = Console.ReadLine();

          foreach (User user in myUser)
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
    Console.WriteLine("\nAdd\nShow\nLogout");

    switch (Console.ReadLine())
    {
      case "add":

        //Console.Write("\nYour username: ");
        //string id = Console.ReadLine();
        Console.Write("\nType of item: ");
        string new_item = Console.ReadLine();
        Console.Write("\nDescription of item: ");
        string new_description = Console.ReadLine();
        string user_id = u.Email;

        user_items.Add(new Item(user_id, new_item, new_description));

        string[] stored_items = { user_id + "," + new_item + "," + new_description };
        File.AppendAllLines(path_i, stored_items);

        break;

      case "show":





        break;

      case "logout":
        active_user = null;
        break;
    }
  }

}
