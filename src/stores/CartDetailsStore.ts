import { defineStore } from 'pinia'
import { type CartDetails, type Product } from '../models/Product.ts'

export const useCartStore = defineStore('cart', {
    state: () => ({ details: <Array<CartDetails>>[] }),
    // getters: {
    //   doubleCount: (state) => state.count * 2,
    // },
    actions: {
      addProduct(product: Product){
        const prod = this.details?.find(prod => prod.id == product.id)
        if(prod != undefined){
            prod.count = prod.count + 1
        }
        else{
            if(product != undefined){
                const detail = {id: product?.id, name:product?.name, count: 1}
                this.details.push(detail)
            }      
        }
    },
}})