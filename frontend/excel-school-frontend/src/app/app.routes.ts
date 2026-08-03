import { Routes } from '@angular/router';
import { Dashboard } from './features/dashboard/dashboard';
import { Login } from './features/auth/login/login';
import { StudentsList } from './features/students/students-list/students-list';
import { MainLayout } from './shared/main-layout/main-layout';

export const routes: Routes = [
  { path: 'login', component: Login },
  {
    path: '',
    component: MainLayout,
    children: [
      { path: 'dashboard', component: Dashboard, data: { role: 'admin' } },
      { path: 'students', component: StudentsList },
    ],
  },
];
