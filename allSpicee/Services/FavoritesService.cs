namespace allSpicee.Services;

public class FavoritesService
{
  private readonly FavoritesRepository _repo;
  private readonly RecipesService _recipesService;
  public FavoritesService(FavoritesRepository repo, RecipesService recipesService)
  {
    _repo = repo;
    _recipesService = recipesService;
  }


  internal FavoritesModel Create(FavoritesModel favData)
  {
    Recipe recipe = _recipesService.GetOne(favData.recipeId, favData.accountId);

    FavoritesModel favorite = _repo.Create(favData);

    return favorite;
  }



  internal List<myRecipe> GetFavs(string accountId)
  {
    List<myRecipe> myFav = _repo.GetFavs(accountId);
    return myFav;
  }


  internal string Remove(int id, string userId)
  {
    FavoritesModel original = _repo.GetOne(id);
    if (original == null)
    {
      throw new Exception("not favirote to Delete at that id");
    }
    if (original.accountId != userId)
    {
      throw new Exception("Nacho favirote");
    }
    _repo.Remove(id);
    return $"favirote at {id} was removed";
  }
}
