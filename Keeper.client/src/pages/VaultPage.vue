<template>
  <div class="container-fluid">
    <div class="">
      <div class="col-md-12 d-flex justify-content-between mt-4">
        <h1 class="p-1">{{ vault.name }}</h1>
        <button
          v-show="vault.creatorId == account.id"
          @click="deleteVault"
          class="btn btn-secondary me-3"
        >
          Delete Vault
        </button>
      </div>
      <p class="p-1 m-3">Keeps: {{ vaultKeeps.length }}</p>
    </div>
    <!-- <div v-for="v in vaultKeeps" :key="v.id"> -->
    <div class="mt-5 masonry-with-columns">
      <Kep
        v-for="v in vaultKeeps"
        :key="v.id"
        :keep="v"
        data-bs-toggle="modal"
        data-bs-target="#vault-details"
      />
    </div>
    <!-- </div> -->
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core';
import { useRoute, useRouter } from 'vue-router'
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import { vaultKeepsService } from '../services/VaultKeepsService'
import { AppState } from '../AppState';
import { vaultsService } from '../services/VaultsService';

export default {
  name: 'Vault',
  setup(props) {
    const router = useRouter();
    const route = useRoute();
    onMounted(async () => {

      try {

        await vaultKeepsService.getKeepsInVaults(route.params.id)
        await vaultsService.getThisVault(route.params.id)
        // if (vault.creator.id == account.id || vault.isPrivate == false) {

        //   router.push({ name: "Home" })
        // }
      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }
    })
    return {
      vaultKeeps: computed(() => AppState.vaultKeeps),
      vault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account),


      async deleteVault() {
        try {
          if (await Pop.confirm('Delete Vault?', 'are you sure you want to delete?', 'info', 'Yes Delete')) {
            await vaultsService.deleteVault(route.params.id)
            Pop.toast("Vault Deleted")
          }
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      }

    }
  }
}
</script>



<style scoped lang="scss">
body {
  margin: 0;
  padding: 1rem;
}

.masonry-with-columns {
  columns: 4 200px;
  column-gap: 1rem;
  div {
    width: 150px;
    background: #ec985a;
    color: white;
    margin: 0 1rem 1rem 0;
    display: inline-block;
    width: 100%;
    text-align: center;
  }
  @for $i from 1 through 36 {
    div:nth-child(#{$i}) {
      $h: (random(400) + 100) + px;
      height: $h;
      line-height: $h;
    }
  }
}
</style>
