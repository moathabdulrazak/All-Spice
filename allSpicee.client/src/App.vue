<template>
  <header>
    <Navbar />
  </header>
  <main class="bg-color">
    <router-view />
  </main>
  <footer class="bg-vfx text-light sticky-bottom ">
    <div class="d-flex">
      <button type="button" class=" d-flex btn mdi fs-5 mdi-food" data-bs-toggle="modal" data-bs-target="#exampleModal">
        <h3 class="px-1 ">Got a recipe?</h3>
      </button>
    </div>
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

.bg-color {
  background-color: #FFEBEE;
}

.bg-vfx {
  background-color: #3EB489;
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
