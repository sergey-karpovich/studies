<template>
    <solar-modal >
        <template v-slot:header>
            Receive Shipment
        </template>

        <template v-slot:body>
            <label for="product">Product Received</label>
            <select v-model="selectedProduct" 
                class="shipmentItems" id="product">
                <option disabled value="">Please select one</option>
                <option v-for="item in inventory" :value="item" :key="item.product.id">
                    {{ item.product.name }}
                </option>
            </select>
            <label for="qtyReceived">Quantity Received:</label>
            <input type="number" id="qtyReceived" v-model="qtyReceived" />
        </template>

        <template v-slot:footer>
            <solar-button
                type="button"
                @button:click="save"
                aria-label="save new shipment"
            >
                Save Received Shipment
            </solar-button>
            <solar-button
                type="button"
                @button:click="close"
                aria-label="Close modal"
            >
                Close
            </solar-button>
        </template>
    </solar-modal>

</template>

<script>
import SolarButton from '@/components/SolarButton.vue';
import SolarModal from '@/components/Models/SolarModal.vue';
export default {
    emits:[
        'close',
        'save:shipment'
    ],
    props:[
        'inventory'
    ],
    components:{
        SolarButton,
        SolarModal
    },
    data(){
        return {
            selectedProduct: {
                createdOn: new Date(),
                updatedOn: new Date(),
                id: 0 ,
                description: "",
                isTaxable: false,
                name: "",
                price: 0,
                isArchived: false
            },
            qtyReceived: 0,
        }
    },
    methods:{
        save(){
            let shipment = {
                productId: this.selectedProduct.id,
                adjustment: this.qtyReceived,                
            };
            this.$emit('save:shipment', shipment);
        },  
        close(){
            this.$emit("close");
        },
    }

}
</script>

<style>

</style>