<template>
  <div class="masonry-with-flex">
    <Kep
      v-for="k in keeps"
      :key="k.id"
      :keep="k"
      data-bs-toggle="modal"
      data-bs-target="#keep-details"
    />
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
.masonry-with-flex {
  display: flex;

  // If I put this on I get Massive Ugly Side Scroll
  // flex-direction: column;
  flex-wrap: wrap;
  max-height: 1000px;
  .kep {
    width: 150px;
    background: #ec985a;
    color: white;
    margin: 0 1rem 1rem 0;
  }
  @for $i from 1 through 36 {
    div:nth-child(#{$i}) {
      $h: (random(400) + 100) + px;
      height: $h;
      line-height: $h;
    }
  }
}
</style>
