import Vue from "vue";
import App from "./App.vue";
import BootstrapVue from "bootstrap-vue";
import axios from "axios";
import VueAxios from "vue-axios";
import VueRouter from "vue-router";

import Router from "./router";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

Vue.config.productionTip = false;
Vue.use(VueAxios, axios);
Vue.use(BootstrapVue);
Vue.use(VueRouter);

new Vue({
  router: Router,
  render: h => h(App)
}).$mount("#app");
