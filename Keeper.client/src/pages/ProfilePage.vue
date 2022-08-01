<template>
  <div class="container-fluid">
    <div class="row">
      <div class="d-flex col-md-12 mt-4">
        <img class="rounded m-3 img-fluid logo" :src="profile.picture" alt="" />
        <div class="mt-3">
          <h1 class="p-1">{{ profile.name }}</h1>
          <h3 class="p-1">Vaults:{{ vaults.view }}</h3>
          <h3 class="p-1">Keeps:{{ keeps.kept }}</h3>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-md-12 m-3 mt-5 d-flex">
        <h1>Vaults</h1>
        <i class="mdi mdi-plus fs-1 text-primary"></i>
      </div>
    </div>
    <div class="row">
      <Vault v-for="v in vaults" :key="v.id" :vault="v" />
    </div>
    <div class="row">
      <div class="col-md-12 m-3 mt-5 d-flex">
        <h1>Keeps</h1>
        <i class="mdi mdi-plus fs-1 text-primary"></i>
      </div>
    </div>
    <div class="masonry-with-flex">
      <Kep v-for="k in keeps" :key="k.id" :keep="k" />
    </div>
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
import { keepsService } from '../services/KeepsService';



export default {
  //   components: { Keep },
  setup(props) {
    const route = useRoute();
    onMounted(async () => {
      try {

        await profilesService.getProfile(route.params.id),
          await profilesService.getUsersVaults(route.params.id),
          await profilesService.getUsersKeeps(route.params.id)

        //   await keepsService.getAll()
      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }


    })
    return {
      account: computed(() => AppState.account),
      profile: computed(() => AppState.activeProfile),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults)

    };
  }
}
</script>


<style lang="scss" scoped>
body {
  margin: 0;
  padding: 1rem;
}
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