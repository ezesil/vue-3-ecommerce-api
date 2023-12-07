<script setup>
    import { ref, onMounted } from "vue"

    onMounted(() => {
        console.log("On mounted funciona.");
    });

    const count = ref(0)

    let increase = () => count.value++;
    let decrease = () => count.value--;
</script>

<template>
    <p>El objetivo es llegar a 100 clicks.</p>
     
    <h1>Contador: {{ count }}</h1>

    <button @click="increase"> Increment </button>
    <button @click="decrease"> Decrease </button>

    <p v-if="count < 15"> Vos podés!</p>
    <p v-else-if="count >= 15 && count < 20">Ya falta poco!</p>
    <p v-else> ¡Felicidades!</p>




</template>