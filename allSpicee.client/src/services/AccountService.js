import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  // async getMyRecipes() {
  //   const res = await api.get('account/recipes')
  //   AppState.myRecipes = res.data
  //   AppState.recipes = res.data
  // }
}

export const accountService = new AccountService()
