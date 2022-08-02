<template>
  <!-- <template #modal-title>{{ activeKeep.name }}</template> -->
  <div class="component" id="keep-details">
    <div class="row text-center">
      <div class="col-md-4">
        <img
          class="m-2 img-fluid"
          :src="activeKeep.img"
          :alt="activeKeep.name + ' picture'"
        />
      </div>
      <div class="col-md-6">
        <div
          class="
            pb-2
            border-bottom border-secondary
            ms-4
            d-flex
            flex-column
            justify-content-center
          "
        >
          <h3 class="mb-5 mt-5">
            {{ activeKeep.name }}
          </h3>
          <p>{{ activeKeep.description }}</p>
        </div>
      </div>
      <!-- Maybe put an offset here later -->
      <div class="row-reverse">
        <div
          class="col-md-12 d-flex offset-2 justify-content-evenly dropdown pb-2"
        >
          <button
            class="btn btn-primary dropdown-toggle"
            type="button"
            data-bs-toggle="dropdown"
            aria-expanded="false"
          >
            Add to a Vault
          </button>
          <ul class="dropdown-menu">
            <li>
              <a
                v-for="v in vaults"
                :key="v.id"
                :vault="v"
                class="dropdown-item"
                href="#"
                >{{ v.name }}</a
              >
            </li>
          </ul>
          <i
            @click="deleteKeep(activeKeep.id)"
            class="mdi mdi-delete text-danger fs-4"
          ></i>
          <div>
            <img class="profile-picture" :src="activeKeep.creator?.picture" />
            <span class="p-2">{{ activeKeep.creator?.name }}</span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
  


<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'
import { useRoute } from 'vue-router'
import { keepsService } from '../services/KeepsService.js'
import { vaultKeepsService } from '../services/VaultKeepsService'

export default {
  setup(props) {
    const keep = reactive({ keepId: '' })
    const route = useRoute()

    return {
      keep,
      activeKeep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults),


      async createVaultKeep(id) {
        try {

          const res = await vaultKeepsService.createVaultKeep(id)
        } catch (error) {
          Pop.toast(error.message)
          logger.error(error)
        }
      },


      async deleteKeep(id) {
        try {

          const res = await keepsService.deleteKeep(id)
        } catch (error) {
          Pop.toast(error.message)
          logger.error(error)
        }
      }

    }
  }
}
</script>
<style scoped>
img {
  width: 100%;
  object-fit: cover;
}

.profile-picture {
  width: 50px;
  height: 50px;
}

.reviews {
  max-height: 30vh;
}
</style>