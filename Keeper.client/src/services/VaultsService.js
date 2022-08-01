import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"



class VaultsService {

    async createVault(body) {
        const res = await api.post('api/vaults', body)
        logger.log('Create a Vault', res.data)
        AppState.vaults.push(res.data)
        return res.data

    }



}



export const vaultsService = new VaultsService()