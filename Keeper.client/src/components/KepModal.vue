<template>
  <!-- <template #modal-title>{{ activeKeep.name }}</template> -->
  <div class="component" id="keep-details">
    <div class="row text-center">
      <div class="col-md-4">
        <img
          class="p-1 img-fluid"
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
          <div>
            <i class="mdi mdi-eye text-primary p-2">
              <span class="m-1 text-dark">{{ activeKeep.views }}</span></i
            >
            <i class="mdi mdi-lock text-primary p-2">
              <span class="m-1 text-dark">{{ activeKeep.kept }}</span></i
            >
          </div>
          <h3 class="mb-5 text-black mt-5">
            {{ activeKeep.name }}
          </h3>
          <p class="text-start text-black">{{ activeKeep.description }}</p>
        </div>
      </div>
      <!-- Maybe put an offset here later -->
      <div class="row-reverse">
        <div
          class="
            col-md-12
            p-2
            d-flex
            offset-2
            justify-content-evenly
            dropdown
            pb-2
          "
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
                @click.prevent="createVaultKeep(activeKeep.id, v.id)"
                v-for="v in myVaults"
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
            v-show="activeKeep.creatorId == account.id"
            :title="'Delete Keep'"
            class="selectable mdi mdi-delete text-danger fs-4"
          ></i>
          <div class="pe-4">
            <img
              class="profile-picture selectable"
              :title="'Got to profile page'"
              @click="goToProfile"
              :src="activeKeep.creator?.picture"
            />
            <span class="p-2 text-dark">{{ activeKeep.creator?.name }}</span>
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
import { Modal } from 'bootstrap'
import { router } from '../router.js'

export default {
  // props: { keep: { type: Object, required: true } },
  setup(props) {
    const keep = reactive({ keepId: '' })
    const route = useRoute()

    return {
      keep,
      activeKeep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults),
      myVaults: computed(() => AppState.myVaults),
      // activeKeepViews: computed(() => AppState.activeKeep.views),


      goToProfile() {
        Modal.getOrCreateInstance(document.getElementById('keep-details')).hide()
        // if (this.activeKeep.creatorId != this.account) {
        router.push({ name: "Profile", params: { id: this.activeKeep.creator.id } })

        // }
        // router.push({ name: "Account", params: { id: this.activeKeep.creator.id } })
      },
      // async getMyVaults() {
      //   try {
      //     const res = await accountService.getMyVaults()

      //   } catch (error) {
      //     Pop.toast(error.message, 'error')
      //     logger.error(error)
      //   }
      // },

      async createVaultKeep(activeKeepId, vaultId) {
        try {

          const res = await vaultKeepsService.createVaultKeep(activeKeepId, vaultId)
          // this.activeKeep.kept++
          Pop.toast("Added to Vault", "success")
        } catch (error) {
          Pop.toast(error.message)
          logger.error(error)
        }
      },


      async deleteKeep(id) {
        try {
          if (await Pop.confirm('Delete Keep?', 'are you sure you want to delete?', 'info', 'Yes Delete')) {
            const res = await keepsService.deleteKeep(id)
            Modal.getOrCreateInstance(document.getElementById('keep-details')).hide()
            Pop.toast("Keep Deleted")
          }
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