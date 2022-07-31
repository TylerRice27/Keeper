<template>
  <div
    data-bs-target="#keep-modal"
    data-bs-toggle="modal"
    class="m-3 p-4 card elevation-3 bg-secondary selectable lighten-20"
    @click="setActive"
    :style="`background-image: url(${keep.img});`"
  >
    <div class="d-flex justify-content-between align-items-end">
      <h6 class="text-light">
        {{ keep.name }}
      </h6>
      <div>
        <img
          class="profile-pic rounded-pill"
          :src="keep.creator.picture"
          alt=""
        />
      </div>
    </div>
  </div>
</template>


<script>
import { keepsService } from '../services/KeepsService'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
export default {

  props: { keep: { type: Object, required: true } },
  setup(props) {
    return {
      async setActive() {
        try {
          keepsService.setActive(props.keep)
        } catch (error) {
          Pop.toast("Something went wrong", "error")
          logger.error(error)
        }

      }
    }
  }
}
</script>


<style lang="scss" scoped>
// .card {
//   height: 30vh;
// }

.profile-pic {
  height: 38px;
  width: 38px;
}
</style>