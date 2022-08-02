<template>
  <div class="component" id="vault-details">
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
            v-show="activeKeep.creatorId == account.id"
            @click="removeVaultKeep(activeKeep.vaultKeepId)"
            class="btn btn-secondary"
            type="button"
          >
            Remove From Vault
          </button>

          <div>
            <img
              class="profile-picture"
              @click="goToProfile"
              :src="activeKeep.creator?.picture"
            />
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
import { accountService } from '../services/AccountService.js'
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

      goToProfile() {
        Modal.getOrCreateInstance(document.getElementById('vault-details')).hide()
        router.push({ name: "Profile", params: { id: this.activeKeep.creator.id } })
      },

      async removeVaultKeep(id) {

        try {
          if (await Pop.confirm('Remove Vault?', 'are you sure you want to remove?', 'info', 'Yes Remove')) {
            const res = await vaultKeepsService.removeVaultKeep(id)
            Pop.toast("Keep Removed")
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