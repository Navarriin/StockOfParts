import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./pages/home/home.component').then((page) => page.HomeComponent),
  },
  {
    path: 'list',
    loadComponent: () =>
      import('./pages/list/list.component').then((page) => page.ListComponent),
  },
  {
    path: 'form',
    loadComponent: () =>
      import('./pages/form/form.component').then((page) => page.FormComponent),
  },
  {
    path: 'form/:id',
    loadComponent: () =>
      import('./pages/form/form.component').then((page) => page.FormComponent),
  },
  {
    path: '**',
    redirectTo: '',
  },
];
