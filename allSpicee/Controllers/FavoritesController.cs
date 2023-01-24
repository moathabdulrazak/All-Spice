namespace allSpicee.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{

  private readonly FavoritesService _favService;

  private readonly Auth0Provider _auth0provider;

  public FavoritesController(FavoritesService favService, Auth0Provider auth0provider)
  {
    _favService = favService;
    _auth0provider = auth0provider;
  }

  [HttpPost]
  [Authorize]

  public async Task<ActionResult<FavoritesModel>> Create([FromBody] FavoritesModel favData)
  {
    favoritesVueModel userInfo = await _auth0provider.GetUserInfoAsync<favoritesVueModel>(HttpContext);
    favData.accountId = userInfo.Id;
    FavoritesModel favorite = _favService.Create(favData);
    return Ok(favorite);
  }


  [HttpDelete("{id}")]
  [Authorize]

  public async Task<ActionResult<string>> Remove(int id)
  {
    {
      try
      {
        Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
        string message = _favService.Remove(id, userInfo.Id);
        return Ok(message);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
