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
      <h5 class="text-light d-flex justify-content-between keep-text">
        {{ keep.name }}
        <!-- <a href="Profile"> -->
        <img
          class="profile-pic rounded-pill"
          @click.stop="goToProfile"
          :title="keep.creator?.name"
          :src="keep.creator?.picture"
          alt=""
        />
        <!-- </a> -->
      </h5>
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
          if (!props.keep?.vaultKeepId) {

            Modal.getOrCreateInstance(document.getElementById('keep-details')).show()
          }
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
.profile-pic {
  height: 38px;
  width: 38px;
}
.kep-hover {
  transition: all 0.4s ease-in-out;
}
.keep-text {
  text-shadow: 3px 1px black;
}

.kep-hover:hover {
  transform: scale(1);
}
</style>