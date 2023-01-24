namespace allSpicee.Repositories;

public class FavoritesRepository
{


  private readonly IDbConnection _db;

  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal FavoritesModel Create(FavoritesModel favData)
  {
    string sql = @"
INSERT INTO favorites
(recipeId, accountId)
VALUES
(@recipeId, @accountId);
SELECT LAST_INSERT_ID();
";
    int id = _db.ExecuteScalar<int>(sql, favData);
    favData.Id = id;
    return favData;
  }


  internal FavoritesModel GetOne(int id)
  {
    string sql = @"
        SELECT
        *
        FROM favorites
        WHERE id = @id;
        ";
    return _db.Query<FavoritesModel>(sql, new { id }).FirstOrDefault();
  }
  internal List<myRecipe> GetFavs(string accountId)
  {
    string sql = @"
    SELECT
    rc.*,
    fm.*,
    cr.*
    FROM favorites fm
    JOIN recipes rc ON rc.id = fm.recipeId
    JOIN accounts cr ON rc.creatorId = cr.id
    WHERE fm.accountId = @accountId;
    ";
    List<myRecipe> myFav = _db.Query<myRecipe, FavoritesModel, Account, myRecipe>(sql, (rc, fm, cr) =>
    {
      rc.FavoriteId = fm.Id;
      rc.Creator = cr;
      return rc;
    }, new { accountId }).ToList();
    return myFav;

  }

  internal void Remove(int id)
  {
    {
      string sql = @"
    DELETE FROM favorites
    WHERE id = @id;
    ";
      _db.Execute(sql, new { id });
    }
  }
}
