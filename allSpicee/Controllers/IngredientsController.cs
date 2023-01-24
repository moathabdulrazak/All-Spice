
namespace allSpicee.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{

  private readonly IngredientsService _ingredientsService;

  private readonly Auth0Provider _auth0Provider;

  public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0Provider)
  {
    _ingredientsService = ingredientsService;
    _auth0Provider = auth0Provider;
  }



  [HttpPost]
  [Authorize]

  public async Task<ActionResult<Ingredient>> Create([FromBody] Ingredient ingredientData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      ingredientData.CreatorId = userInfo.Id;
      Ingredient ingredient = _ingredientsService.Create(ingredientData);
      ingredient.Creator = userInfo;
      return Ok(ingredient);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpDelete("{id}")]
  [Authorize]
  public async Task<ActionResult<string>> DeleteIngredient(int id)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);


      _ingredientsService.DeleteIngredient(id, userInfo.Id);
      return Ok("Ingredient deleted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
