import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
class KeepsService {

    async getAll() {
        const res = await api.get('api/keeps')
        // logger.log("get all keeps", res.data)
        AppState.keeps = res.data


    }

    async setActive(keep) {
        const res = await api.get(`api/keeps/${keep.id}`)
        logger.log("open this keep modal", res.data)


        AppState.activeKeep = keep

        keep.views++


    }

    async createKeep(body) {
        const res = await api.post('api/keeps', body)
        logger.log('Create a Keep', res.data)
        AppState.profileKeeps.unshift(res.data)
        return res.data

    }

    async deleteKeep(id) {
        const res = await api.delete('api/keeps/' + id)
        logger.log('Delete this keep', res.data)
    }


}


export const keepsService = new KeepsService()