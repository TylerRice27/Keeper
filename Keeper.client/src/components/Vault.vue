<template>
  <!-- justify-content-end -->
  <!-- put the words on the bottom -->
  <div
    class="
      col-md-2
      m-3
      p-4
      kep-hover
      card
      elevation-3
      bg-secondary
      selectable
      img-fluid
      lighten-20
      d-flex
      justify-content-end
    "
    @click="goToVaultPage"
    :style="`background-image: url(${vault.img});`"
  >
    <h6 class="text-light">
      {{ vault.name }}
    </h6>
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

  props: { vault: { type: Object, required: true } },
  setup(props) {
    const router = useRouter()
    return {

      goToVaultPage() {
        Modal.getOrCreateInstance(document.getElementById('keep-details')).hide()
        router.push({ name: "Vault", params: { id: props.vault.id } })
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
  //   align-items: flex-end;
  transition: all 4s ease-in-out;
}

.kep-hover:hover {
  transform: scale(1);
}
</style>