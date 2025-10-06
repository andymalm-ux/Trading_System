using App;

List<Item> user_items = new List<Item>();
List<User> myUser = new List<User>();


string trade_original = ("Trades.csv");
string items_updated = ("Items.csv");
string trade_backup = ("Trades_bckup.csv");


string[] users_csv = File.ReadAllLines("Users.csv"); //Läser in information från Users.csv och sparar det till en array.
string path_u = "Users.csv"; //Skapar en variabel för att enkelt komma åt Users.csv.

foreach (string user in users_csv)  //Skapar en loop för att gå igenom innehållet i Users.csv. 
{
  string[] values = user.Split(",");  //Delar upp varje värde skiljt med komma.
  myUser.Add(new User(values[0], values[1], values[2])); //Sparar informationen i en list.
}

string[] items_csv = File.ReadAllLines("Items.csv"); // Samma funktion som ovan men hämtar och spara information för items.
string path_i = "Items.csv";

foreach (string item in items_csv)
{
  string[] values = item.Split(",");
  user_items.Add(new Item(values[0], values[1], values[2]));
}

User active_user = null; //Variabel för att kontrollera om man är inloggade

bool running = true; // Variabel för att loopa programmet. 

while (running) // Start av while-loop.
{
  if (active_user == null) // Om man inte är inloggade körs koden som tar en till inloggningssidan.
  {
    bool logged_out = true; // Bool-variabel för att köra funktionen för inloggning sälänge man inte
                            // är inloggad.
    while (logged_out)
    {
      Console.Clear();

      Console.WriteLine("--- Welcome to the trading system ---");
      Console.WriteLine("\n1. New account\n2. Login\n3. Quit");
      string input = Console.ReadLine();

      switch (input) // Switch-case för att hantera menyfunktionen.
      {
        case "1": // Här skapar man ett nytt konto.

          Console.Clear();

          Console.WriteLine("--- Create account ---");

          Console.Write("\nEnter your name: ");
          string name = Console.ReadLine();     // Sparar input från användaren i en variabel string. 
          Console.Write("\nEnter your email: ");
          string email = Console.ReadLine();
          Console.Write("\nEnter your password: ");
          string _password = Console.ReadLine();

          myUser.Add(new User(name, email, _password)); // Här sparas värdena från användarens input i en lista (User).

          string[] account = { name + "," + email + "," + _password }; // Skapar en array (account) för att 
                                                                       // även kunna spara informationen till fil.
          File.AppendAllLines(path_u, account); // Här skrivs informationen till filen Users.csv.

          break;

        case "2":

          Console.Clear();

          Console.WriteLine("--- Login ---");

          Console.Write("\nUsername: ");
          string username = Console.ReadLine(); //Sparar input från användaren i en variabel string.
          Console.Write("\nPassword: ");
          string password = Console.ReadLine();

          foreach (User user in myUser) // Vi jämför inputen från anvädaren mot varje string i listan User
          {
            if (user.TryLogin(username, password)) // Här säger vi om username och password stämmer,
            {                                      // så blir användaren samma som username.
              active_user = user;                  // Vi är nu inloggade.
              logged_out = false;
              break;
            }
          }
          break;

        case "3":
          logged_out = false; // Vi bryter while-loopen för logged_out samt running. Programmet stängs.
          running = false;
          break;
      }
    }
  }

  else if (active_user is User u) // Om vi blir inloggade hamnar vi här. Vi deklarerar att active_user = u.
  {
    Console.Clear();
    Console.WriteLine("--- Main meny ---");

    Console.WriteLine("\nHello " + u.Name); // Skriver ut namnet på användaren.
    Console.WriteLine("\n1. Add\n2. Show\n3. Trade\n4. Logout");

    switch (Console.ReadLine())
    {
      case "1":

        Console.Clear();

        Console.WriteLine("--- Add item ---");  // Här sparar vi ett item i listan Item.
        Console.Write("\nType of item: ");
        string new_item = Console.ReadLine();     // Vi frågar efter 2 inputs från användaren.
        Console.Write("\nDescription of item: "); // Dessa sparas i strängarna new_item och new_description.
        string new_description = Console.ReadLine();
        string user_id = u.Email;   // Jag deklarerar en variabel user_id och säger att den är samma som användarens email.

        user_items.Add(new Item(user_id, new_item, new_description)); // Datan sparas i Listan Item.

        string[] stored_items = { user_id + "," + new_item + "," + new_description }; // Datan sparas även i en tillfällig array stored_items.
        File.AppendAllLines(path_i, stored_items);                                    // Sedan skrivs datan i arrayen till filen Items.csv   

        break;

      case "2":

        Console.Clear();

        Console.WriteLine("--- Items up for trade ---");  // Funktion för att se alla föremål.

        foreach (Item item in user_items) // Med hjälp av en foreach-loop går vi igenom alla item i listan user_items.
        {
          Console.WriteLine("Username: " + item.Account_Item + "\nItem: " + item.Name_Item + "\nDescription: " + item.Description_Item + "\n"); // Vi skriver ut varje item i listan,
        }

        Console.WriteLine("Press ENTER to return to main meny.");
        Console.ReadLine();

        break;

      case "3":

        Console.Clear();

        Console.WriteLine("--- Items up for trade ---");

        foreach (Item item in user_items) // Samma som ovan. Skriver ut alla item i listan user_items.
        {
          Console.WriteLine("Username: " + item.Account_Item + "\nItem: " + item.Name_Item + "\nDescription: " + item.Description_Item + "\n");
        }

        Console.Write("\nItem you want to trade: ");  // Användaren gör 2st inputs som sparas i variablarna own_item och item_to_trade.
        string own_item = Console.ReadLine();
        Console.Write("\nItem you want to trade for: ");
        string item_to_trade = Console.ReadLine();


        foreach (Item trade_item in user_items) // Med en foreach-loop går vi igenom alla trade_item i listan user_items.
        {
          if (item_to_trade == trade_item.Name_Item) // Om värdet för item_to_trade stämmer med trade_item.Name_Item,
          {
            trade_item.Account_Item = u.Email;       // bytas username (email) på objektet till den inloggades username.
          }
          string[] trades = { trade_item.Account_Item + "," + trade_item.Name_Item + "," + trade_item.Description_Item };
          File.AppendAllLines("Trades.csv", trades); // Datan sparas i en tillfällig array för att sedan skrivas till files Trades.csv.
        }

        File.Replace(trade_original, items_updated, trade_backup);  // Innehållet i filen Trades.csv ersätter innehållet i filen Items.csv.
        break;                                                      // På så vis är informationen i Items.csv uppdaterad.

      case "4":
        active_user = null;
        break;
    }
  }

}
