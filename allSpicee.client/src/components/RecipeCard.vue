<template>
  <div @click="getDetials()">

    <div type="button" class="btn" data-bs-toggle="modal" data-bs-target="#activeModal">


      <div class="img-size elevation-5" v-bind:style="`background-image: url(' ${recipe.img}')`">
        <div class="d-flex justify-content-between">
          <h4 class="rounded  ms-1 mt-3 category text-light text-vfx">{{ recipe.category }}</h4>

        </div>

        <div class="text-light fw-bold card-color ">
          <div class="col-12">

          </div>
          <div class="pt-5 pl-1   padding-top">
            <h5 class="text2 d-flex col-10 text-vfx">{{ recipe.title }}</h5>
          </div>
        </div>
      </div>
    </div>
    <div class="pt-1 px-3">
      <button v-if="!liked" @click="favRecipe()" class=" mdi btn text-light fs-5 text-vfx mdi-heart-outline"></button>
      <button v-else @click="removeFav(liked.favoriteId)" class=" mdi btn text-danger text-vfx fs-5 mdi-heart"></button>
      <button title="delete event" class=" btn btn-outline btn-danger mdi mdi-delete"
        v-if="recipe?.creatorId == account.id" @click="deleteRecipe"></button>
      <img class="img-fluid img-vfx px-2 p-1" :src="recipe.creator?.picture" alt="" srcset="">
    </div>
  </div>

</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import { ingrediantService } from "../services/IngrediantService.js";
import { favoritesService } from "../services/FavoritesService.js";
import { Modal } from "bootstrap";
import ActiveModal from "./ActiveModal.vue";
export default {
  props: {
    recipe: { type: Object, required: true }
  },
  setup(props) {
    onMounted(() => {
      // console.log("[PROPS]", liked)
    })

    return {
      liked: computed(() => AppState.favorites.find((f => f.id == props.recipe.id))),
      account: computed(() => AppState.account),
      // foundMe: computed(() => AppState.favorites.find(f => f.favoriteId == props.recipe.favoriteId)),
      // fav: computed(() => AppState.favorites),
      // fav: computed(() => AppState.favorites),
      async favRecipe() {
        try {
          let recipe = { recipeId: props.recipe.id }
          await favoritesService.favRecipe(recipe)
          Pop.success("added to favorites")
        } catch (error) {
          Pop.error(error)
        }
      },
      async removeFav(likedId) {
        try {
          debugger
          const yes = await Pop.confirm();
          if (!yes) {
            return;
          }
          await favoritesService.removeFav(likedId)
          Pop.success("removed from favorites")
        } catch (error) {
          Pop.error(error)
        }
      },

      async getDetials() {
        try {


          await recipesService.getDetials(props.recipe.id)

          this.getIngredients()
        } catch (error) {
          Pop.error(error)
        }
      },

      async getIngredients() {
        try {
          await ingrediantService.getIngredients(props.recipe.id);
        }
        catch (error) {
          Pop.error(error);
        }
      },
      async deleteRecipe() {
        try {
          await recipesService.deleteRecipe(props.recipe.id)
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  }
};
</script>


<style lang="scss" scoped>
.img-size {
  height: 30vh;
  width: 50vh;
  position: center;
  background-position: center;
  background-size: cover;
}

.card-color {
  // height: 20vh;
  // background-color: rgb(51 27 61 / 14%);
  // backdrop-filter: blur(10px);

}

.img-vfx {
  height: 6vh;
}

.text2 {
  // background-color: rgba(39, 20, 47, 0.14);
  // backdrop-filter: blur(10px);
}

.text-vfx {
  background-color: rgba(39, 20, 47, 0.14);
  backdrop-filter: blur(10px);
}

.padding-top {
  padding-top: 100%;
  transform: translateY(105px);
}

.img-size:hover {
  transform: scale(1.05);
  box-shadow: solid black 10em;
}
</style>