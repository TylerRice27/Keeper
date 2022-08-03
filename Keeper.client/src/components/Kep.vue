<template>
  <!-- justify-content-end -->
  <!-- put the words on the bottom -->
  <div
    class="
      p-2
      kep-hover
      card
      elevation-3
      bg-secondary
      selectable
      lighten-20
      d-flex
      justify-content-end
    "
    @click="setActive"
    :style="`background-image: url(${keep.img});`"
  >
    <div class="">
      <h6 class="text-light d-flex justify-content-between">
        {{ keep.name }}
        <img
          class="profile-pic rounded-pill"
          @click.stop="goToProfile"
          :src="keep.creator?.picture"
          alt=""
        />
      </h6>
    </div>
  </div>
</template>


<script>
import { Modal } from 'bootstrap'
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

      goToProfile() {
        Modal.getOrCreateInstance(document.getElementById('keep-details')).hide()
        router.push({ name: "Profile", params: { id: props.keep.creator.id } })

      },



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
  //   display: flex;
  //   align-items: f;
  transition: all 0.4s ease-in-out;
}

.kep-hover:hover {
  transform: scale(1);
}
</style>