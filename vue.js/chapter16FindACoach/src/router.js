import { defineAsyncComponent } from 'vue';
import { createRouter, createWebHistory} from 'vue-router';

import CoachList from './pages/coaches/CoachesList.vue';
// import RegisterCoaches from './pages/coaches/CoachRegistration.vue';
// import CoachDetail from './pages/coaches/CoachDetail.vue';
// import ContactCoach from './pages/requests/ContactCoach.vue';
// import RequestsReceived from './pages/requests/RequestsRecieved.vue';
// import UserAuth from './pages/auth/UserAuth.vue';
import NotFound from './pages/NotFound.vue';
import store from './store/index.js';

const CoachDetail = defineAsyncComponent(() => import ('./pages/coaches/CoachDetail.vue'));
const RegisterCoaches = defineAsyncComponent(()=> import('./pages/coaches/CoachRegistration.vue'));
const ContactCoach = defineAsyncComponent(() => import('./pages/requests/ContactCoach.vue'));
const RequestsReceived = defineAsyncComponent(() => import('./pages/requests/RequestsRecieved.vue'));
const UserAuth = defineAsyncComponent(() => import('./pages/auth/UserAuth.vue'));

const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: '/', redirect: '/coaches' },
        { path: '/coaches', component: CoachList },
        { path: '/coaches/:id', 
            component: CoachDetail,
            props: true, 
            children:[
                { path: 'contact', component: ContactCoach }]
        },
        { path: '/register', component: RegisterCoaches, meta:{ requiresAuth: true } },
        { path: '/requests', component: RequestsReceived, meta:{ requiresAuth: true } },
        { path: '/auth', component: UserAuth, meta: { requiresUnauth: true }},
        { path: '/:notFound(.*)', component: NotFound },
    ]
});

router.beforeEach(function(to, _, next){
    if(to.meta.requiresAuth && !store.getters.isAuthenticated){
        next('/auth');
    } else if(to.meta.requiresUnauth && store.getters.isAuthenticated){
        next('/coaches');
    } else {
        next();
    }
})

export default router;

