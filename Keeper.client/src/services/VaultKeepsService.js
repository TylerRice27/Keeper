import { AppState } from "../AppState"
import { router } from "../router"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
import { api } from "./AxiosService"


class VaultKeepsService {

    async getKeepsInVaults(vaultId) {
        try {

            const res = await api.get(`api/vaults/${vaultId}/keeps`)
            logger.log('Get Keeps in this Vault', res.data)
            AppState.vaultKeeps = res.data

        } catch (error) {

            router.push({ name: 'Home' })
            Pop.toast(error, "error")
        }


    }

    async createVaultKeep(keepId, vaultId) {
        let data = {
            vaultId: vaultId,
            keepId: keepId
        }
        const res = await api.post('api/vaultkeeps', data)
        logger.log('Create keep in a Vault', res.data)
        AppState.vaultKeeps.push(res.data)
        AppState.activeKeep.kept++
        return res.data
    }

    async removeVaultKeep(id) {
        const res = await api.delete('api/vaultkeeps/' + id)
        logger.log('Delete this vaultkeep', res.data)
    }


}

export const vaultKeepsService = new VaultKeepsService()