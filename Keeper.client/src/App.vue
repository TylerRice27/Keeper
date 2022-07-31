<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
    <Modal id="create-keep">
      <template #header>Create Keep</template>
      <template #body>
        <KepForm />
      </template>
    </Modal>

    <Modal id="create-vault">
      <template #header>Create Vault</template>
      <template #body>
        <VaultForm />
      </template>
    </Modal>

    <Modal id="keep-modal">
      <template #header>Create Vault</template>
      <template #body>
        <KepModal />
      </template>
    </Modal>
  </main>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
export default {
  name: 'App',
  setup() {
    return {
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
</style>
