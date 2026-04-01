import { Component, OnInit, inject, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { Product } from '../../models/product';


@Component({
  selector: 'app-productpage',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './productpage.html',
  styleUrl: './productpage.scss',
})
export class Productpage implements OnInit {
  private route = inject(ActivatedRoute);
  private http = inject(HttpClient);
  private cdr = inject(ChangeDetectorRef);
  private router = inject(Router);

  identity: number = 0;
  product: Product | null = null;

  loading: boolean = true;
  nothingFound: boolean = false;
  limitWarning: boolean = false;
  addedToCart: boolean = false;

  allColors: string[] = [];
  allSizes: string[] = [];
  currentColor: string = '';
  currentSize: string = '';
  currentPrice?: string = '';

  itemCount?: string = "0 left";



  ngOnInit()
  {
    const id = this.route.snapshot.params['id'];
    this.identity = id;
    this.http.get<Product>(`http://localhost:5191/api/products/${id}`).subscribe({
      next: (product) => {
        this.product = product;
        this.loading = false;
        const allColors = this.product?.variants.map(p => p.color);
        this.allColors = [...new Set(allColors)]
        this.ChangeColor(this.allColors[0]);
      },
      error: (error) => {
        this.loading = false;
        this.nothingFound = true;
      }
    });
  }


  ChangeColor(color: string)
  {
    this.currentColor = color;
    this.allSizes = [""];
    const allVariants = this.product?.variants.filter(p => p.color === color); 
    const Sizes = allVariants?.map(p => p.size);
    this.allSizes = [...new Set(Sizes)];
    this.cdr.detectChanges();
    this.ChangeSize(this.allSizes[0]);
  }

  ChangeSize(size: string)
  {
    this.currentSize = size;
    this.cdr.detectChanges();
    const prod = this.product?.variants.find(p => p.color === this.currentColor && p.size === size);
    const quantity = prod?.stockQuantity;
    if (quantity !== undefined && quantity <= 0)
    {
      this.itemCount = "out of stock";
      this.limitWarning = false;
    }
    else
    {
        this.itemCount = quantity?.toString() + " left"; 
        this.limitWarning = (quantity !== undefined && quantity <= 4);
    }
    this.currentPrice = prod?.finalPrice.toString();
  }

  AddToCart()
  {
    this.addedToCart = true;
    setTimeout(() => {
      this.router.navigate(['/shop']);
    }, 2000);
  }

}
