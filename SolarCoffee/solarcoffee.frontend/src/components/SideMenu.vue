<template>
    <div class="side-menu-container">
        <router-link to="/">
            <img 
            id="imgLogo" 
            alt="Solar Coffee logo" 
            src="../assets/images/coffee-logo-design-creative-idea-logo-elements-2.png" />
        </router-link>
        <h1>Management Portal</h1>
        <solar-button 
            id="menuInventory"
            :link="'/inventory'"
            :is-full-width="true"
            >
            Inventory
        </solar-button>
        <solar-button 
            id="menuCustomers"
            :link="'/customers'"
            :is-full-width="true">
            Manage Customers
        </solar-button>
        <solar-button 
            id="menuInvoice"
            :link="'/invoice/new'"
            :is-full-width="true"
            >
            New Invoice
        </solar-button>
        <solar-button 
            id="menuOrders"
            :link="'/orders'"
            :is-full-width="true"
            >
            Orders
        </solar-button>
    </div>
</template>

<script>
import SolarButton from "@/components/SolarButton.vue"
export default {
    data(){
        return{

        }
    }    ,
    components:{
        SolarButton,

    }
}
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";

.side-menu-container{
    background-color: #fcfcfc;
    height: 100vh;
    width: $menu-width;
    display: flex;
    flex-direction: column;
    padding: 0.8rem;
    box-shadow: 0 1px 1px rgba(0,0,0,0.12), 0 1px rgba(0,0,0,0.24);
    box-sizing: border-box;
}

#imgLogo{
    width: 100%;

}

h1{
    font-size: 1.2rem;
    margin: 1rem 0;
}


</style>