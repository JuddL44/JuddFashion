import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './navbar.html',
  styleUrl: './navbar.scss',
})


export class Navbar {
  brandName: string = `🦋 Judd Fashion`;
  motto: string = `It's judd fashionable.`;

  navLinks = [
      { label: 'Home', path: '/' },
      { label: 'Shop', path: '/shop'},
      { label: 'About', path: '/about'},
      { label: 'Contact', path: '/contact'}
  ];

  menuOpen: boolean = false;

  toggleMenu() {
    this.menuOpen = !this.menuOpen;
  }
}
