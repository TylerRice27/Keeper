<template>
  <!-- justify-content-end -->
  <!-- put the words on the bottom -->
  <div
    class="
      col-md-2
      m-2
      p-4
      card
      elevation-3
      justify-content-end
      bg-secondary
      selectable
      lighten-20
    "
    @click="goToVaultPage"
    :style="`background-image: url(${vault.img});`"
  >
    <h6 class="text-light text-center mt-4">
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
        // if (vault.creatorId == account.id || vault.isPrivate == false) {

        //   router.push({ name: "Home" })
        // }
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
.card {
  height: 19vh;
}

.profile-pic {
  height: 38px;
  width: 38px;
}
</style>