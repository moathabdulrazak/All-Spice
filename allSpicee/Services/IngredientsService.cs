

namespace allSpicee.Services;

public class IngredientsService
{

  private readonly IngredientsRepository _repo;
  private readonly RecipesService _recipeService;


  public IngredientsService(IngredientsRepository repo, RecipesService recipeService)
  {
    _repo = repo;
    _recipeService = recipeService;
  }



  internal Ingredient Create(Ingredient ingredientData)
  {
    Ingredient ing = _repo.Create(ingredientData);
    return ing;
  }






  internal string DeleteIngredient(int id, string userId)
  {
    Ingredient orignal = _repo.GetOne(id);

    if (orignal.CreatorId != userId)
    {
      throw new Exception("not ur ingredient");
    }
    _repo.DeleteIngredient(id);
    return $"ingredeint at {id} was removed";
  }






  internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
  {
    return _repo.GetIngredientsByRecipe(recipeId);
  }
}
