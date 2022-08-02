<template>
  <div class="container-fluid">
    <!-- <div class="row"> -->
    <div class="d-flex col-md-12 mt-4">
      <img class="rounded m-3 img-fluid logo" :src="profile.picture" alt="" />
      <div class="mt-3">
        <h1 class="p-1">{{ profile.name }}</h1>
        <h3 class="p-1">Vaults: {{ profileVaults.length }}</h3>
        <h3 class="p-1">Keeps: {{ profileKeeps.length }}</h3>
      </div>
    </div>
    <!-- </div> -->
    <div class="row">
      <div class="col-md-12 mt-5 d-flex">
        <h1>Vaults</h1>
        <i
          @click="createVault"
          data-bs-toggle="modal"
          data-bs-target="#create-vault"
          class="mdi mdi-plus fs-1 text-primary selectable"
        ></i>
      </div>
    </div>
    <div class="row">
      <Vault v-for="v in profileVaults" :key="v.id" :vault="v" />
    </div>
    <!-- <div v-else="v.creatorId != account.id" class="row">
      <Vault v-for="v in myVaults" :key="v.id" :vault="v" />
    </div> -->
    <div class="row">
      <div class="col-md-12 mt-5 d-flex">
        <h1>Keeps</h1>
        <i
          @click="createVault"
          data-bs-toggle="modal"
          data-bs-target="#create-keep"
          class="mdi mdi-plus fs-1 text-primary selectable"
        ></i>
      </div>
    </div>
    <div class="masonry-with-columns">
      <Kep
        data-bs-toggle="modal"
        data-bs-target="#keep-details"
        v-for="k in profileKeeps"
        :key="k.id"
        :keep="k"
      />
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
import { accountService } from '../services/AccountService';



export default {
  name: 'Profile',
  //   components: { Keep },
  setup(props) {
    const route = useRoute();
    onMounted(async () => {
      try {
        await profilesService.getProfile(route.params.id)
        // if (route.params.id != AppState.account.id) {
        await profilesService.getUsersVaults(route.params.id)
        await profilesService.getUsersKeeps(route.params.id)
        // } else {
        //   await accountService.getMyVaults(route.params.id)
        //   await profilesService.getUsersKeeps(route.params.id)

        // }

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
      profileKeeps: computed(() => AppState.profileKeeps),
      profileVaults: computed(() => AppState.profileVaults),
      myVaults: computed(() => AppState.myVaults),
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

.masonry-with-columns {
  columns: 4 200px;
  column-gap: 1rem;
  div {
    width: 150px;
    background: #ec985a;
    color: white;
    margin: 0 1rem 1rem 0;
    display: inline-block;
    width: 100%;
    text-align: center;
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