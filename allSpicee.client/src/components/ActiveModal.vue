<template>



  <!-- Modal -->
  <div class="modal fade" id="activeModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">{{ recipe?.title }}</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <div class="row d-flex">
            <div class=" ">
              <h5 class="text-center">{{ recipe?.title }}</h5>
              <h6>{{ recipe?.category }}</h6>
            </div>
            <img class="img-fluid img-size" :src="recipe?.img" alt="">
            <div class="col-6 d-flex">
              <p> instructions: {{ recipe?.instructions }}</p>
            </div>
          </div>
        </div>
        <form @submit.prevent="addIngredient" v-if="account.id == recipe?.creatorId">
          <div class="form-floating mb-3 elevation-5">
            <input v-model="editable.quantity" type="text" required class="form-control" id="name"
              placeholder="quantity">
            <label for="quantity">quantity</label>
          </div>
          <div class="form-floating mb-3 elevation-5">
            <input v-model="editable.name" type="text" required class="form-control" id="name" placeholder="name">
            <label for="name">name</label>
          </div>
          <button type="submit" class="btn btn-primary">create</button>
        </form>
        <h1>recipe ingredients</h1>
        <div class="card" v-for="i in ingredients">
          <IngredientCard :ingredient="i" />
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary">Save changes</button>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { ingrediantService } from "../services/IngrediantService.js";
import Pop from "../utils/Pop.js";
import { Recipe } from "../models/Recipe.js";
import IngredientCard from "./IngredientCard.vue";
export default {
  props: {
    recipe: {
      type: Recipe,
    }
  },
  setup(props) {
    const editable = ref({});
    // onMounted(() => {
    //   getIngredients();
    // });
    return {
      editable,
      recipe: computed(() => AppState.activeRecipe),
      ingredients: computed(() => AppState.ingredients),
      account: computed(() => AppState.account),
      async addIngredient() {
        try {
          debugger;
          editable.value.recipeId = AppState.activeRecipe.id;
          await ingrediantService.addIngredient(editable.value);
          editable.value = {};
        }
        catch (error) {
          Pop.error(error);
        }
      },

    };
  },
  components: { IngredientCard }
};
</script>


<style lang="scss" scoped>
.img-size {
  height: 50vh;
}
</style>