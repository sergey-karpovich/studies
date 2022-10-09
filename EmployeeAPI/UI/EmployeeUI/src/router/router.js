import { createRouter, createWebHistory } from 'vue-router'
import NotFound from '../pages/NotFound.vue';

import EmployeeList from '../pages/employee/EmployeeList.vue';
import EmployeeDetail from '../pages/employee/EmployeeDetail.vue';

const router = createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: '/',
      redirect: '/employee'
    },
    {
      path: '/employee',
      name: 'employee',      
      component: EmployeeList
    },
    {
      path: '/employee/:id',
      component: EmployeeDetail,
      props: true,
    },
    {
      path: '/projects',
      name: 'projects',      
      component: () => null
    },
    {
      path: '/workTime',
      name: 'workTime',      
      component: () => null
    },
    {
      path: '/printReport',
      name: 'printReport',      
      component: () => null
    },
    { path: '/:notFound(.*)', component: NotFound },
  ]
})

export default router
