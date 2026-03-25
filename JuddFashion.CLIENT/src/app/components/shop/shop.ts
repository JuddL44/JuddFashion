import { Component, OnInit, inject, ChangeDetectorRef, booleanAttribute } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Product, ProductVariant } from '../../models/product';
import { HttpClient, HttpClientModule } from '@angular/common/http';



@Component({
  selector: 'app-shop',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './shop.html',
  styleUrl: './shop.scss',
})
export class Shop implements OnInit {
  private http = inject(HttpClient);
  private cdr = inject(ChangeDetectorRef);
  
  currentProductDisplay: string = "All Products";
  heroTitle: string = `Our Products`;
  heroSubtitle: string = '2026 Collection';
  apiExtension: string = '';
  featuredItemCount: number = 3;
  featuredProducts: Product[] = [];
  featuredClothingIndex: number = 0;
  featuredClothingIncrement: number = 4;
  containsMoreFeatured: boolean = true;

  
  ngOnInit() {
    this.loadMoreProducts();
  }
  


  loadMoreProducts() {
    console.log("Loading more products");
    this.http.get<Product[]>(`http://localhost:5191/api/products${this.apiExtension}`).subscribe({
      next: (products) => {
        this.featuredClothingIndex += this.featuredClothingIncrement;
        this.featuredProducts = [...this.featuredProducts, ...products.slice(this.featuredClothingIndex - this.featuredClothingIncrement, this.featuredClothingIndex)]
        if (products.length <= this.featuredClothingIndex) {this.containsMoreFeatured = false;}
        this.cdr.detectChanges();
      }
    })
  }


  loadFilterTabProducts(tab: string) {

    this.currentProductDisplay = tab;
    let resetIndex: boolean = (this.apiExtension !== `/category/${tab}`);
    this.apiExtension = `/category/${tab}`;

    if (tab === "All") 
    {
      this.apiExtension = "";
      this.currentProductDisplay = this.currentProductDisplay + " Products";
    }
    if (resetIndex)
    {
      this.containsMoreFeatured = true;
      this.featuredProducts = [];
      this.featuredClothingIndex = 0;
    }
    this.loadMoreProducts();
  }
}
