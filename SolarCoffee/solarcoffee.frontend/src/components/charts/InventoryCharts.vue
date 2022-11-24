<template>
    <div>

        <apex-chart type="area" :width="'100%'" height="300" :options="options" :series="series">
        </apex-chart>
    </div>
</template>

<script>
import moment from 'moment';

//import { Sync } from "vuex-pathify";
export default {
    // props:[
    //     'snapshot'
    // ],

    data() {
        return {


            snapshotTimeline: {
                productInventorySnapshots: [
                    {
                        productId: 0,
                        quantityOnHand: [],
                    }
                ],
                timeline: [],
            },
            snapshot:
            {
                "productInventorySnapshots": [
                    {
                        "quantityOnHand": [
                            74,60,50,40,10,40,73,73,73],
                        "productId": 2
                    },
                    {
                        "quantityOnHand": [
                            54,54,53,53,53,53,13,13,13],
                        "productId": 3
                    },
                    {
                        "quantityOnHand": [
                            19,19,10,19,18,18,10,18,16],
                        "productId": 4
                    },
                    {
                        "quantityOnHand": [
                            16,25,35,45,45,45,24,14,14],
                        "productId": 5
                    },
                    {
                        "quantityOnHand": [
                            32,132,92,31,91,31,11,30,30],
                        "productId": 6
                    },
                    {
                        "quantityOnHand": [
                            0,10,20,30,10,10,20,30,30],
                        "productId": 8
                    }
                ],
                "timeline": [
                    "2022-11-24T11:55:01.5577977",
                    "2022-11-24T12:55:01.9175985",
                    "2022-11-24T13:55:01.9420552",
                    "2022-11-24T14:55:01.9686225",
                    "2022-11-24T15:55:01.9957585",
                    "2022-11-24T16:59:43.4105543",
                    "2022-11-24T17:59:43.4566371",
                    "2022-11-24T18:59:43.4818207",
                    "2022-11-24T19:59:43.5041983"
                ]
            }
        }
    },
    methods:
    {

    },
    computed:
    {
        options() {            
            return {
                dataLabels: { enabled: false },
                fill: {
                    type: "gradient"
                },
                stroke: {
                    curve: "smooth"
                },                
                xaxis: {
                    categories: this.snapshot.timeline.map(t => moment(t).format('dd HHMMss')),
                    type: "datetime"
                    
                }
            }
        },
        series() {            
            return this.snapshot.productInventorySnapshots
                .map(snapshot => ({
                    name: snapshot.productId,
                    data: snapshot.quantityOnHand
                }))
        }
    },
    async created() {        
        await this.$store.dispatch('getSnapshotHistory');
        this.snapshot=this.$store.getters.snapshot

    }
}
</script>

<style scoped lang="scss">

</style>