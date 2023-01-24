import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

import { Recipe } from "../models/Recipe.js";


class RecipesService {



  async getRecipes() {
    const res = await api.get('api/recipes')
    AppState.recipes = res.data
    // AppState.recipes.forEach(r => {
    //   if (r.id = AppState.myFavorites.recipeId) {
    //     r.liked = true
    //   }
    // })
  }

  async createRecipe(body) {
    const res = await api.post('api/recipes', body)
    logger.log(res.data)
    AppState.recipes.push(res.data)
    AppState.myRecipes.push(res.data)
    return res.data
  }

  async searchCategory(query) {
    const res = await api.get("api/recipes")
    logger.log(res.data)
    AppState.recipes = res.data
    AppState.recipes = AppState.recipes.filter((r) => r.category.toString().toUpperCase().includes(query.toUpperCase()))
  }
  async getDetials(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}`)
    AppState.activeRecipe = res.data
  }
  async deleteRecipe(recipeId) {
    await api.delete(`api/recipes/${recipeId}`);
    let recipe = AppState.recipes.findIndex((r) => r.id == recipeId);
    AppState.recipes.splice(recipe, 1);
  }
}








export const recipesService = new RecipesService();