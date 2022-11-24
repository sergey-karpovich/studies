<template>
    <div class="inventory-container">
        <h1 id="inventoryTitle">
            Inventory Dashboard
        </h1>
        <hr />
        <div>
            <inventory-charts>              
            </inventory-charts>
        </div>
        <div class="inventory-actions">
            <solar-button @button:click="showNewProductModal" id="addNewBtn">
                Add New Item
            </solar-button>
            <solar-button @button:click="showShipmentModal" id="addNewBtn">
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
                <td 
                  v-bind:class="`${applyColor(item.quantityOnHand, item.idealQuantity)}`"
                  >
                  {{ item.quantityOnHand}}</td>
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
                    <div 
                      class="lni lni-cross-circle product-archive"
                      @click="archiveProduct(item.product.id)"
                    >                        
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
import InventoryCharts from '@/components/charts/InventoryCharts.vue';

export default {
    components:{
        SolarButton,
        NewProductModal,
        ShipmentModal,
        InventoryCharts,
    },

    data(){
        return {
            isNewProductVisible:false,
            isShipmentVisible: false,
            snapshot: {},
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
        async saveNewShipment(shipment){
            await this.$store.dispatch('updateInventoryQuantity',shipment);
            this.isShipmentVisible=false;
            await this.fetchData();
        },
        closeModals(){
            this.isShipmentVisible=false;
            this.isNewProductVisible=false;
        },
        async fetchData(){
            await this.$store.dispatch('getInventory');
            await this.$store.dispatch('getSnapshotHistory');
            this.inventory=this.$store.getters.inventory;
            this.snapshot=this.$store.getters.snapshot;
        },
        applyColor(current, target){
            if(current <=0)
                return "red";
            if(Math.abs(target-current)>8)
                return "yellow";
            return "green";
        },
        async archiveProduct(id){
           await this.$store.dispatch('archiveProduct',id) ;
           await this.fetchData();
        },
        async saveNewProduct(product){
            await this.$store.dispatch('saveProduct',product);
            this.isNewProductVisible=false;
            await this.fetchData();
        }
    },
    async created(){    
        await this.fetchData();
        
    }
}
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";
.inventory-actions{
    display: flex;
    margin-bottom: 0.8rem;
}

.green {
    font-weight: bold;
    color: $solar-green;
}
.red {
    font-weight: bold;
    color: $solar-red;
}
.yellow {
    font-weight: bold;
    color: $solar-yellow;
}

.product-archive{
    cursor: pointer;
    font-weight: bold;
    font-size: 1.2rem;
    color: $solar-red;
}



</style>