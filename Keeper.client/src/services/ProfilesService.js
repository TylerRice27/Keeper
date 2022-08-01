import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
class ProfilesService {

    async getProfile(id) {
        const res = await api.get('api/profiles/' + id)
        AppState.activeProfile = res.data
    }

    async getUsersVaults(profileId) {
        const res = await api.get(`api/profiles/${profileId}/vaults`)
        logger.log('User vaults', res.data)
        AppState.vaults = res.data
    }

}


export const profilesService = new ProfilesService()