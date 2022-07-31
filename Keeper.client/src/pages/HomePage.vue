<template>
  <div class="masonry-frame">
    <div>
      <Keep v-for="k in keeps" :key="k.id" :keep="k" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import Pop from '../utils/Pop'
import { logger } from '../utils/Logger'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'

export default {
  name: 'Home',
  setup(props) {
    onMounted(async () => {
      try {
        await keepsService.getAll();
      } catch (error) {
        logger.error(error);
        Pop.toast(error.message, 'error');
      }




    });

    return {
      keeps: computed(() => AppState.keeps),

    };
  },
};
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card {
    width: 50vw;
    > img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
