import { AppState } from "../AppState"
import { router } from "../router"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"



class VaultsService {


    async getThisVault(vaultId) {


        const res = await api.get('api/vaults/' + vaultId)

        AppState.activeVault = res.data




    }
    async createVault(body) {
        const res = await api.post('api/vaults', body)
        logger.log('Create a Vault', res.data)

        AppState.profileVaults.unshift(res.data)

        return res.data

    }

    async deleteVault(id) {
        const res = await api.delete('api/vaults/' + id)
        logger.log('Delete this vault', res.data)
        AppState.vaults = res.data

    }



}



export const vaultsService = new VaultsService()