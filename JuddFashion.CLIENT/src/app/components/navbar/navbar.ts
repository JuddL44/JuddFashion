import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Carts } from '../../services/carts';
import { Auth } from '../../services/auth';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './navbar.html',
  styleUrl: './navbar.scss',
})
export class Navbar {
  authService = inject(Auth);
  cartService = inject(Carts);

  brandName: string = `🦋 Judd Fashion`;
  motto: string = `It's judd fashionable.`;
  cartCount: number = 0;

  navLinks = [
    { label: 'Home', path: '/' },
    { label: 'Shop', path: '/shop' },
    { label: 'About', path: '/about' },
    { label: 'Contact', path: '/contact' },
  ];

  navLinksExtended = [
    { label: 'Home', path: '/' },
    { label: 'Shop', path: '/shop' },
    { label: 'Account', path: '/account' },
    { label: 'About', path: '/about' },
    { label: 'Contact', path: '/contact' },
  ];

  menuOpen: boolean = false;

  toggleMenu() {
    this.menuOpen = !this.menuOpen;
  }

  ngOnInit() {
    this.cartService.cart$.subscribe((cart) => {
      this.cartCount = cart?.totalItems ?? 0;
    });
  }
}
