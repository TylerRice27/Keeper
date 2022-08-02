import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class VaultKeepsService {

    async getKeepsInVaults(vaultId) {
        const res = await api.get(`api/vaults/${vaultId}/keeps`)
        logger.log('Get Keeps in this Vault', res.data)
        AppState.vaultKeeps = res.data

    }

    async createVaultKeep() {
        const res = await api.post('api/vaultkeeps' + body)
        logger.log('Create keep in a Vault', res.data)

        AppState.vaultKeeps.push(res.data)
        return res.data
    }


}

export const vaultKeepsService = new VaultKeepsService()