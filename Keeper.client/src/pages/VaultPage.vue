<template>
  <div class="container-fluid">
    <div class="row">
      <div class="d-flex col-md-12 mt-4">
        <div class="mt-3">
          <h1 class="p-1">{{ vault.name }}</h1>
        </div>
        {{ vaults }}
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

export default {
  name: 'VaultPage',
  setup(props) {
    const route = useRoute();
    onMounted(async () => {

      try {
        await vaultKeepsService.getKeepsInVaults(route.params.id)

      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }
    })
    return {
      keeps: computed(() => AppState.keeps),
      vault: computed(() => AppState.vaults),

    }
  }
}
</script>



<style scoped lang="scss">
</style>
