import Vue from 'vue'
import Router from 'vue-router'

import NotFound from './pages/NotFound.vue';

import EmployeeList from './pages/employees/EmployeeList.vue';
import EmployeeDetail from './pages/employees/EmployeeDetail.vue';
import ProjectList from './pages/projects/ProjectList.vue';
import EmployeeRegistration from './pages/employees/EmployeeRegistration.vue';
import TimeTracking from './pages/workTime/TimeTracking.vue';
import PrintReport from './pages/reports/PrintReports.vue';

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
    // {
    //   // какого-то хера не работает маршрут
    //   path: '/employee/register',
    //   component: EmployeeRegistration,
    //   props: true,      
    // },
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
      path: '/timeTracking',
      name: 'timeTracking',      
      component: TimeTracking
    },
    {
      path: '/printReport',
      name: 'printReport',      
      component: PrintReport
    },
    { path: '/:notFound(.*)', component: NotFound },
  ]
})