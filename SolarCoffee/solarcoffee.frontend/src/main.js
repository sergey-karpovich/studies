import Vue from 'vue'
import App from './App.vue'
import router from './router/index.js'
import store from './store/index.js'
import moment  from 'moment'
import VueApexCharts from 'vue-apexcharts'




Vue.config.productionTip = false

Vue.use(VueApexCharts)
Vue.component('apex-chart', VueApexCharts)

Vue.filter('price', function(number){
  if(isNaN(number)){
    return '-';
  }
  return '$ '+number.toFixed(2);
});
Vue.filter('humanizeDate', function(date){ 
  return moment(date).format('MMMM Do YYYY');
});

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app')
