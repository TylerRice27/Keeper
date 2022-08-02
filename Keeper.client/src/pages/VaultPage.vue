<template>
  <div class="container-fluid">
    <div class="row">
      <div class="d-flex col-md-12 mt-4">
        <div class="mt-3">
          <h1 class="p-1">{{ vault.name }}</h1>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core';
import { useRoute } from 'vue-router'
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import { vaultKeepsService } from '../services/VaultKeepsService'
import { AppState } from '../AppState';
import { vaultsService } from '../services/VaultsService';

export default {
  name: 'Vault',
  setup(props) {
    const route = useRoute();
    onMounted(async () => {

      try {
        await vaultKeepsService.getKeepsInVaults(route.params.id)
        await vaultsService.getThisVault(route.params.id)

      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }
    })
    return {
      vaultKeeps: computed(() => AppState.vaultKeeps),
      vault: computed(() => AppState.activeVault)

    }
  }
}
</script>



<style scoped lang="scss">
</style>
