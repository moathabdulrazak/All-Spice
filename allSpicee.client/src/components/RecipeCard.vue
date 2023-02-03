<template>
  <div>

    <!-- <div type="button" class="btn" data-bs-toggle="modal" data-bs-target="#activeModal">


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
    </div> -->
    <div class="card">
      <figure class="card__thumb">
        <img :src="recipe.img" alt="" class="card__image">
        <figcaption class="card__caption">
          <h2 class="card__title">{{ recipe.title }}</h2>
          <p class="card__snippet">{{ recipe.category }}.</p>
          <button data-bs-toggle="modal" data-bs-target="#activeModal" href=""
            class="btn btn-outline bg-light  text-dark" @click="getDetials()">Read more</button>
        </figcaption>
      </figure>
    </div>

    <div class="d-flex">
      <div class="pt-1 px-3 d-flex">
        <button v-if="!liked" @click="favRecipe()"
          class=" mdi btn text-light fs-5 text-vfx mdi-heart-outline  text-dark d-flex"></button>
        <button v-else @click="removeFav(liked.favoriteId)"
          class=" mdi btn text-danger text-vfx fs-5 mdi-heart"></button>
        <div class="pt-1">
          <h4 class="text-end">{{ recipe.calcFavCount }}</h4>
        </div>
        <button title="delete event" class=" btn btn-outline btn-danger mdi mdi-delete d-flex"
          v-if="recipe?.creatorId == account.id" @click="deleteRecipe"></button>
        <img class="img-fluid img-vfx px-2 p-1 d-flex" :src="recipe.creator?.picture" alt="" srcset="">
      </div>
    </div>
  </div>
  <div>
    <div class="share d-flex px-3">
      <h6 class="pt-2">share?</h6>
      <div class="share-container d-flex p-1">
        <div>
          <a class="share-button share-button-twitter" href="https://twitter.com/" target="https://twitter.com/">
            <i class="fa fa-twitter" aria-hidden="true"></i>
            <span class="mdi mdi-twitter fs-5"></span>
          </a>
        </div>
        <div>
          <a class="share-button share-button-facebook" href="https://www.facebook.com/"
            target="https://www.facebook.com/">
            <i class="fa fa-facebook" aria-hidden="true"></i>
            <span class="mdi mdi-facebook fs-5"></span>
          </a>
        </div>
        <div class="share-button-hide">
          <a class="share-button share-button-whatsapp" href="https://www.instagram.com/"
            target="https://www.instagram.com/">
            <i class="fa fa-whatsapp" aria-hidden="true"></i>
            <span class="mdi mdi-instagram fs-5"></span>
          </a>
        </div>
      </div>
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

.img-vfx {
  height: 5vh;
}

$desktop: 1024px;

@mixin breakpoint($point) {
  @if $point ==desktop {
    @media (min-width: $desktop) {
      @content;
    }
  }
}

html {
  box-sizing: border-box;
  font-size: 62.5%;

  *,
  *:before,
  *:after {
    box-sizing: inherit;
  }
}

body {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 100vw;
  height: 100vh;
  background-color: #e6e6e6;
}

.container {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  width: 100%;
  margin: 20px 0 80px;
}


.card {
  // width: 300px;
  // margin: 10px;
  // background-color: none !important;
  // box-shadow: none !important;
  background-color: var(--bs-card-bg) none !important;
  background-clip: border-box none !important;
  border: var(--bs-card-border-width) solid var(--bs-card-border-color) none !important;

  &:hover {
    .card__caption {
      top: 50%;
      transform: translateY(-50%);
    }

    .card__image {
      transform: translateY(-10px);
    }

    .card__thumb {
      &::after {
        top: 0;
      }
    }

    .card__snippet {
      margin: 20px 0;
    }
  }

  &__thumb {
    position: relative;
    max-height: 400px;
    overflow: hidden;

    @include breakpoint(desktop) {
      max-height: 500px;
    }

    &::after {
      position: absolute;
      top: 0;
      display: block;
      content: '';
      width: 100%;
      height: 100%;
      background: linear-gradient(0deg, rgba(0, 0, 0, .5) 40%, rgba(255, 255, 255, 0) 100%);
      transition: .3s;

      @include breakpoint(desktop) {
        top: calc(100% - 140px);
      }
    }
  }

  &__image {
    transition: .5s ease-in-out;
  }

  &__caption {
    position: absolute;
    top: 50%;
    z-index: 1;
    padding: 0 20px;
    color: white;
    transform: translateY(-50%);
    text-align: center;
    transition: .3s;

    @include breakpoint(desktop) {
      top: calc(100% - 110px);
      transform: unset;
    }
  }

  &__title {
    display: -webkit-box;
    max-height: 85px;
    overflow: hidden;
    font-family: 'Playfair Display', serif;
    font-size: 23px;
    line-height: 28px;
    text-shadow: 0px 1px 5px black;
    text-overflow: ellipsis;
    -webkit-line-clamp: 3;
    -webkit-box-orient: vertical;
  }

  &__snippet {
    display: -webkit-box;
    max-height: 150px;
    margin: 20px 0;
    overflow: hidden;
    font-family: 'Roboto', sans-serif;
    font-size: 16px;
    line-height: 20px;
    text-overflow: ellipsis;
    transition: .5s ease-in-out;
    -webkit-line-clamp: 5;
    -webkit-box-orient: vertical;

    @include breakpoint(desktop) {
      margin: 60px 0;
    }
  }

  &__button {
    display: inline-block;
    padding: 10px 20px;
    color: white;
    border: 1px solid white;
    font-family: 'Roboto', sans-serif;
    font-size: 12px;
    text-transform: uppercase;
    text-decoration: none;
    transition: .3s;

    &:hover {
      color: black;
      background-color: white;
    }
  }
}

.disclaimer {
  position: fixed;
  bottom: 0;
  left: 50%;
  z-index: 2;
  box-sizing: border-box;
  width: 100%;
  padding: 20px 10px;
  background-color: white;
  transform: translateX(-50%);
  font-family: 'Roboto', sans-serif;
  font-size: 14px;
  text-align: center;

  &__link {
    color: #755D87;
    text-decoration: none;
  }
}
</style>