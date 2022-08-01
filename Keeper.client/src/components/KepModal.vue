<template>
  <!-- <template #modal-title>{{ activeKeep.name }}</template> -->
  <div class="component" id="keep-details">
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
        <div class="col-md-12 d-flex justify-content-evenly dropdown pb-2">
          <button
            class="btn btn-primary dropdown-toggle"
            type="button"
            data-bs-toggle="dropdown"
            aria-expanded="false"
          >
            Add to a Vault
          </button>
          <ul class="dropdown-menu">
            <li><a class="dropdown-item" href="#">Action</a></li>
            <li><a class="dropdown-item" href="#">Another action</a></li>
            <li><a class="dropdown-item" href="#">Something else here</a></li>
          </ul>
          <i @click="deleteKeep" class="mdi mdi-delete text-danger fs-4"></i>
          <!-- 
          <img class="profile-picture" :src="activeKeep.creator.picture" />
          <span class="p-2">{{ activeKeep.creator.name }}</span> -->
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

export default {
  setup(props) {
    const keep = reactive({ keepId: '' })
    const route = useRoute()

    return {
      keep,
      activeKeep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account),


      async deleteKeep() {
        try {
          const res = await keepsService.deleteKeep(route.params.keepId)
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