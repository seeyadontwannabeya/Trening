import Vue from "vue";
import Router from "vue-router";
import LoginComponent from "./views/login.vue";
import SecureComponent from "./views/secure.vue";
import RegisterComponent from "./views/Registration.vue";
import CalculateComponent from "./views/NutritionCalculator.vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      redirect: {
        name: "login"
      }
    },
    {
      path: "/login",
      name: "login",
      component: LoginComponent
    },
    {
      path: "/secure",
      name: "secure",
      component: SecureComponent
    },
    {
      path: "/register",
      name: "register",
      component: RegisterComponent
    },
    {
      path: "/calculate",
      name: "calculate",
      component: CalculateComponent
    }
  ]
});
