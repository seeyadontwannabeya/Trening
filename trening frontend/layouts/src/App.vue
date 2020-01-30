<template>
  <div id="app">
    <div id="nav">
      <router-link id="link" v-if="authenticated" to="/calculate" replace
        >Calculate</router-link
      >
      <router-link id="link" v-if="authenticated" to="/secure" replace
        >Workoutprogram</router-link
      >
      <router-link
        id="link"
        v-if="authenticated"
        to="/login"
        v-on:click.native="logout()"
        replace
        >Logout</router-link
      >
    </div>
    <router-view @authenticated="setAuthenticated" />
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "App",
  data() {
    return {
      authenticated: false,
      login: function(email, password) {
        axios
          .post("https://localhost:44368/login", {
            Email: email,
            Password: password
          })
          .then(response => {
            document.cookie =
              "Token=" +
              response.data.accessToken +
              ";" +
              response.data.expireDate +
              ";path=/";
            return true;
          })
          .catch(error => {
            console.log(error);
            return false;
          });
      }
    };
  },
  mounted() {
    if (!this.authenticated) {
      this.$router.replace({ name: "login" });
    }
  },
  methods: {
    setAuthenticated(status) {
      this.authenticated = status;
    },
    logout() {
      this.authenticated = false;
    },
    calc() {
      this.$router.replace({ name: "calculate" });
    }
  }
};
</script>

<style>
body {
  background-color: #f0f0f0;
}
h1 {
  padding: 0;
  margin-top: 0;
}
#app {
  width: 100%;
  margin: auto;
}
#link {
  padding-right: 15px;
}
#nav {
  width: 100%;
  border-bottom-style: groove;
  border-bottom-color: black;
  border-bottom-width: 1px;
}
</style>
