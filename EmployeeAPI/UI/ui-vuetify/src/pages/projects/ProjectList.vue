<template>
    <v-container >
        <v-layout row>
            <base-dialog :show="!!error" title="An error occurred!" 
                @close="handleError">
                <p>{{ error }}</p>
            </base-dialog>   
            <div v-if="isLoading">
                <base-spinner></base-spinner>
            </div>
        </v-layout>
        <v-layout row justify-center >
            <v-card
            class="mx-1"
            min-width="300"
            max-width="400"
        >
            <v-list>
            <v-list-item-group
                v-model="model"
                mandatory
                color="indigo"
            >
                <v-list-item
                v-for="(item, i) in items"
                :key="i"
                >
                <v-list-item-icon>
                    <v-icon v-text="item.icon"></v-icon>
                </v-list-item-icon>

                <v-list-item-content>
                    <v-list-item-title v-text="item.text"></v-list-item-title>
                </v-list-item-content>
            </v-list-item>
        </v-list-item-group>
    </v-list>
        </v-card>
        
        <v-card
        class="mx-1"
        max-width="400">
        <v-list-item two-line>
            <v-list-item-content>
        <v-list-item-title class="text-h5">
            {{ model }}
        </v-list-item-title>
        <v-list-item-subtitle>Mon, 12:30 PM, Mostly sunny</v-list-item-subtitle>
      </v-list-item-content>
    </v-list-item>

    <v-card-text>
      <v-row align="center">
        <v-col
          class="text-h2"
          cols="6"
        >
          23&deg;C
        </v-col>
        <v-col cols="6">
            <v-img
            src="https://cdn.vuetifyjs.com/images/cards/sun.png"
            alt="Sunny image"
            width="92"
          ></v-img>
        </v-col>
      </v-row>
    </v-card-text>

    <v-list-item>
        <v-list-item-icon>
            <v-icon>mdi-send</v-icon>
        </v-list-item-icon>
      <v-list-item-subtitle>23 km/h</v-list-item-subtitle>
    </v-list-item>
    
    <v-list-item>
        <v-list-item-icon>
        <v-icon>mdi-cloud-download</v-icon>
    </v-list-item-icon>
      <v-list-item-subtitle>48%</v-list-item-subtitle>
    </v-list-item>

    <v-slider
    v-model="time"
    :max="6"
    :tick-labels="labels"
    class="mx-4"
    ticks
    ></v-slider>
    
    <v-list class="transparent">
        <v-list-item
        v-for="item in forecast"
        :key="item.day"
        >
        <v-list-item-title>{{ item.day }}</v-list-item-title>
        
        <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
        </v-list-item-icon>
        
        <v-list-item-subtitle class="text-right">
            {{ item.temp }}
        </v-list-item-subtitle>
    </v-list-item>
    </v-list>
    
    <v-divider></v-divider>

    <v-card-actions>
      <v-btn text>
        Full Report
    </v-btn>
</v-card-actions>

</v-card>
</v-layout>
</v-container>
</template>

<script>
export default {
    data: () => ({
        isLoading: false,
            error: null,
        items: [
            {
            icon: 'mdi-wifi',
            text: 'Wifi',
            },
            {
            icon: 'mdi-bluetooth',
            text: 'Bluetooth',
            },
            {
            icon: 'mdi-chart-donut',
            text: 'Data Usage',
            },
        ],
        model: 1,

      labels: ['SU', 'MO', 'TU', 'WED', 'TH', 'FR', 'SA'],
        time: 0,
        forecast: [
          { day: 'Tuesday', icon: 'mdi-white-balance-sunny', temp: '24\xB0/12\xB0' },
          { day: 'Wednesday', icon: 'mdi-white-balance-sunny', temp: '22\xB0/14\xB0' },
          { day: 'Thursday', icon: 'mdi-cloud', temp: '25\xB0/15\xB0' },
        ],
    }),
    watch:{
        model(){
            console.log(this.model);
        }
    },
    methods: {
        handleError() {
            this.error = null;
        },
        async loadProjects(){
            this.isLoading = true;
            try{
                await this.$store.dispatch('projects/loadProjects');
            } catch (error){
                this.error = error.message || 'Something went wrong!';
            }
            this.isLoading=false
        },
    },
    created(){
        this.loadProjects();
    }
}
</script>