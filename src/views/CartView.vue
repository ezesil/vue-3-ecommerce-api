<script lang="ts">
import { useCartStore } from '@/stores/CartDetailsStore';
import Cart from '../components/Cart.vue'

export default {
  computed:{
    details() {
        return useCartStore().details
    }
  },
  components:{ Cart }

} 
</script>

<template>
    <Cart :details="details"/>
</template>











