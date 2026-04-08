import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { Auth } from './auth';
import { environment } from '../../environment/environment';

@Injectable({
  providedIn: 'root',
})
export class Carts {
  private http = inject(HttpClient);
  private authService = inject(Auth);
  private apiUrl = `${environment.apiUrl}/cart`;

  private cartSubject = new BehaviorSubject<Cart | null>(null);
  public cart$ = this.cartSubject.asObservable();

  constructor() {
    if (this.authService.isLoggedIn()) {
      this.loadCart();
    }
  }

  private getHeaders(): HttpHeaders {
    const token = this.authService.getToken();
    return new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });
  }

  loadCart(): void {
    this.http.get<Cart>(this.apiUrl, { headers: this.getHeaders() }).subscribe({
      next: (cart) => {
        this.cartSubject.next(cart);
      },
      error: (error) => {
        console.error('Error loading cart: ', error);
      },
    });
  }

  addToCart(productVariantId: number, quantity: number = 1): Observable<Cart> {
    const request: AddToCartRequest = { productVariantId, quantity };
    return this.http.post<Cart>(this.apiUrl, request, { headers: this.getHeaders() }).pipe(
      tap((cart) => {
        this.cartSubject.next(cart);
        console.log('Item added to cart: ', cart);
      }),
    );
  }

  updateCartItem(cartItemId: number, quantity: number): Observable<Cart> {
    return this.http
      .put<Cart>(`${this.apiUrl}/${cartItemId}?quantity=${quantity}`, null, {
        headers: this.getHeaders(),
      })
      .pipe(
        tap((cart) => {
          this.cartSubject.next(cart);
        }),
      );
  }

  removeFromCart(cartItemId: number): Observable<void> {
    return this.http
      .delete<void>(`${this.apiUrl}/${cartItemId}`, {
        headers: this.getHeaders(),
      })
      .pipe(
        tap(() => {
          this.loadCart();
        }),
      );
  }

  clearCart(): Observable<void> {
    return this.http
      .delete<void>(`${this.apiUrl}/clear`, {
        headers: this.getHeaders(),
      })
      .pipe(
        tap(() => {
          this.cartSubject.next(null);
        }),
      );
  }

  checkout(): Observable<CheckoutResult> {
    return this.http
      .post<CheckoutResult>(`${this.apiUrl}/checkout`, null, {
        headers: this.getHeaders(),
      })
      .pipe(
        tap((result) => {
          if (result.success) {
            this.cartSubject.next(null);
          }
        }),
      );
  }

  getCart(): Cart | null {
    return this.cartSubject.value;
  }

  getTotalItems(): number {
    return this.cartSubject.value?.totalItems ?? 0;
  }
}

interface CartItem {
  id: number;
  productVariantId: number;
  quantity: number;
  productName: string;
  productDescription: string;
  productImageUrl: string;
  category: string;
  brand: string;
  size: string;
  color: string;
  price: number;
  stockQuantity: number;
}

interface Cart {
  id: number;
  items: CartItem[];
  totalPrice: number;
  totalItems: number;
}

interface AddToCartRequest {
  productVariantId: number;
  quantity: number;
}

interface CheckoutResult {
  success: boolean;
  message: string;
  outOfStockItems: string[];
  totalAmount: number;
}
