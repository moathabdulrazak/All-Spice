import { api } from "./AxiosService.js";
import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";





class IngrediantService {

  async getIngredients(recipeId) {
    debugger
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    logger.log(res.data, "ing")
    AppState.ingredients = res.data
  }
  async addIngredient(ingredientData) {
    const res = await api.post("api/ingredients", ingredientData);
    AppState.ingredients.push(res.data)
  }

}










export const ingrediantService = new IngrediantService();