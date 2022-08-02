<template>
  <div class="container-fluid">
    <div class="row">
      <div class="d-flex col-md-12 mt-4">
        <div class="mt-3">
          <h1 class="p-1">{{ vault.name }}</h1>
          <p class="p-1">Keeps: {{ vaultKeeps.length }}</p>
        </div>
      </div>
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
body {
  margin: 0;
  padding: 1rem;
}

.masonry-with-columns {
  columns: 6 200px;
  column-gap: 1rem;
  div {
    width: 150px;
    background: #ec985a;
    color: white;
    margin: 0 1rem 1rem 0;
    display: inline-block;
    width: 100%;
    text-align: center;
    font-family: system-ui;
    font-weight: 900;
    font-size: 2rem;
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
