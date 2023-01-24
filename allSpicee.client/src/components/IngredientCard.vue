<template>

<div class="col-6 ">
<h6> name: {{ ingredient.name }} quantity: {{ ingredient.quantity }}</h6>

</div>

</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
  props: {
    ingredient: { type: Object, required: true }
  },
  setup(){
  return {  }
  }
};
</script>


<style lang="scss" scoped>

</style>