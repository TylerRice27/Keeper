<template>
  <div
    class="m-3 p-4 card elevation-3 bg-secondary lighten-20"
    :style="`background-image: url(${keep.img});`"
  >
    <div class="d-flex justify-content-between align-items-end">
      <h6 class="text-light">
        {{ keep.name }}
      </h6>
      <div>
        <img
          class="profile-pic rounded-pill"
          :src="keep.creator.picture"
          alt=""
        />
      </div>
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
// .card {
//   height: 30vh;
// }

.profile-pic {
  height: 38px;
  width: 38px;
}
</style>