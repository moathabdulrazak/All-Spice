<template>
  <!-- <div class="row container-fluid">
    <div class="pt-2 p-3 mx-2">
      <img class="col-12 justify-content-center elevation-5" src="src\assets\unsplash_pqJ21tErTgI.png" alt="">
      <Login />
    </div>
  </div> -->

  <div class="">
    <RecipeForm />
  </div>

  <div class=" row container-fluid">

    <ActiveModal />
    <div class="pt-3 px-5">
      <div class="pb-3  bg-img col-12 img-fluid elevation-5  "
        style="background-image: url('https://images.unsplash.com/photo-1606787366850-de6330128bfc?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80')">
        <div class="row container d-flex justify-content-end ">
          <Login />
          <div class="col-10 align-items-center ">
            <h1 class="text-center fw-bold text-danger text-vfx glow">All-Spice</h1>

            <!-- <h2 class="text-center fw-bold text-dark  text-vfx">Elevate your taste buds with every recipe</h2>
              <h5 class="text-center fw-bold text-dark  text-vfx">Discover new flavors, explore cuisines and cook like a
                pro. </h5> -->
            <h4 class="text-center  text-dark text2 text-vfx ">Unleash your culinary creativity with my recipe
              app.
              From classic dishes to unique creations, we have the recipe for every appetite.</h4>
          </div>
          <div class="col-10 justify-content-end">
            <SearchBar />
          </div>
        </div>
      </div>
    </div>
  </div>
  <div class="row container-fluid  pt-2 pb-1">
    <div class=" col-12 d-flex justify-content-center ">
      <div class="p-1  ">
        <button @click="getRecipes" class="btn text-things">Home</button>
      </div>
      <div class=" p-1">
        <button v-if="account.id == recipes.creatorId" @click="getMyRecipes" class="btn text-things">My Recipes
        </button>
      </div>
      <div class=" p-1 ">
        <button @click="getFavorites" class="btn text-things">Favorites</button>
      </div>
    </div>
  </div>
  <div class="row container-fluid">
    <div class="col-4 pt-3 px-5 pb-5" v-for="r in recipes">
      <RecipeCard :recipe="r" />
    </div>
  </div>
</template>
<script>
import Login from "../components/Login.vue";
import { onMounted, computed, ref } from "vue";
import { recipesService } from "../services/RecipesService.js";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import RecipeCard from "../components/RecipeCard.vue";
import RecipeForm from "../components/RecipeForm.vue";
import { favoritesService } from "../services/FavoritesService.js";
import SearchBar from "../components/SearchBar.vue";
import { accountService } from "../services/AccountService.js";
import ActiveModal from "../components/ActiveModal.vue";
export default {
  setup() {
    const editable = ref({})

    async function getRecipes() {
      try {
        await recipesService.getRecipes()

      } catch (error) {
        Pop.error
      }
    }
    // async function getFavoritess() {
    //   try {
    //     await favoritesService.getFavorites()
    //   } catch (error) {
    //     Pop.error(error)
    //   }
    // }
    onMounted(() => {
      getRecipes();
      // getFavoritess();
    });

    return {

      editable,
      recipes: computed(() => AppState.recipes),
      account: computed(() => AppState.account),
      fav: computed(() => AppState.favorites),
      async createRecipe() {
        try {
          const recipe = await recipesService.createRecipe(editable.value)
          editable.value = {}
          Modal.getOrCreateInstance('#exampleModal').hide()
        } catch (error) {
          Pop.error(error)
        }
      },

      async getFavorites() {
        try {
          await favoritesService.getFavorites()
        } catch (error) {
          Pop.error(error)
        }
      },
      async getMyRecipes() {
        try {

          await accountService.getMyRecipes()

        } catch (error) {
          Pop.error
        }
      },
      async getRecipes() {
        try {
          await recipesService.getRecipes()
        } catch (error) {
          Pop.error
        }
      }
    }
  },
  components: { Login, RecipeCard, RecipeForm, SearchBar, ActiveModal }
}

</script>

<style scoped lang="scss">
.text-vfx {
  font-family: 'Oxygen', sans-serif;
  text-decoration: double;

}

.text-things {
  background-color: #3EB489;
}

.text2 {
  background-color: rgba(84, 56, 97, 0.14);
  backdrop-filter: blur(10px);
}

.bg-img {
  background-color: rgba(165, 0, 236, 0.14);
  backdrop-filter: blur(10px);
  // background-repeat: no-repeat;
  object-fit: cover;
  object-position: center;
  background-size: cover;
}

.glow {
  font-size: 80px;
  color: #fff;
  text-align: center;
  -webkit-animation: glow 1s ease-in-out infinite alternate;
  -moz-animation: glow 1s ease-in-out infinite alternate;
  animation: glow 1s ease-in-out infinite alternate;
}

@-webkit-keyframes glow {
  from {
    text-shadow: 0 0 10px rgb(0, 0, 0), 0 0 15px rgb(0, 0, 0), 0 0 20px #000000, 0 0 30px #000000, 0 0 0px #000000, 0 0 10px #e84245, 0 0 70px #000000;
  }

  to {
    text-shadow: 0 0 15px rgb(0, 0, 0), 0 0 30px #000000, 0 0 20px #000000, 0 0 25px #000000, 0 0 30px #000000, 0 0 0px #ac0909, 0 0 40px #ff0000;
  }
}



.account-vfx {
  border-radius: 50;
}

.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }



}
</style>
