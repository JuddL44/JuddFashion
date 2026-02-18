using JuddFashion.API.Models;

namespace JuddFashion.API.Data
{
    public class DbSeeder
    {
        public static void SeedData(ApplicationDbContext context)
        {
            if (context.Products.Any()) { return; }

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Snorlax Hoodie",
                    Description = "100% cotton hoodie with Snorlax design",
                    BasePrice = 59.99m,
                    Category = ClothingCategory.Outerwear,
                    Brand = "Pokemon Apparel",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSSZcx35C-L-DYnRy2mxelYAF6ama_BnPZVKw&s",
                    IsActive = true,
                    Variants = new List<ProductVariant>
                    {
                        new ProductVariant
                        {
                            Size = ClothingSize.XS,
                            Color = "Blue",
                            SKU = "SNORLAX-HOOD-BLUE-XS",
                            StockQuantity = 8,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.S,
                            Color = "Blue",
                            SKU = "SNORLAX-HOOD-BLUE-S",
                            StockQuantity = 7,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "Blue",
                            SKU = "SNORLAX-HOOD-BLUE-M",
                            StockQuantity = 12,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.L,
                            Color = "Blue",
                            SKU = "SNORLAX-HOOD-BLUE-L",
                            StockQuantity = 14,
                            PriceAdjustment = 0m
                        }
                    }
                },
                new Product
                {
                    Name = "Marsh Tee",
                    Description = "100% cotton t-shirt featuring an alligator and checkered flag graphic",
                    BasePrice = 29.99m,
                    Category = ClothingCategory.Tops,
                    Brand = "LZMFG",
                    ImageUrl = "https://lzmfg.com/cdn/shop/files/DSC05559_1800x1800.jpg?v=1726503488",
                    IsActive = true,
                    Variants = new List<ProductVariant>
                    {
                        new ProductVariant
                        {
                            Size = ClothingSize.XS,
                            Color = "Black",
                            SKU = "LZMFG-MARSH-BLACK-XS",
                            StockQuantity = 14,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.S,
                            Color = "Black",
                            SKU = "LZMFG-MARSH-BLACK-S",
                            StockQuantity = 5,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "Black",
                            SKU = "LZMFG-MARSH-BLACK-M",
                            StockQuantity = 2,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.S,
                            Color = "White",
                            SKU = "LZMFG-MARSH-WHITE-S",
                            StockQuantity = 5,
                            PriceAdjustment = 10m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.L,
                            Color = "White",
                            SKU = "LZMFG-MARSH-WHITE-L",
                            StockQuantity = 8,
                            PriceAdjustment = 10m
                        }
                    }
                },
                new Product
                {
                    Name = "Shogun Dad Hat",
                    Description = "Minimalist embroidered Shogun dad hat, relaxed fit",
                    BasePrice = 23.99m,
                    Category = ClothingCategory.Accessories,
                    Brand = "Popkiller",
                    ImageUrl = "https://www.popkiller.us/cdn/shop/products/shogun-orange-dad-cap.jpg?v=1759866857&width=1080",
                    IsActive = true,
                    Variants = new List<ProductVariant>
                    {
                        new ProductVariant
                        {
                            Size = ClothingSize.S,
                            Color = "Brown",
                            SKU = "PK-SHOGUN-BROWN-S",
                            StockQuantity = 11,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "Brown",
                            SKU = "PK-SHOGUN-BROWN-M",
                            StockQuantity = 9,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.L,
                            Color = "Brown",
                            SKU = "PK-SHOGUN-BROWN-L",
                            StockQuantity = 1,
                            PriceAdjustment = 0m
                        }
                    }
                },
                new Product
                {
                    Name = "Navy Slim Jeans",
                    Description = "Slim fit jeans with clean, modern look",
                    BasePrice = 19.99m,
                    Category = ClothingCategory.Bottoms,
                    Brand = "Old Navy",
                    ImageUrl = "https://media1.popsugar-assets.com/files/thumbor/gPOXXe1gbjR7Vhl809Mk8YJX0so=/0x0:3384x5000/fit-in/792x1170/filters:format_auto():upscale()/2023/02/13/751/n/1922564/0ab1f0ee63ea6d150cab02.23997105_.jpg",
                    IsActive = true,
                    Variants = new List<ProductVariant>
                    {
                        new ProductVariant
                        {
                            Size = ClothingSize.S,
                            Color = "Navy Blue",
                            SKU = "OLDNAVY-SLIMJEANS-NB-S",
                            StockQuantity = 8,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "Navy Blue",
                            SKU = "OLDNAVY-SLIMJEANS-NB-M",
                            StockQuantity = 2,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.L,
                            Color = "Navy Blue",
                            SKU = "OLDNAVY-SLIMJEANS-NB-L",
                            StockQuantity = 6,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.S,
                            Color = "Black",
                            SKU = "OLDNAVY-SLIMJEANS-BLACK-S",
                            StockQuantity = 16,
                            PriceAdjustment = 4m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "Black",
                            SKU = "OLDNAVY-SLIMJEANS-BLACK-M",
                            StockQuantity = 2,
                            PriceAdjustment = 4m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.L,
                            Color = "Black",
                            SKU = "OLDNAVY-SLIMJEANS-BLACK-L",
                            StockQuantity = 3,
                            PriceAdjustment = 4m
                        }
                    }
                },
                new Product
                {
                    Name = "Squidward Crocs",
                    Description = "Squidward themed Crocs with fun cartoon design",
                    BasePrice = 39.99m,
                    Category = ClothingCategory.Footwear,
                    Brand = "Crocs X Nickelodeon",
                    ImageUrl = "https://www.designscene.net/wp-content/uploads/2025/12/Crocs-SpongeBob-Collection-12.webp",
                    IsActive = true,
                    Variants = new List<ProductVariant>
                    {
                        new ProductVariant
                        {
                            Size = ClothingSize.S,
                            Color = "Olive",
                            SKU = "CROCS-SQUID-OLIVE-S",
                            StockQuantity = 4,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "Olive",
                            SKU = "CROCS-SQUID-OLIVE-M",
                            StockQuantity = 0,
                            PriceAdjustment = 1m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.L,
                            Color = "Olive",
                            SKU = "CROCS-SQUID-OLIVE-L",
                            StockQuantity = 3,
                            PriceAdjustment = 2m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.XL,
                            Color = "Olive",
                            SKU = "CROCS-SQUID-OLIVE-XL",
                            StockQuantity = 8,
                            PriceAdjustment = 2m
                        }
                    }
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
            Console.WriteLine("The database has been seeded successfully.");
        }
    }
}
