<template>
  <form class="m-2" @submit.prevent="createVault" id="create-vault">
    <div class="mb-3">
      <label>Title</label>
      <input
        class="form-control"
        v-model="editable.name"
        type="text"
        required
      />
    </div>
    <div class="mb-3">
      <label>Image Url</label>
      <input class="form-control" v-model="editable.img" type="text" required />
    </div>
    <div class="mb-3">
      <label>Description</label>
      <input
        class="form-control"
        v-model="editable.description"
        type="text"
        required
      />
    </div>
    <div class="mb-3">
      <input class="m-1" v-model="editable.isPrivate" type="checkbox" />
      <label class="fs-5"> Private?</label>
    </div>
    <button class="btn btn-primary">Save Changes!</button>
  </form>
</template>


<script>
import { computed, ref } from '@vue/reactivity'

import { vaultsService } from '../services/VaultsService'
import Pop from '../utils/Pop'
import { logger } from '../utils/Logger'
import { watchEffect } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { Modal } from 'bootstrap'
export default {
  setup() {
    const editable = ref({})
    watchEffect(() => {
      //   AppState.vaults;
      //   editable.value = { ...AppState.vaults };
    })
    return {
      editable,
      //   vaults: computed(() => AppState.vaults),
      async createVault() {
        try {

          await vaultsService.createVault(editable.value)
          Modal.getOrCreateInstance(document.getElementById("create-vault")).hide()
          editable.value = {}
          Pop.toast('Vault Created!')

        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
</style>