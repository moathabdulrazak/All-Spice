<template>
  <!-- Button trigger modal -->


  <!-- Modal -->
  <!-- <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
    aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">

        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary">Save changes</button>
        </div>
      </div>
    </div>
  </div> -->
  <!-- <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel"
    aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">

      </div>
    </div>
  </div>
  <button type="button" class="btn btn-primary" data-toggle="modal" data-target=".bd-example-modal-lg">Large
    modal</button> -->
  <!-- <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-target="#exampleModal">
    Launch demo modal
  </button>

  <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
    aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">

        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary">Save changes</button>
        </div>
      </div>
    </div>
  </div> -->

  <div class="modal fade modal-background" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel"
    aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="exampleModalLabel">Modal title</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createRecipe">
            <div class="form-floating mb-3 elevation-5">
              <input v-model="editable.img" type="url" required class="form-control" id="img" placeholder="Cover Image">
              <label for="coverImg">recipe Image</label>
            </div>
            <div class="form-floating mb-3 elevation-5">
              <input v-model="editable.title" type="text" required class="form-control" id="title"
                placeholder="recipe name">
              <label for="name">recipe name</label>
            </div>
            <div class="form-floating mb-3 elevation-5">
              <input v-model="editable.instructions" type="text" required class="form-control" id="title"
                placeholder="instructions">
              <label for="name">instructions</label>
            </div>
            <div class="mt-3 inputBox">
              <div class="form-group scrollable ">
                <label for="type" class="pe-2 mb-2 pt-3">Category</label>
                <select required name="category" v-model="editable.category">
                  <option value="Breakfast">Breakfast</option>
                  <option value="Comfort food">Comfort food</option>
                  <option value="Appetizers">Appetizers</option>
                  <option value="Breakfast">Desserts</option>
                  <option value="Soup">Soup</option>
                  <option value="Drinks">Drinks</option>
                  <option value="Baking">Baking</option>
                  <option value="Seafood">Seafood</option>
                  <option value="Bbq">BBQ</option>
                  <option value="Italian cuisine">Italian cuisine</option>
                  <option value="Japanese cuisine">Japanese cuisine</option>
                  <option value="Mexican cuisine">Mexican cuisine</option>
                  <option value="Indian cuisine">Indian cuisine</option>
                  <option value="Pasta and Noodles">Pasta and Noodles</option>
                  <option value="Keto-friendly">Keto-friendly</option>
                  <option value="Vegetarian">Vegetarian</option>
                  <option value="Side Dishes">Side Dishes</option>
                  <option value="Mediterranean cuisine">Mediterranean cuisine</option>
                  <option value="Gluten-free">Gluten-free</option>
                  <option value="One-Pot meals">One-Pot meals</option>
                  <option value="No-bake desserts.">No-bake desserts.</option>
                  <option value="Cajun and Creole cuisine">Cajun and Creole cuisine</option>
                  <option value="African cuisine">African cuisine</option>
                  <option value="Middle Eastern cuisine">Middle Eastern cuisine</option>
                  <option value="French cuisine">French cuisine</option>
                </select>
              </div>
            </div>
            <button type="submit" class="btn btn-primary">create</button>
          </form>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from "../utils/Pop.js";
import { recipesService } from "../services/RecipesService.js";

import { Modal } from "bootstrap";
export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      async createRecipe() {
        try {
          const recipe = await recipesService.createRecipe(editable.value)
          editable.value = {}
          Modal.getOrCreateInstance('#exampleModal').hide()
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  }
};
</script>


<style lang="scss" scoped>
.modal-background {
  background-color: rgb(51 27 61 / 14%);
  backdrop-filter: blur(40px);
}
</style>