import { Routes } from '@angular/router';
import { Home } from './components/home/home';
import { Shop } from './components/shop/shop';
export const routes: Routes = [
    { path : '', component: Home },
    { path : 'shop', component: Shop }
];
