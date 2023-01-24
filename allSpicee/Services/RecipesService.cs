
namespace allSpicee.Services;

public class RecipesService
{

  private readonly RecipesRepository _repo;

  public RecipesService(RecipesRepository repo)
  {
    _repo = repo;
  }



  internal Recipe Create(Recipe recipeData)
  {
    Recipe recipe = _repo.Create(recipeData);
    return recipe;
  }

  internal List<Recipe> Get()
  {
    List<Recipe> recipes = _repo.Get();
    return recipes;

  }

  internal Recipe GetOne(int id, string userId)
  {
    Recipe recipe = _repo.GetOne(id);
    if (recipe == null)
    {
      throw new Exception("no chore at dis id bruh");
    }

    return recipe;
  }
  internal Recipe Edit(Recipe recipeEdit, int id, string userId)
  {
    Recipe original = GetOne(id, userId);
    original.Title = recipeEdit.Title ?? original.Title;
    original.Instructions = recipeEdit.Instructions ?? original.Instructions;
    original.Img = recipeEdit.Img ?? original.Img;
    original.Category = recipeEdit.Category ?? original.Category;
    original.CreatorId = recipeEdit.CreatorId ?? original.CreatorId;

    bool edited = _repo.Edit(original);
    if (edited == false)
    {
      throw new Exception("recipe not edited");
    }
    return original;
  }
  internal string Remove(int id, string userId)
  {
    Recipe original = GetOne(id, userId);
    if (original.CreatorId != userId)
    {
      throw new Exception("not your recipe idiot");
    }
    _repo.Remove(id);
    return $"{original.Title} was removed";
  }
}
