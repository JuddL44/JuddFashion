import { Component, OnInit, inject, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Product, ProductVariant } from '../../models/product';
import { RouterModule } from '@angular/router';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, HttpClientModule, RouterModule],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home implements OnInit {
  private http = inject(HttpClient);
  private cdr = inject(ChangeDetectorRef);
  
  heroTitle: string = `Welcome to Judd Fashion`;
  heroSubtitle: string = 'Premium streetwear & accessories';
  featuredItemCount: number = 3;
  featuredProducts: Product[] = [];
  isLoading: boolean = false;
  
  ngOnInit() {
    this.loadRandomFeaturedItems();
  }
  
  loadRandomFeaturedItems() {
  this.isLoading = true;
  this.http.get<Product[]>('http://localhost:5191/api/products').subscribe({
    next: (products) => {
      const shuffled = products.sort(() => 0.5 - Math.random());
      this.featuredProducts = shuffled.slice(0, 3);
      this.cdr.detectChanges();
      this.isLoading = false;
  }});
  }
}