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
        AppState.activeKeep = keep
        const res = await api.get(`api/keeps/${keep.id}`)
        logger.log("open this keep modal", res.data)


    }

    async createKeep(body) {
        const res = await api.post('api/keeps', body)
        logger.log('Create a Keep', res.data)
        AppState.keeps.push(res.data)
        return res.data

    }



}


export const keepsService = new KeepsService()