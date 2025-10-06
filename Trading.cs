namespace App;

public class Trading
{
  public string Trade_User;
  public string Trade_Item;
  public string Trade_Item_Descrip;

  public Trading(string trade_user, string trade_item, string trade_item_descrip)
  {
    Trade_User = trade_user;
    Trade_Item = trade_item;
    Trade_Item_Descrip = trade_item_descrip;
  }
}