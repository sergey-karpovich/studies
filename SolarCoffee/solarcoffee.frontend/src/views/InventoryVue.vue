<template>
    <div class="inventory-container">
        <h1 id="inventoryTitle">
            Inventory Dashboard
        </h1>
        <hr />
        
        <div class="inventory-actions">
            <solar-button @click.native="showNewProductModal" id="addNewBtn">
                Add New Item
            </solar-button>
            <solar-button @click.native="showShipmentModal" id="addNewBtn">
                Receive Shipment 
            </solar-button>
        </div>

        <table id="inventoryTable" class="table">
            <tr>
                <th>Item</th>
                <th>Quantity On-hand</th>
                <th>Unit Price</th>
                <th>Taxable</th>
                <th>Delete</th>
            </tr>
            
            <tr v-for="item in inventory" :key="item.id">
                <td>{{ item.product.name}}</td>
                <td>{{ item.quantityOnHand}}</td>
                <td>{{ item.product.price | price}}</td>
                <td>
                    <span v-if="item.product.isTaxable">
                        Yes
                    </span>
                    <span v-else>
                        No
                    </span>
                </td>
                <td>
                    <div>
                        X
                    </div>
                </td>
            </tr>
        </table>
        <new-product-modal 
            v-if="isNewProductVisible" 
            @save:product="saveNewProduct"
            @close="closeModals"
        />
        <shipment-modal 
            v-if="isShipmentVisible" 
            :inventory="inventory"
            @save:shipment="saveNewShipment"
            @close="closeModals" 
        />
    </div>
</template>

<script>
import SolarButton from '@/components/SolarButton.vue';
import NewProductModal from '@/components/Models/NewProductModal.vue';
import ShipmentModal from '@/components/Models/ShipmentModal.vue';

export default {
    components:{
        SolarButton,
        NewProductModal,
        ShipmentModal,
    },

    data(){
        return {
            isNewProductVisible:false,
            isShipmentVisible: false,
            inventory:[
                {
                    id: 1,
                    product: 
                    {
                        id: 1,
                        name: 'Some Product',
                        description: 'Good stuff',
                        price: 100,
                        createdOn: new Date(),
                        updatedOn: new Date(),
                        isTaxable: true,
                        isArchived: false,
                    },
                    quantityOnHand: 100,
                    idealQuantity: 100,
                },
                {
                    id: 2,
                    product: 
                    {
                        id: 2,
                        name: 'Second Product',
                        description: 'Good stuff',
                        price: 100,
                        createdOn: new Date(),
                        updatedOn: new Date(),
                        isTaxable: false,
                        isArchived: false,
                    },
                    quantityOnHand: 40,
                    idealQuantity: 20,
                }
            ]
        }
    },
    methods:{
        showNewProductModal(){
            this.isNewProductVisible = true;
        },
        showShipmentModal(){
            this.isShipmentVisible = true;
        },
        saveNewProduct(newProduct){
            console.log("saveNewProduct");
            console.log(newProduct);
        },
        saveNewShipment(shipment){
            console.log('saveNewShipment')
            console.log(shipment)
        },
        closeModals(){
            this.isShipmentVisible=false;
            this.isNewProductVisible=false;
        },
        async fetchData(){
            await this.$store.dispatch('getInventory');
            this.inventory=this.$store.getters.inventory;
        }
    },
    async created(){    
        await this.fetchData();
        //await this.$store.dispatch('getInventory');
    }
}
</script>

<style scoped>
.inventory-actions{
    display: flex;
}
</style>