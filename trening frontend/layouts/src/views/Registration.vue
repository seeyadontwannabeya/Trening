<template>
  <div id="Registration">
    <h3>Sign up</h3>
    <label for="email">E-mail</label>
    <div id="UserRow">
      <input type="email" id="email" v-model="input.username" />
    </div>
    <br />
    <label for="password">Password</label>
    <div id="UserRow">
      <input type="password" id="password" v-model="input.password" />
    </div>
    <br />
    <button type="button" v-on:click="submit()">Submit</button>
  </div>
</template>

<script>
import axios from "axios";

export default {
  methods: {
    submit() {
      axios
        .post("https://localhost:44368/api/UserRegistrations", {
          Email: this.input.username,
          Password: this.input.password
        })
        .then(response => {
          this.success = "Data saved successfully";
          this.response = JSON.stringify(response, null, 2);
          this.$router.replace({ name: "login" });
        })
        .catch(error => {
          this.response = "Error: " + error.response.status;
          this.$router.replace({ name: "login" });
        });
    }
  },
  name: "Registration",

  data: function() {
    return {
      input: {
        username: "",
        password: ""
      }
    };
  }
};
</script>
<style>
#UserRegistration {
  text-align: center;
}
.hejsan {
  margin: 10px;
}
</style>
