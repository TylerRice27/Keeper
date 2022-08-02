<template>
  <div class="mt-5 masonry-with-columns">
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
body {
  margin: 0;
  padding: 1rem;
}

.masonry-with-columns {
  columns: 6 200px;
  column-gap: 1rem;
  div {
    width: 150px;
    background: #ec985a;
    color: white;
    margin: 0 1rem 1rem 0;
    display: inline-block;
    width: 100%;
    text-align: center;
    font-family: system-ui;
    font-weight: 900;
    font-size: 2rem;
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
