<template>
  <div
    class="
      m-3
      p-4
      kep-hover
      card
      elevation-3
      bg-secondary
      selectable
      lighten-20
    "
    @click="setActive"
    :style="`background-image: url(${keep.img});`"
  >
    <div class="">
      <h6 class="text-light">
        {{ keep.name }}
        <img
          class="profile-pic rounded-pill"
          :src="keep.creator.picture"
          alt=""
        />
      </h6>
    </div>
  </div>
</template>


<script>
import { useRouter } from 'vue-router'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
export default {

  props: { keep: { type: Object, required: true } },
  setup(props) {
    const router = useRouter()
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
.kep-hover {
  transition: all 0.4s ease-in-out;
}

.kep-hover:hover {
  transform: scale(1);
}
</style>