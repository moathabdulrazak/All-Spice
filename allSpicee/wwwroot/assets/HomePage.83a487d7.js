import{_ as x,r as R,d as b,b as r,e as p,P as v,f as w,g as F,L as S,R as M,h as k,S as C,i as j,c as d,a as e,j as i,F as g,k as A,o as l,A as _,p as B,l as L,m as n}from"./index.bbaed73d.js";const I={setup(){const t=R({});async function s(){try{await p.getRecipes()}catch{}}return b(()=>{s()}),{editable:t,recipes:r(()=>_.recipes),account:r(()=>_.account),fav:r(()=>_.favorites),async createRecipe(){try{const c=await p.createRecipe(t.value);t.value={},Modal.getOrCreateInstance("#exampleModal").hide()}catch(c){v.error(c)}},async getFavorites(){try{await w.getFavorites()}catch(c){v.error(c)}},async getMyRecipes(){try{await F.getMyRecipes()}catch{}},async getRecipes(){try{await p.getRecipes()}catch{}}}},components:{Login:S,RecipeCard:M,RecipeForm:k,SearchBar:C,ActiveModal:j}},P=t=>(B("data-v-550eaa32"),t=t(),L(),t),H={class:""},N={class:"row container-fluid"},D={class:"pt-3 px-5"},V={class:"pb-3 bg-img col-12 img-fluid elevation-5",style:{"background-image":"url('https://as1.ftcdn.net/v2/jpg/02/52/12/40/1000_F_252124067_aCtp9ZD934RboKmjJzkXiwYDL7XkNjpn.jpg')"}},X={class:"row container d-flex justify-content-end"},q=P(()=>e("div",{class:"col-10 align-items-center"},[e("h1",{class:"text-center fw-bold text-danger text-vfx glow"},"All-Spice"),e("h4",{class:"text-center text-dark text2 text-vfx"},"Unleash your culinary creativity with my recipe app. From classic dishes to unique creations, we have the recipe for every appetite.")],-1)),z={class:"col-10 justify-content-end"},E={class:"row container-fluid pt-1 pb-1"},J={class:"col-12 d-flex justify-content-center"},K={class:"p-1"},O={class:"p-1"},U={class:"p-1"},Y={class:"row container-fluid"},Z={class:"col-4 pt-3 px-5 pb-5"};function G(t,s,c,o,Q,T){const h=n("RecipeForm"),u=n("ActiveModal"),m=n("Login"),f=n("SearchBar"),y=n("RecipeCard");return l(),d(g,null,[e("div",H,[i(h)]),e("div",N,[i(u),e("div",D,[e("div",V,[e("div",X,[i(m),q,e("div",z,[i(f)])])])])]),e("div",E,[e("div",J,[e("div",K,[e("button",{onClick:s[0]||(s[0]=(...a)=>o.getRecipes&&o.getRecipes(...a)),class:"btn text-things"},"Home")]),e("div",O,[e("button",{onClick:s[1]||(s[1]=(...a)=>o.getMyRecipes&&o.getMyRecipes(...a)),class:"btn text-things"},"My Recipes ")]),e("div",U,[e("button",{onClick:s[2]||(s[2]=(...a)=>o.getFavorites&&o.getFavorites(...a)),class:"btn text-things"},"Favorites")])])]),e("div",Y,[(l(!0),d(g,null,A(o.recipes,a=>(l(),d("div",Z,[i(y,{recipe:a},null,8,["recipe"])]))),256))])],64)}const $=x(I,[["render",G],["__scopeId","data-v-550eaa32"]]);export{$ as default};
