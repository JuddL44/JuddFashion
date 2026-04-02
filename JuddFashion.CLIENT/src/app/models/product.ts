export interface ProductVariant {
  id: number;
  size: string;
  color: string;
  sku: string;
  stockQuantity: number;
  priceAdjustment: number;
  finalPrice: number;
  inStock: boolean;
}
export interface Product {
  id: number;
  name: string;
  description: string;
  basePrice: number;
  category: string;
  brand: string;
  imageUrl: string;
  dateAdded: string;
  variants: ProductVariant[];
  totalStock: number;
  isAvailable: boolean;
  availableColors: string[];
  availableSizes: string[];
}
