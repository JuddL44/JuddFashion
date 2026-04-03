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

  username?: string = '';
  checkoutMessage: string = '';

  checkingOut: boolean = false;

  recentTotal: number = 0;
  recentItems: number = 0;
  cartItems: number = 0;
  taxPercentage: number = 0.072;
  subtotal: number = 0;

  ngOnInit() {
    this.cartService.loadCart();
    const user = this.authService.getCurrentUser();
    this.username = user?.username;
    this.cart$.subscribe((cart) => {
      if (cart) {
        this.subtotal = cart.totalPrice;
        this.cartItems = cart.items.length;
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

  checkoutCart() {
    if (this.checkingOut) return;

    this.checkingOut = true;
    this.recentItems = this.cartItems;

    this.cartService.checkout().subscribe({
      next: (result) => {
        if (result.success) {
          this.subtotal = 0;
          this.recentTotal = Number(result.totalAmount.toFixed(2));
          this.checkoutMessage = '';
        } else {
          this.checkoutMessage = result.message;
        }
        this.checkingOut = false;
      },
      error: (error) => {
        this.checkoutMessage = error.error?.message || 'Checkout failed. Please try again.';
        this.checkingOut = false;
      },
    });
  }
}
