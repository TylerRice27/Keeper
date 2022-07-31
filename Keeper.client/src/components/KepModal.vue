<template>
  <!-- <template #modal-title>{{ activeKeep.name }}</template> -->
  <div class="component" id="keep-details">
    <div class="row">
      <div class="col-md-4">
        <img
          class="img-fluid"
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
          <h3 class="mb-5">
            {{ activeKeep.name }}
          </h3>
          <p>{{ activeKeep.description }}</p>
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

export default {
  setup(props) {
    const keep = reactive({ keepId: '' })
    const route = useRoute()

    return {
      keep,
      activeKeep: computed(() => AppState.activeKeep),



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