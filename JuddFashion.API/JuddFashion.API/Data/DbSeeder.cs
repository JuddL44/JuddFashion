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
                    Name = "Hiking Knee-Pockets",
                    Description = "Plain Color Hiking Style Knee Pocket Pants",
                    BasePrice = 22.99m,
                    Category = ClothingCategory.Bottoms,
                    Brand = "Slick Street",
                    ImageUrl = "https://shopslickstreet.com/cdn/shop/files/Se5b3ab654b3f4d4daaa146c81f1658b7M.webp?v=1710969031",
                    IsActive = true,
                    Variants = new List<ProductVariant>
                    {
                        new ProductVariant
                        {
                            Size = ClothingSize.XS,
                            Color = "Plain",
                            SKU = "SLST-HKP-PLAIN-XS",
                            StockQuantity = 8,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.S,
                            Color = "Plain",
                            SKU = "SLST-HKP-PLAIN-S",
                            StockQuantity = 5,
                            PriceAdjustment = 1m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "Plain",
                            SKU = "SLST-HKP-PLAIN-M",
                            StockQuantity = 4,
                            PriceAdjustment = 1m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.L,
                            Color = "Plain",
                            SKU = "SLST-HKP-PLAIN-L",
                            StockQuantity = 7,
                            PriceAdjustment = 2m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.XS,
                            Color = "Black",
                            SKU = "SLST-HKP-BLACK-XS",
                            StockQuantity = 13,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.S,
                            Color = "Black",
                            SKU = "SLST-HKP-BLACK-S",
                            StockQuantity = 2,
                            PriceAdjustment = 1m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "Black",
                            SKU = "SLST-HKP-BLACK-M",
                            StockQuantity = 1,
                            PriceAdjustment = 1m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.L,
                            Color = "Black",
                            SKU = "SLST-HKP-BLACK-L",
                            StockQuantity = 15,
                            PriceAdjustment = 2m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.XS,
                            Color = "Yellow",
                            SKU = "SLST-HKP-YELLOW-XS",
                            StockQuantity = 0,
                            PriceAdjustment = 2m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.S,
                            Color = "Yellow",
                            SKU = "SLST-HKP-YELLOW-S",
                            StockQuantity = 4,
                            PriceAdjustment = 3m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "Yellow",
                            SKU = "SLST-HKP-YELLOW-M",
                            StockQuantity = 14,
                            PriceAdjustment = 3m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.L,
                            Color = "Yellow",
                            SKU = "SLST-HKP-YELLOW-L",
                            StockQuantity = 1,
                            PriceAdjustment = 5m
                        }
                    }
                },
                new Product
                {
                    Name = "Donkey Goggles",
                    Description = "Orange and blue sunglasses that live to stand out from the drove.",
                    BasePrice = 29.99m,
                    Category = ClothingCategory.Outerwear,
                    Brand = "goodr",
                    ImageUrl = "https://goodr.com/cdn/shop/files/5_DONKEY_GOGGLES_Featured_7125bc59-c54b-45ee-8bb2-4e3707c8c816.jpg?crop=center&pad_color=ffffff&v=1689751010&width=1600",
                    IsActive = true,
                    Variants = new List<ProductVariant>
                    {
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "Orange",
                            SKU = "GDR-DOGO-ORANGE-M",
                            StockQuantity = 8,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "Green",
                            SKU = "GDR-DOGO-GREEN-M",
                            StockQuantity = 3,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "Yellow",
                            SKU = "GDR-DOGO-YELLOW-M",
                            StockQuantity = 5,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "Brown",
                            SKU = "GDR-DOGO-BROWN-M",
                            StockQuantity = 0,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "White",
                            SKU = "GDR-DOGO-WHITE-M",
                            StockQuantity = 2,
                            PriceAdjustment = 0m
                        },
                    }
                },
                new Product
                {
                    Name = "Pine Varsity Jacket",
                    Description = "Crafted with wool & leather sleeves for warmth, comfort, and versatile style.",
                    BasePrice = 89.99m,
                    Category = ClothingCategory.Outerwear,
                    Brand = "Lastwolf Apparel",
                    ImageUrl = "https://lastwolf.us/cdn/shop/files/Pine-Varsity-jacket-3.jpg?v=1725560187&width=1024",
                    IsActive = true,
                    Variants = new List<ProductVariant>
                    {
                        new ProductVariant
                        {
                            Size = ClothingSize.XS,
                            Color = "Green",
                            SKU = "LASTWOLF-PV-GREEN-XS",
                            StockQuantity = 8,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.S,
                            Color = "Green",
                            SKU = "LASTWOLF-PV-GREEN-S",
                            StockQuantity = 5,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "Green",
                            SKU = "LASTWOLF-PV-GREEN-M",
                            StockQuantity = 12,
                            PriceAdjustment = 3m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.L,
                            Color = "Green",
                            SKU = "LASTWOLF-PV-GREEN-L",
                            StockQuantity = 2,
                            PriceAdjustment = 5m
                        }
                    }
                },
                new Product
                {
                    Name = "Air Sneakers",
                    Description = "Black Cushion Comfort Shoes Lace Up Casual Shoe For Men",
                    BasePrice = 39.99m,
                    Category = ClothingCategory.Footwear,
                    Brand = "Basoles",
                    ImageUrl = "https://i.ebayimg.com/images/g/JMQAAOSwW1dmudFt/s-l1200.jpg",
                    IsActive = true,
                    Variants = new List<ProductVariant>
                    {
                        new ProductVariant
                        {
                            Size = ClothingSize.XS,
                            Color = "Black",
                            SKU = "BASOLES-AIRS-BLACK-XS",
                            StockQuantity = 3,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.S,
                            Color = "White",
                            SKU = "BASOLES-AIRS-WHITE-S",
                            StockQuantity = 15,
                            PriceAdjustment = 10m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "White",
                            SKU = "BASOLES-AIRS-WHITE-M",
                            StockQuantity = 4,
                            PriceAdjustment = 12m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.L,
                            Color = "Black",
                            SKU = "BASOLES-AIRS-BLACK-L",
                            StockQuantity = 23,
                            PriceAdjustment = 0m
                        }
                    }
                },
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
                    Name = "566 Cloud 9 Hoodie",
                    Description = "80% fleece cotton hoodie, relaxed fit",
                    BasePrice = 79.99m,
                    Category = ClothingCategory.Outerwear,
                    Brand = "YoungLA",
                    ImageUrl = "https://www.youngla.com/cdn/shop/files/YLA_9.246_ff5e92e2-e20f-4caa-ba46-8f34d9aff1e0.jpg?v=1700261990&width=1421",
                    IsActive = true,
                    Variants = new List<ProductVariant>
                    {
                        new ProductVariant
                        {
                            Size = ClothingSize.S,
                            Color = "Light Blue",
                            SKU = "LA-CLOUD-BLUE-S",
                            StockQuantity = 1,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "Light Blue",
                            SKU = "LA-CLOUD-BLUE-M",
                            StockQuantity = 16,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.L,
                            Color = "Light Blue",
                            SKU = "LA-CLOUD-BLUE-L",
                            StockQuantity = 8,
                            PriceAdjustment = 4m
                        }
                    }
                },
                new Product
                {
                    Name = "Dark Olive T",
                    Description = "Minimalist dark green t-shirt, 100% cotton",
                    BasePrice = 12.99m,
                    Category = ClothingCategory.Tops,
                    Brand = "BIG BUD PRESS",
                    ImageUrl = "https://bigbudpress.com/cdn/shop/files/01ECOMMORGANICTEEALEXSWAMPPBYMORGAN2-9-2613766.png?v=1772037103",
                    IsActive = true,
                    Variants = new List<ProductVariant>
                    {
                        new ProductVariant
                        {
                            Size = ClothingSize.S,
                            Color = "Dark Olive",
                            SKU = "BBP-DOT-DO-S",
                            StockQuantity = 5,
                            PriceAdjustment = 0m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.M,
                            Color = "Dark Olive",
                            SKU = "BBP-DOT-DO-M",
                            StockQuantity = 11,
                            PriceAdjustment = 1m
                        },
                        new ProductVariant
                        {
                            Size = ClothingSize.L,
                            Color = "Dark Olive",
                            SKU = "BBP-DOT-DO-L",
                            StockQuantity = 4,
                            PriceAdjustment = 2m
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