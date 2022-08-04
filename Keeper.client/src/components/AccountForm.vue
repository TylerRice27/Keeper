<template>
  <form class="m-2" @submit.prevent="editAccount" id="editAccount-form">
    <div class="mb-3">
      <label>Account Name</label>
      <input
        class="form-control"
        v-model="editable.name"
        type="text"
        required
      />
    </div>
    <div class="mb-3">
      <label>Account Image</label>
      <input
        class="form-control"
        v-model="editable.picture"
        type="text"
        required
      />
    </div>
    <button class="btn btn-primary">Save Changes!</button>
  </form>
</template>


<script>
import { computed, ref } from '@vue/reactivity'
import { accountService } from '../services/AccountService'
import Pop from '../utils/Pop'
import { logger } from '../utils/Logger'
import { watchEffect } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { Modal } from 'bootstrap'
export default {
  setup() {
    const editable = ref({})
    watchEffect(() => {
      AppState.account;
      editable.value = { ...AppState.account };
    })
    return {
      editable,
      account: computed(() => AppState.account),
      async editAccount() {
        try {
          await accountService.editAccount(editable.value);
          Modal.getOrCreateInstance(document.getElementById("editAccount-form")).hide()
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