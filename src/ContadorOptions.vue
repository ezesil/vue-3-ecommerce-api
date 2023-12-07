<script lang="ts">
export default{
  data(){
    return {
      count:0
    }
  },
  methods:{
    increase(){
      this.count = this.count+1; 
    },
    decrease(){
      this.count = this.count-1;
    }
  },
  mounted(){ 
console.log("Componente contador cargado.")
  }
}
</script> 

<template>
  <h1>Contador: {{ count }}</h1>
  <button @click="$event => increase()">
    Aumentar contador  
  </button>
  <button @click="$event => decrease()">
    Restar contador  
  </button>
</template>

  