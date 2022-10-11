import { createApp, defineAsyncComponent } from 'vue'
import App from './App.vue'

import router from './router/router.js'
import store from './store/index.js'

// import axios from 'axios'
// import VueAxios from 'vue-axios'

import './assets/main.css'

const BaseCard = defineAsyncComponent(()=>import('./components/ui/BaseCard.vue'));
const BaseButton = defineAsyncComponent(()=>import('./components/ui/BaseButton.vue'));
const BaseBadge = defineAsyncComponent(() => import('./components/ui/BaseBadge.vue'));
const BaseSpinner = defineAsyncComponent(()=>import('./components/ui/BaseSpinner.vue'));
const BaseDialog = defineAsyncComponent(() => import('./components/ui/BaseDialog.vue'));

const app = createApp(App)

app.use(router)
app.use(store)
// app.use(VueAxios, axios)

app.component('base-card', BaseCard);
app.component('base-button', BaseButton);
app.component('base-badge', BaseBadge);
app.component('base-spinner', BaseSpinner);
app.component('base-dialog', BaseDialog);

app.mount('#app')
