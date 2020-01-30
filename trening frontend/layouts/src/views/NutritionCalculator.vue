<template>
  <div id="NutritionCalculator">
    <h3>Nutrition Calculator</h3>

    <br />
    <label for="age">Age?</label>
    <div id="UserRow">
      <input type="text" id="age" v-model="input.Age" />
    </div>
    <br />

    <div id="UserRow1"></div>
    <input type="radio" value="male" id="male" v-model="input.Gender" />
    <label for="male">Male</label>

    <input type="radio" value="female" id="female" v-model="input.Gender" />
    <label for="female">Female</label>
    <br />

    <label for="height">How tall are you?</label>
    <div id="UserRow">
      <input type="text" id="height" v-model="input.Height" />
    </div>
    <br />

    <label for="weight">How much do you weigh?</label>
    <div id="UserRow">
      <input type="text" id="weight" v-model="input.Weight" />
    </div>
    <br />
    <span>Activityfactor: {{ input.Activityfactor }}</span>
    <div class="slidecontainer">
      <input
        type="range"
        min="1.2"
        max="2.0"
        value="1.6"
        step="0.1"
        class="slider"
        id="myRange"
        v-model="input.Activityfactor"
      />
    </div>
    <button type="button" v-on:click="submit()">submit</button>
    <br />
    <span>Kcal: {{ input.KcalResult }}</span>
  </div>
</template>

<script>
import axios from "axios";

export default {
  methods: {
    submit: function() {
      axios
        .post("https://localhost:44368/api/CalcDatas", {
          Gender: this.input.Gender,
          Age: this.input.Age,
          Height: this.input.Height,
          Weight: this.input.Weight,
          Activityfactor: this.input.Activityfactor
        })
        .then(response => {
          this.success = "Data saved successfully";
          this.response = JSON.stringify(response, null, 2);
          this.input.KcalResult = response.data.KcalResult;
        })
        .catch(error => {
          this.response = "Error: " + error.response;
        });
    }
  },
  name: "NutritionCalculator",

  data: function() {
    return {
      input: {
        Gender: "",
        Age: "",
        Height: "",
        Weight: "",
        Activityfactor: "1.3",
        KcalResult: ""
      }
    };
  }
};
</script>
<style>
#NutritionCalculator {
  text-align: center;
}
</style>
