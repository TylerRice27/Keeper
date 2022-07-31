<template>
  <div class="container">
    <div class="masonry-frame">
      <div class="col-md-12">
        <Kep v-for="k in keeps" :key="k.id" :keep="k" />
      </div>
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
.masonry-frame {
  columns: 4;

  div {
    break-inside: avoid;
  }
}
</style>
