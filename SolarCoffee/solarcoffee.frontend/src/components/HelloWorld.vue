<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <h2>{{ myNumber }}</h2>
    <button @click="myNumber++">
      Click Me!
    </button>
  </div>
</template>

<script>
export default {
  name: 'HelloWorld',
  data(){
    return{
      myNumber: 0, 

    }
  },
  props: {
    msg: String,

  },
  created(){
    console.log("Created")
  },
  mounted(){
    console.log("mounted");
  },
  destroyed(){
    console.log("Destroyed");
  }

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
