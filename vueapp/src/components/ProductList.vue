<script lang="ts">
    import { useCartStore } from "@/stores/CartDetailsStore";
    import { useProductsStore } from "@/stores/ProductsStore";
    import ProductCard from "./ProductCard.vue";
    import Cart from "./Cart.vue"

    export default {
        computed: {
            addProduct() {
                return useCartStore().addProduct;
            },
            getProducts(){
                return useProductsStore().getProducts;
            }
        },
        components: { ProductCard, Cart }
    }
    
</script>



<template>
    <v-row>
        <v-col v-for="p in getProducts()" cols="4">
            <ProductCard     
            :product="p" 
            @productAddedToCart="addProduct(p)"/>
        </v-col>
    </v-row>
  
    <Cart></Cart>
</template>





