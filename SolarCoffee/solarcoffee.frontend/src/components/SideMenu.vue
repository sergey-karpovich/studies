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
          :is-full-width="true"
          @button:click="goToRoute('/inventory')"
        >
            Inventory
        </solar-button>
        <solar-button 
          id="menuCustomers"
          :is-full-width="true"
          @button:click="goToRoute('/customer')"
          >
          Manage Customers
        </solar-button>
        <solar-button 
          id="menuInvoice"
          :is-full-width="true"
          @button:click="goToRoute('/invoice/new')"
          >
          New Invoice
        </solar-button>
        <solar-button 
          id="menuOrders"
          :is-full-width="true"
          @button:click="goToRoute('/orders')"
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
    },
    methods:{
        goToRoute(route){
            if(route!=window.location.pathname)
                this.$router.push(route);
        }

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