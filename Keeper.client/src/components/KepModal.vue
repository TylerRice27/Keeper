<template>
  <!-- <Modal id="keep-modal"> -->
  <!-- <template #modal-title>{{ keep.name }}</template>
  <template #modal-body> -->
  <div class="container">
    <div class="row">
      <div class="col-md-6">
        <img
          class="img-fluid"
          :src="keep.picture"
          :alt="keep.name + ' picture'"
        />
      </div>
      <div class="col-md-6">
        <div class="ms-4 d-flex flex-column justify-content-center">
          <h3 class="pb-2 border-bottom border-secondary">
            {{ keep.name }}
            <small>
              <kbd class="">{{ keep.category }}</kbd></small
            >
          </h3>
          <p>{{ keep.location }}</p>
        </div>
      </div>
    </div>
  </div>
  <!-- // </template> -->
  <!-- </Modal> -->
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'

export default {
  setup() {
    const keep = reactive({})

    return {
      keep,
      restaurant: computed(() => AppState.activeKeep),


    }
  }
}
</script>
<style scoped>
img {
  width: 100%;
  object-fit: cover;
}

.reviews {
  max-height: 30vh;
}
</style>