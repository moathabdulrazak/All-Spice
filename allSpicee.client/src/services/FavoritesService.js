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
    const res = await api.post("api/favorites", recipe);
    logger.log(res.data)
    this.getFavorites()
    // AppState.favorites.push(res.data)

  }

  async removeFav(likedId) {
    const res = await api.delete(`api/favorites/${likedId}`);
    let index = AppState.favorites.findIndex(f => f.favoriteId == likedId)
    AppState.favorites.splice(index, 1)
    // AppState.favorites = res.data
  }
}


export const favoritesService = new FavoritesService();