namespace allSpicee.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;

  private readonly FavoritesService _favService;
  public AccountController(AccountService accountService, Auth0Provider auth0Provider, FavoritesService favService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _favService = favService;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("favorites")]
  [Authorize]
  public async Task<ActionResult<List<myRecipe>>>
  GetFavs()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<myRecipe> myFavorites = _favService.GetFavs(userInfo?.Id);
      return myFavorites;
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }
}
