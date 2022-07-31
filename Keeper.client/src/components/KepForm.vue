<template>
  <form class="m-2" @submit.prevent="createKeep" id="keep-form">
    <div class="mb-3">
      <label>Keep Title</label>
      <input
        class="form-control"
        v-model="editable.title"
        type="text"
        required
      />
    </div>
    <div class="mb-3">
      <label>Keep Picture</label>
      <input class="form-control" v-model="editable.img" type="text" required />
    </div>
    <div class="mb-3">
      <label>Keep Description</label>
      <input
        class="form-control"
        v-model="editable.description"
        type="text"
        required
      />
    </div>

    <!-- <div class="mb-3">
      <label>Category</label>
      <select class="form-control" v-model="editable.category" required>
        <option value="breakfast">Breakfast</option>
        <option value="lunch">Lunch</option>
        <option value="dinner">Dinner</option>
      </select>
    </div> -->
    <button class="btn btn-primary m-1">Create Keep!</button>
  </form>
</template>


<script>
import { ref } from '@vue/reactivity'
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Pop'
import { Modal } from 'bootstrap'
export default {
  setup() {
    const editable = ref({})
    return {
      editable,


      async createKeep() {
        try {

          const keep = await keepsService.createKeep(editable.value)
          Modal.getOrCreateInstance(document.getElementById('create-keep')).hide()
          Pop.toast('Keep Created!')
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
</style>