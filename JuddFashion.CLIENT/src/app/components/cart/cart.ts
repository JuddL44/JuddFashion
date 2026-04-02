import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Carts } from '../../services/carts';
import { Auth } from '../../services/auth';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './cart.html',
  styleUrl: './cart.scss',
})
export class Cart implements OnInit {
  cartService = inject(Carts);
  authService = inject(Auth);

  cart$ = this.cartService.cart$;
  taxPercentage: number = 0.072;
  subtotal: number = 0;
  username?: string = '';

  ngOnInit() {
    this.cartService.loadCart();
    const user = this.authService.getCurrentUser();
    this.username = user?.username;
    this.cart$.subscribe((cart) => {
      if (cart) {
        this.subtotal = cart.totalPrice;
      }
    });
  }

  updateQuantity(cartItemId: number, quantity: number) {
    const cart = this.cartService.getCart();
    const item = cart?.items.find((i) => i.id === cartItemId);

    if (!item) return;

    const newQuantity = item.quantity + quantity;

    if (newQuantity <= 0) {
      return;
    }
    this.cartService.updateCartItem(cartItemId, newQuantity).subscribe();
  }

  removeItem(cartItemId: number) {
    this.cartService.removeFromCart(cartItemId).subscribe({
      next: () => {
        console.log('Item removed');
      },
    });
  }

  clearCart() {
    this.subtotal = 0;
    this.cartService.clearCart().subscribe();
  }

  link: string =
    'https://cdn.discordapp.com/attachments/1453198131343921287/1487617771830513674/63261302-4519-455d-b458-0c7571d87392.png?ex=69ce68c3&is=69cd1743&hm=1500a6e92160eb757123d46bd88154e16aa30e1eba7a3e5081f5c9a4184d85fc&';
}
