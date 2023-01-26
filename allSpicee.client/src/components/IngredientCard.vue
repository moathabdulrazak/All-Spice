<template>

  <div class="col-6 ">
    <h6> name: {{ ingredient.name }} quantity: {{ ingredient.quantity }}</h6>
    <button v-if="ingredient.accountId == account.id" title="delete event"
      class=" btn btn-outline btn-danger mdi mdi-delete" @click="deleteIngredient"></button>

  </div>

</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { ingrediantService } from "../services/IngrediantService.js";
export default {
  props: {
    ingredient: { type: Object, required: true }

  },
  setup(props) {
    return {
      ingredients: computed(() => AppState.ingredients),
      account: computed(() => AppState.account),
      async deleteIngredient() {
        await ingrediantService.removeIngredient(props.ingredient.id)
      }

    }
  }
};
</script>


<style lang="scss" scoped>

</style>