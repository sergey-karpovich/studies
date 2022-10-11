import { createRouter, createWebHistory } from 'vue-router'
import NotFound from '../pages/NotFound.vue';

import EmployeeList from '../pages/employees/EmployeeList.vue';
import EmployeeDetail from '../pages/employees/EmployeeDetail.vue';
import ProjectList from '../pages/projects/ProjectList.vue';
import EmployeeRegistration from '../pages/employees/EmployeeRegistration.vue';

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
      path: '/employee/register',
      component: EmployeeRegistration,
    },
    {
      path: '/projects',
      name: 'projects',      
      component: () => ProjectList
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
