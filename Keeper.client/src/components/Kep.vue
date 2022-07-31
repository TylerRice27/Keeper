<template>
  <div
    class="m-3 p-3 card elevation-3 bg-secondary lighten-20"
    :style="`background-image: url(${keep.img});`"
  >
    <h4>
      <span class="f-28">"</span><em>{{ keep.name }}</em
      ><span class="f-28">"</span>
    </h4>
    <div class="text-end">
      <img
        class="profile-pic rounded-pill"
        :src="keep.creator.picture"
        alt=""
      />
    </div>
  </div>
</template>


<script>
export default {
  props: { keep: { type: Object, required: true } },
  setup(props) {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.profile-pic {
  height: 38px;
  width: 38px;
}
</style>