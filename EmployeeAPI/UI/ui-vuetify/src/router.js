import Vue from 'vue'
import Router from 'vue-router'

import NotFound from './pages/NotFound.vue';

import EmployeeList from './pages/employees/EmployeeList.vue';
import EmployeeDetail from './pages/employees/EmployeeDetail.vue';
import ProjectList from './pages/projects/ProjectList.vue';
import EmployeeRegistration from './pages/employees/EmployeeRegistration.vue';


Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
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
      // какого-то хера не работает маршрут
      path: '/employee/register',
      component: EmployeeRegistration,
      props: true,      
    },
    {
      path: '/employee/edit/:id',
      component: EmployeeRegistration,
      props: true
    },
    {
      path: '/projects',
      name: 'projects',      
      component:  ProjectList
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