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

    <Modal id="editAccount-form">
      <template #header>Edit Account</template>
      <template #body>
        <AccountForm />
      </template>
    </Modal>

    <Modal id="keep-details">
      <template #header>{{ activeKeep.name }}</template>
      <template #body>
        <KepModal />
      </template>
    </Modal>

    <Modal id="vault-details">
      <template #header>{{ activeKeep.name }}</template>
      <template #body>
        <VaultModal />
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
      activeKeep: computed(() => AppState.activeKeep),
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

// main {
//   overflow: hidden;
// }
</style>
