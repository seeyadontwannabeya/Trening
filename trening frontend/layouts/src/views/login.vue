<template>
  <div id="login">
    <h1>Login</h1>
    <input
      type="text"
      name="username"
      v-model="input.username"
      placeholder="Username"
    />
    <input
      type="password"
      name="password"
      v-model="input.password"
      placeholder="Password"
    />
    <button type="button" v-on:click="submit()">Login</button>
    <button type="button" v-on:click="register()">Sign up</button>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "Login",
  data() {
    return {
      input: {
        username: "",
        password: ""
      }
    };
  },
  methods: {
    submit() {
      if (this.input.username != "" && this.input.password != "") {
        axios
          .post("https://localhost:44368/login", {
            Username: this.input.username,
            Password: this.input.password
          })
          .then(response => {
            this.success = "Data saved successfully";
            console.log(JSON.stringify(response.data));
            document.cookie =
              "Token=" +
              response.data.accessToken +
              ";" +
              response.data.expireDate +
              ";path=/";
            this.$emit("authenticated", true);
            this.$router.replace({ name: "secure" });
          })
          .catch(error => {
            this.response = "Error: " + error.response;
            console.log("The username and / or password is incorrect");
          });
      } else {
        console.log("A username and password must be present");
      }
    },
    register() {
      this.$router.replace({ name: "register" });
    }
  }
};
</script>

<style scoped>
#login {
  width: 500px;
  border: 1px solid #cccccc;
  background-color: #ffffff;
  margin: auto;
  margin-top: 200px;
  padding: 20px;
}
</style>
