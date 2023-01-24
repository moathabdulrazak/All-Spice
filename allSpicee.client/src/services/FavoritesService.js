import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class FavoritesService {
  async getFavorites() {
    const res = await api.get('account/favorites')
    logger.log(res.data)
    AppState.favorites = res.data
    AppState.recipes = res.data
  }
  async favRecipe(recipe) {
    let recipeId = {};
    recipeId.recipeId = recipe.id
    const res = await api.post("api/favorites", recipeId);
    AppState.favorites.push(res.data)
    // AppState.myFavorites.push(res.data)

  }

  async removeFav(likedId) {
    const res = await api.delete(`api/favorites/${likedId}`);
    let index = AppState.favorites.findIndex(f => f.id == favoriteId)
    AppState.favorites.splice(index, 1)
    if (AppState.number) {
      AppState.recipes = AppState.recipes.filter(f => f.id != recipeId)
    }
    AppState.favorites = res.data
  }
}


export const favoritesService = new FavoritesService();