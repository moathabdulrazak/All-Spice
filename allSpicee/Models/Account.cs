namespace allSpicee.Models;

public class Account
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Picture { get; set; }
}
public class favoritesVueModel : Account
{
  public int RecipeFavoriteId { get; set; }
}