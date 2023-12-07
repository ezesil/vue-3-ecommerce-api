<script lang="ts">
import { useCartStore } from '../stores/CartDetailsStore';

export default {
  computed:{
    details() {
        return useCartStore().details
    }
  }
}
</script>

<template>
    <v-card class="mt-4">
        <v-card-title>
            <p>Carrito de compras:</p>
        </v-card-title>
        <v-card-text>
            <v-list>
                <v-list-item v-for="product in details" :value="product?.productId">
                    <v-list-item-title>
                        Nombre: {{product?.name}}
                        Cantidad: {{product?.count}}
                    </v-list-item-title>
                </v-list-item>
            </v-list>
        </v-card-text>
    </v-card>   
</template>



