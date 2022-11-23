<template>
  <div>
   
    <apex-chart
      type="area"
      :width="'100%'"
      height="300"
      :options="options"
      :series="series"
      >
    </apex-chart>
  </div>
</template>

<script>
//import { Sync } from "vuex-pathify";
export default {
    props:[
        'snapshot'
    ],
    
    data()
    {
        return{
            options: {
                chart: {
                    id: 'vuechart-example'
                },
                xaxis: {
                    categories: [1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998],
                    //timeline:this.snapshot.timeline
                }
            },
            series:
            [{
                name: 'series-1',
                data: [30, 40, 45, 50, 49, 60, 70, 91]
            }],
            snapshotTimeline: {
                productInventorySnapshots: [
                    {
                        productId: 0,
                        quantityOnHand: [],
                    }
                ],
                timeline: [],
            },
            
        }
    },
    methods:
    {
        
    },
    computed:
    {
        
    },
    created(){
       console.log(this.snapshot.timeline)
    }
}
</script>

<style scoped lang="scss">

</style>