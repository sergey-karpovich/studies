import axios from "axios"

export default {

    /**
     * Inventory Service
     * Provides UI business logic associated with Inventory in our system 
     */
    async getInventory(context){        
        var url=context.state.API_URL+'/inventory';       
        let result = await axios.get(url);
        context.commit('getInventory',result.data)
    },
    async updateInventoryQuantity(context, shipment){
        var url=context.state.API_URL+'/inventory';
        let result = await axios.patch(url,shipment);
        console.log(result);
    },
    async archiveProduct(context, id){
        var url=context.state.API_URL+'/product/'+id;       
        let result = await axios.patch(url);
        console.log(result);
    },
    async saveProduct(context, newProduct){
        var url=context.state.API_URL+'/product/';       
        let result = await axios.post(url, newProduct);
        console.log(result);
    },

    /**
     * Customer Service
     * Provides UI business logic associated with Customers in our system 
     */
    async getCustomers(context){
        var url=context.state.API_URL+'/customer/'; 
        let result = await axios.get(url);
        context.commit('getCustomers',result.data);
    },
    async addCustomer(context,customer){
        var url = context.state.API_URL+'/customer/';
        let result =await axios.post(url,customer);
        console.log(result);
    },
    async deleteCustomer(context, id){
        var url=context.state.API_URL+'/customer/'+id;       
        let result = await axios.delete(url);
        console.log(result);
    },

    /**
     * InvoiceService
     */
    async makeNewInvoice(context, invoice){
        var url=context.state.API_URL+'/invoice/'
        let now =new Date();
        invoice.createdOn = now;
        invoice.updatedOn = now;
        console.log(invoice);
        let result= await axios.post(url,invoice);
        console.log(result);
    },
    async getOrders(context){        
        var url=context.state.API_URL+'/order/';       
        let result = await axios.get(url);
        context.commit('getOrders',result.data)
    },
    async makeOrderComplete(context,id){
        var url=context.state.API_URL+'/order/complete/'+id;
        let result= await axios.patch(url);
        console.log(result);
    },

}