import { Component, OnInit, inject, ChangeDetectorRef, booleanAttribute } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Product, ProductVariant } from '../../models/product';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { RouterLink, RouterModule } from '@angular/router';

@Component({
  selector: 'app-shop',
  standalone: true,
  imports: [CommonModule, HttpClientModule, RouterLink, RouterModule],
  templateUrl: './shop.html',
  styleUrl: './shop.scss',
})
export class Shop implements OnInit {
  private http = inject(HttpClient);
  private cdr = inject(ChangeDetectorRef);

  allProductTabs: string[] = ['All', 'Tops', 'Outerwear', 'Bottoms', 'Footwear', 'Accessories'];

  currentProductDisplay: string = 'All Products';
  currentProductCategory: string = 'All';
  currentProductSearch: string = '';
  currentProductSort: string = '';

  heroTitle: string = `Our Products`;
  heroSubtitle: string = '2026 Collection';

  featuredItemCount: number = 3;
  featuredProducts: Product[] = [];
  featuredClothingIndex: number = 0;
  featuredClothingIncrement: number = 4;
  containsMoreFeatured: boolean = true;

  isLoading: boolean = false;

  apiExtension: string = '';
  apiExtensionSearch: string = '/search?query=';
  apiExtensionCategory: string = '';
  apiExtensionSortBy: string = '';

  ngOnInit() {
    this.loadMoreProducts();
  }

  loadMoreProducts() {
    console.log('Loading more products' + ' ' + this.currentProductDisplay);
    this.http.get<Product[]>(`http://localhost:5191/api/products${this.apiExtension}`).subscribe({
      next: (products) => {
        this.featuredClothingIndex += this.featuredClothingIncrement;
        this.featuredProducts = [
          ...this.featuredProducts,
          ...products.slice(
            this.featuredClothingIndex - this.featuredClothingIncrement,
            this.featuredClothingIndex,
          ),
        ];
        if (products.length <= this.featuredClothingIndex) {
          this.containsMoreFeatured = false;
        }
        this.isLoading = false;
        this.cdr.detectChanges();
      },
    });
  }

  applyFilter(tab: string, type: string) {
    this.isLoading = true;
    this.containsMoreFeatured = true;
    this.featuredProducts = [];
    this.featuredClothingIndex = 0;

    switch (type) {
      case 'search':
        this.apiExtensionSearch = `/search?query=${tab}`;
        this.currentProductSearch = tab;
        break;
      case 'filter':
        this.apiExtensionCategory = `&category=${tab}`;
        this.currentProductCategory = tab;
        break;
      case 'sort':
        if (this.currentProductSort === tab) {
          this.currentProductSort = '';
          this.apiExtensionSortBy = '';
        } else {
          this.apiExtensionSortBy = `&sortBy=${tab}`;
          this.currentProductSort = tab;
        }
        break;
    }

    if (tab === 'All') {
      this.apiExtensionCategory = '';
    }

    this.apiExtension =
      this.apiExtensionSearch + this.apiExtensionCategory + this.apiExtensionSortBy;
    this.currentProductDisplay = `${this.currentProductCategory}`;

    if (this.currentProductCategory === 'All') {
      this.currentProductDisplay += ' Products';
    }
    if (this.currentProductSearch !== '') {
      this.currentProductDisplay += ` - \"${this.currentProductSearch}\"`;
    }
    this.loadMoreProducts();
  }
}
