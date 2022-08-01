<template>
  <div class="container-fluid">
    {{ profile }}
  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { useRoute } from "vue-router";
import { AppState } from '../AppState';
import { onMounted } from '@vue/runtime-core';
import Pop from '../utils/Pop';
import { logger } from '../utils/Logger';
import { profilesService } from '../services/ProfilesService'



export default {
  setup(props) {
    const route = useRoute();
    onMounted(async () => {
      try {
        await profilesService.getProfile(route.params.id)
      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }


    })
    return {
      account: computed(() => AppState.account),
      profile: computed(() => AppState.activeProfile),

    };
  }
}
</script>


<style lang="scss" scoped>
</style>