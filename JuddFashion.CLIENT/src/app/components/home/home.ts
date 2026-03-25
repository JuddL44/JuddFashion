import { Component, OnInit, inject, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Product, ProductVariant } from '../../models/product';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
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
  
  ngOnInit() {
    this.loadRandomFeaturedItems();
  }
  
  loadRandomFeaturedItems() {
    console.log('Starting to fetch products...');
  
  this.http.get<Product[]>('http://localhost:5191/api/products').subscribe({
    next: (products) => {
      const shuffled = products.sort(() => 0.5 - Math.random());
      this.featuredProducts = shuffled.slice(0, 3);
      this.cdr.detectChanges();
      console.log(this.featuredProducts);
  }});
  }
}