import { Routes } from '@angular/router';
import { Home } from './components/home/home';
import { Shop } from './components/shop/shop';
import { About } from './components/about/about';
import { Contact } from './components/contact/contact';
import { Account } from './components/account/account';
export const routes: Routes = [
    { path : '', component: Home },
    { path : 'shop', component: Shop },
    { path : 'about', component: About },
    { path : 'contact', component: Contact},
    { path : 'account', component: Account }
];
