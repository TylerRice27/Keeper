import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
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

  async editAccount(accountData) {
    try {

      const res = await api.put('/account', accountData)
      logger.log(res.data)
      AppState.account = res.data
      AppState.activeProfile = res.data


    } catch (error) {
      logger.error(error)
      Pop.toast(error.message, 'error')

    }

  }

  async getMyVaults() {
    try {
      const res = await api.get('/account/vaults')
      // logger.log("get all my Vaults", res.data)
      AppState.myVaults = res.data

    } catch (error) {
      logger.error(error)
      Pop.toast(error.message, 'error')
    }
  }
}

export const accountService = new AccountService()
