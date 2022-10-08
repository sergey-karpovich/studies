import { createRouter, createWebHistory } from 'vue-router'
import NotFound from './pages/NotFound.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      redirect: '/employee'
    },
    {
      path: '/employee',
      name: 'employee',      
      component: () => import('../pages/employee/EmployeeList.vue')
    },
    {
      path: '/projects',
      name: 'projects',      
      component: () => {title: "Projects"}
    },
    {
      path: '/worktime',
      name: 'worktime',      
      component: () => {title:"worktime"}
    },
    {
      path: '/printreport',
      name: 'printreport',      
      component: () => {title: "print report"}
    },
    { path: '/:notFound(.*)', component: NotFound },
  ]
})

export default router
