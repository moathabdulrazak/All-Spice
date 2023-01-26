<template>

  <div class="main-search-input-wrap ">
    <form @submit.prevent="searchCategory">
      <input class="main-search-input-item" type="text" placeholder="Search by category .." required="true"
        name="search" v-model="editable">
      <button type="submit" class="main-search-button"><i class="mdi mdi-magnify mx-2" alt=""
          title="search By category"></i></button>
    </form>

  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref, watchEffect } from 'vue';
import Pop from "../utils/Pop.js";
import { recipesService } from "../services/RecipesService.js";
export default {
  setup() {
    const editable = ref('')
    watchEffect(() => { })
    return {
      editable,
      async searchCategory() {
        try {
          await recipesService.searchCategory(editable.value)
          editable.value = ''
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  }
};
</script>


<style lang="scss" scoped>
.main-search-input {
  background: rgb(252, 2, 2);
  // padding: 0 120px 0 0;
  border-radius: 1px;
  // margin-top: 200px;
  box-shadow: 0px 0px 0px 6px rgba(255, 255, 255, 0.3);
}

.main-search-input:before {
  content: '';
  position: absolute;
  bottom: -40px;
  width: 50px;
  height: 1px;
  background: rgba(255, 255, 255, 0.41);
  left: 50%;
  margin-left: -25px;
}

.main-search-input-item {
  float: right;
  width: 100%;
  box-sizing: border-box;
  border-right: 1px solid rgb(0, 0, 0);
  height: 50px;
  position: relative;
}

.main-search-input-item input:first-child {
  border-radius: 100%;
}

.main-search-input-item input {
  float: left;
  border: none;
  width: 100%;
  height: 50px;
  padding-left: 20px;
}

.main-search-button {

  background-color: #3EB489;
}

.main-search-button {
  position: absolute;
  right: 0px;
  height: 50px;
  width: 120px;
  color: rgb(255, 255, 255);
  top: 0;
  border: none;
  border-top-right-radius: 0px;
  border-bottom-right-radius: 0px;
  cursor: pointer;
}

.main-search-input-wrap {
  max-width: 500px;
  margin: 20px auto;
  position: relative;
}

:focus {
  outline: 0;
}

.fl-wrap {
  float: left;
  width: 100%;
  position: relative;
}

@media only screen and (max-width: 768px) {
  .main-search-input {
    background: rgba(255, 255, 255, 0.2);
    padding: 14px 20px 10px;
    border-radius: 10px;
    box-shadow: 0px 0px 0px 10px rgba(255, 255, 255, 0.0);
  }

  .main-search-input-item {
    width: 100%;
    border: 1px solid rgb(0, 0, 0);
    height: 50px;
    border: none;
    margin-bottom: 10px;
  }

  .main-search-input-item input {
    border-radius: 6px !important;
    background: #fff;
  }

  .main-search-button {
    position: relative;
    float: left;
    width: 100%;
    border-radius: 6px;
  }
}
</style>