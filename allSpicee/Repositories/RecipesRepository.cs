namespace allSpicee.Repositories;

public class RecipesRepository
{
  private readonly IDbConnection _db;

  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }


  internal Recipe Create(Recipe recipeData)
  {
    string sql = @"
INSERT INTO recipes
(title, category, img, instructions, creatorId)
VALUES 
(@title, @category, @img, @instructions, @creatorId);
SELECT LAST_INSERT_ID();
";
    int id = _db.ExecuteScalar<int>(sql, recipeData);
    recipeData.Id = id;
    return recipeData;

  }



  internal List<Recipe> Get()
  {
    string sql = @"
    SELECT
    rc.*,
    ac.*
FROM recipes rc
JOIN accounts ac on ac.id = rc.creatorId;
    ";
    List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
    {
      recipe.Creator = account;
      return recipe;

    }).ToList();
    return recipes;

  }

  internal Recipe GetOne(int id)
  {
    string sql = @"
    SELECT
    rc.*,
    ac.*
    FROM recipes rc
    JOIN accounts ac ON ac.id = rc.creatorId
    WHERE rc.id = @id;
    ";
    return _db.Query<Recipe, Account, Recipe>(sql, (Recipe, account) =>
      {
        Recipe.Creator = account;
        return Recipe;
      }, new { id }).FirstOrDefault();
  }
  internal void Remove(int id)
  {
    string sql = @"
    DELETE FROM recipes
    WHERE id = @id;
    ";
    _db.Execute(sql, new { id });

  }
  internal bool Edit(Recipe original)
  {
    string sql = @"
    UPDATE recipes
      SET
      title = @title,
      instructions = @instructions,
      img = @img,
      category = @category,
      creatorId = @creatorId
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, original);
    return rows > 0;
  }
}
