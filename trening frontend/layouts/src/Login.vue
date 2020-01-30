<template>
  <div>
    <h1>Login</h1>
    <label for="email">E-mail</label>
    <div id="UserRow">
      <input type="text" id="email" v-model="Email" />
    </div>
    <br />
    <label for="password">Password</label>
    <div id="UserRow">
      <input type="password" id="password" v-model="Password" />
    </div>
    <br />
    <button type="submit" @click="submit(Email, Password )">Login</button>
  </div>
</template>
<script>
import axios from "axios";
const app = require("./App");
export default {
  methods: {
    submit: function(Email, Password) {
      axios
        .post("https://localhost:44368/login", {
          Username: Email,
          Password: Password
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
          app.computed.signedInUser = true;
          //userID = re
        })
        .catch(error => {
          this.response = "Error: " + error.response.status;
          console.log(JSON.stringify("error"));
        });
    }
  },
  data: function() {
    return {
      Email: "",
      Password: ""
    };
  }
};
</script>