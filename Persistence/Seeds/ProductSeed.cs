using Domain.Entities;
using Domain.Entities.Checkout;
using Domain.Entities.Products;
using Persistence.Contexts;
namespace Persistence.Seeds
{
    public static class ProductSeed
    {
        public static async Task SeedBrandAsync(ApplicationDbContext context)
        {
            if (!context.Brands.Any())
            {
                context.Brands.AddRange(new List<Brand>
                {
                    new Brand
                    {
                        Description = "Brooks Brothers",
                        Created = new DateTime(), CreatedBy = "Append",
                    },
                     new Brand
                    {
                        Description = "Ralph Lauren",
                        Created = new DateTime(), CreatedBy = "Append",
                    },
                    new Brand
                    {
                        Description = "Tom Ford",
                        Created = new DateTime(), CreatedBy = "Append",
                    },
                    new Brand
                    {
                        Description = "Brunello Cucinelli",
                        Created = new DateTime(), CreatedBy = "Append",
                    },
                });

                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedAvailabilityAsync(ApplicationDbContext context)
        {
            if (!context.Availabilities.Any())
            {
                context.Availabilities.AddRange(new List<Availability>
                {
                    new Availability
                    {
                        Description = "Available",
                        Created = new DateTime(), CreatedBy = "Append",
                    },
                     new Availability
                    {
                        Description = "Out of Stock",
                        Created = new DateTime(), CreatedBy = "Append",
                    },
                });

                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedQuantityTypesyAsync(ApplicationDbContext context)
        {
            if (!context.QuantityTypes.Any())
            {
                context.QuantityTypes.AddRange(new List<QuantityType>
                {
                    new QuantityType
                    {
                        Description = "Unidad",
                        Created = new DateTime(), CreatedBy = "Append",
                    },
                     new QuantityType
                    {
                        Description = "Fracción",
                        Created = new DateTime(), CreatedBy = "Append",
                    },
                });

                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedCategoryAsync(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {

                Category trajesCategory = new Category
                {
                    Description = "Trajes",
                    Created = new DateTime(),
                    CreatedBy = "Append",
                };

                context.Categories.Add(trajesCategory);

                context.Categories.AddRange(new List<Category>
                {
                    new Category { Description = "Trajes completos", ParentId = trajesCategory.Id, Created = new DateTime(), CreatedBy = "Append", },
                    new Category { Description = "Chaquetas", ParentId = trajesCategory.Id, Created = new DateTime(), CreatedBy = "Append", },
                    new Category { Description = "Formal", ParentId = trajesCategory.Id, Created = new DateTime(), CreatedBy = "Append", },
                    new Category { Description = "Business", ParentId = trajesCategory.Id, Created = new DateTime(), CreatedBy = "Append", },
                });

                Category camisasCategory = new Category
                {
                    Description = "Camisas",
                    Created = new DateTime(),
                    CreatedBy = "Append",
                };

                context.Categories.Add(camisasCategory);

                context.Categories.AddRange(new List<Category>
                {
                    new Category { Description = "Formales", ParentId = camisasCategory.Id, Created = new DateTime(), CreatedBy = "Append", },
                    new Category { Description = "Casuales", ParentId = camisasCategory.Id, Created = new DateTime(), CreatedBy = "Append", },
                });

                Category pantalonesCategory = new Category
                {
                    Description = "Pantalones",
                    Created = new DateTime(),
                    CreatedBy = "Append",
                };

                context.Categories.Add(pantalonesCategory);

                context.Categories.AddRange(new List<Category>
                {
                    new Category { Description = "Vestir", ParentId = pantalonesCategory.Id, Created = new DateTime(), CreatedBy = "Append", },
                    new Category { Description = "Chinos", ParentId = pantalonesCategory.Id, Created = new DateTime(), CreatedBy = "Append", },
                    new Category { Description = "Jeans", ParentId = pantalonesCategory.Id, Created = new DateTime(), CreatedBy = "Append", }
                });

                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedShippingMethodAsync(ApplicationDbContext context)
        {
            if (!context.ShippingMethods.Any())
            {
                context.ShippingMethods.AddRange(new List<ShippingMethod>
                {
                    new ShippingMethod
                    {
                        Title = "Retiro en el local",
                        Description = "Rivadavia 456, CABA",
                        DeliveryTime = "",
                        Price = 0,
                        Created = new DateTime(), CreatedBy = "Append",
                    },
                    new ShippingMethod
                    {
                        Title = "Envío a domicilio",
                        Description = "",
                        DeliveryTime = "4 a 7 días",
                        Price = 2000,
                        Created = new DateTime(), CreatedBy = "Append",
                    },
                });

                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedSpecsyAsync(ApplicationDbContext context)
        {
            //if (!context.Specs.Any())
            //{
            //    context.Specs.AddRange(new List<Spec>
            //    {
            //        new Spec
            //        {
            //            Name = "Grupo1",
            //            Type = "Object",
            //            CategoryId = 4
            //        },
            //        new Spec
            //        {
            //            Name = "Nombre",
            //            Type = "input",
            //            Format = "text",
            //            CategoryId = 4,
            //            Required = true,
            //            ParentId = 1
            //        },

            //    });

            //    await context.SaveChangesAsync();
            //}
        }
        //public static async Task SeedProductAsync(ApplicationDbContext context)
        //{
        //    if (!context.Products.Any())
        //    {
        //        context.Products.AddRange(new List<Product>
        //        {
        //            new Product
        //            {
        //                ProductName = "Women Colorblock Sneakers",
        //                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit.",
        //                PriceBase = 154,
        //                Price = 154,
        //                UrlImage = "assets/img/shop/catalog/01.jpg",
        //                BrandId = 1,
        //                AvailabilityId = 1,
        //                CategoryId = 11,
        //                Warranty = "Garantia por 3 años",
        //                Review = 75,
        //                Rating = 3.5,
        //                QuantityTypeId=1,
        //                BarCode= "123123123123213123123132",
        //                Stock = 10
        //            },
        //            new Product
        //            {
        //                ProductName = "Cotton Lace Blouse",
        //                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit.",
        //                PriceBase = 38.50,
        //                Price = 28.50,
        //                UrlImage = "assets/img/shop/catalog/02.jpg",
        //                BrandId = 2,
        //                AvailabilityId = 1,
        //                CategoryId = 6,
        //                Warranty = "Garantia por 1 años",
        //                Review = 50,
        //                Rating = 3,
        //                QuantityTypeId=1,
        //                BarCode= "123123123123213123123132",
        //                Stock = 10
        //            },
        //             new Product
        //            {
        //                ProductName = "Mom High Waist Shorts",
        //                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit.",
        //                PriceBase = 39.50,
        //                Price = 28.50,
        //                UrlImage = "assets/img/shop/catalog/03.jpg",
        //                BrandId = 2,
        //                AvailabilityId = 2,
        //                CategoryId = 6,
        //                Warranty = "Garantia por 1 años",
        //                Review = 20,
        //                Rating = 5,
        //                QuantityTypeId=1,
        //                BarCode= "123123123123213123123132",
        //                Stock = 10
        //            },
        //               new Product
        //            {
        //                ProductName = "Women Sports Jacket",
        //                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit.",
        //                PriceBase = 68.40,
        //                Price = 68.40,
        //                UrlImage = "assets/img/shop/catalog/04.jpg",
        //                BrandId = 6,
        //                AvailabilityId = 2,
        //                CategoryId = 3,
        //                Warranty = "Garantia por 1 años",
        //                Review = 70,
        //                Rating = 4,
        //                QuantityTypeId=1,
        //                BarCode= "123123123123213123123132",
        //                Stock = 10
        //            },
        //               new Product
        //            {
        //                ProductName = "Women Colorblock Sneakers",
        //                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit.",
        //                PriceBase = 154,
        //                Price = 154,
        //                UrlImage = "assets/img/shop/catalog/01.jpg",
        //                BrandId = 1,
        //                AvailabilityId = 1,
        //                CategoryId = 11,
        //                Warranty = "Garantia por 3 años",
        //                Review = 75,
        //                Rating = 3.5,
        //                QuantityTypeId=1,
        //                BarCode= "123123123123213123123132",
        //                Stock = 10
        //            },
        //            new Product
        //            {
        //                ProductName = "Cotton Lace Blouse",
        //                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit.",
        //                PriceBase = 38.50,
        //                Price = 28.50,
        //                UrlImage = "assets/img/shop/catalog/02.jpg",
        //                BrandId = 2,
        //                AvailabilityId = 1,
        //                CategoryId = 6,
        //                Warranty = "Garantia por 1 años",
        //                Review = 50,
        //                Rating = 3,
        //                QuantityTypeId=1,
        //                BarCode= "123123123123213123123132",
        //                Stock = 10
        //            },
        //             new Product
        //            {
        //                ProductName = "Mom High Waist Shorts",
        //                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit.",
        //                PriceBase = 39.50,
        //                Price = 28.50,
        //                UrlImage = "assets/img/shop/catalog/03.jpg",
        //                BrandId = 2,
        //                AvailabilityId = 2,
        //                CategoryId = 6,
        //                Warranty = "Garantia por 1 años",
        //                Review = 20,
        //                Rating = 5,
        //                QuantityTypeId=1,
        //                BarCode= "123123123123213123123132",
        //                Stock = 10
        //            },
        //               new Product
        //            {
        //                ProductName = "Women Sports Jacket",
        //                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit.",
        //                PriceBase = 68.40,
        //                Price = 68.40,
        //                UrlImage = "assets/img/shop/catalog/04.jpg",
        //                BrandId = 6,
        //                AvailabilityId = 2,
        //                CategoryId = 3,
        //                Warranty = "Garantia por 1 años",
        //                Review = 70,
        //                Rating = 4,
        //                QuantityTypeId=1,
        //                BarCode= "123123123123213123123132",
        //                Stock = 10
        //            },
        //               new Product
        //            {
        //                ProductName = "Women Colorblock Sneakers",
        //                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit.",
        //                PriceBase = 154,
        //                Price = 154,
        //                UrlImage = "assets/img/shop/catalog/01.jpg",
        //                BrandId = 1,
        //                AvailabilityId = 1,
        //                CategoryId = 11,
        //                Warranty = "Garantia por 3 años",
        //                Review = 75,
        //                Rating = 3.5,
        //                QuantityTypeId=1,
        //                BarCode= "123123123123213123123132",
        //                Stock = 10
        //            },
        //            new Product
        //            {
        //                ProductName = "Cotton Lace Blouse",
        //                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit.",
        //                PriceBase = 38.50,
        //                Price = 28.50,
        //                UrlImage = "assets/img/shop/catalog/02.jpg",
        //                BrandId = 2,
        //                AvailabilityId = 1,
        //                CategoryId = 6,
        //                Warranty = "Garantia por 1 años",
        //                Review = 50,
        //                Rating = 3,
        //                QuantityTypeId=1,
        //                BarCode= "123123123123213123123132",
        //                Stock = 10
        //            },
        //             new Product
        //            {
        //                ProductName = "Mom High Waist Shorts",
        //                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit.",
        //                PriceBase = 39.50,
        //                Price = 28.50,
        //                UrlImage = "assets/img/shop/catalog/03.jpg",
        //                BrandId = 2,
        //                AvailabilityId = 2,
        //                CategoryId = 6,
        //                Warranty = "Garantia por 1 años",
        //                Review = 20,
        //                Rating = 5,
        //                QuantityTypeId=1,
        //                BarCode= "123123123123213123123132",
        //                Stock = 10
        //            },
        //               new Product
        //            {
        //                ProductName = "Women Sports Jacket",
        //                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit.",
        //                PriceBase = 68.40,
        //                Price = 68.40,
        //                UrlImage = "assets/img/shop/catalog/04.jpg",
        //                BrandId = 6,
        //                AvailabilityId = 2,
        //                CategoryId = 3,
        //                Warranty = "Garantia por 1 años",
        //                Review = 70,
        //                Rating = 4,
        //                QuantityTypeId=1,
        //                BarCode= "123123123123213123123132",
        //                Stock = 10
        //            },
        //               new Product
        //            {
        //                ProductName = "Women Colorblock Sneakers",
        //                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit.",
        //                PriceBase = 154,
        //                Price = 154,
        //                UrlImage = "assets/img/shop/catalog/01.jpg",
        //                BrandId = 1,
        //                AvailabilityId = 1,
        //                CategoryId = 11,
        //                Warranty = "Garantia por 3 años",
        //                Review = 75,
        //                Rating = 3.5,
        //                QuantityTypeId=1,
        //                BarCode= "123123123123213123123132",
        //                Stock = 10
        //            },
        //            new Product
        //            {
        //                ProductName = "Cotton Lace Blouse",
        //                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit.",
        //                PriceBase = 38.50,
        //                Price = 28.50,
        //                UrlImage = "assets/img/shop/catalog/02.jpg",
        //                BrandId = 2,
        //                AvailabilityId = 1,
        //                CategoryId = 6,
        //                Warranty = "Garantia por 1 años",
        //                Review = 50,
        //                Rating = 3,
        //                QuantityTypeId=1,
        //                BarCode= "123123123123213123123132",
        //                Stock = 10
        //            },
        //             new Product
        //            {
        //                ProductName = "Mom High Waist Shorts",
        //                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit.",
        //                PriceBase = 39.50,
        //                Price = 28.50,
        //                UrlImage = "assets/img/shop/catalog/03.jpg",
        //                BrandId = 2,
        //                AvailabilityId = 2,
        //                CategoryId = 6,
        //                Warranty = "Garantia por 1 años",
        //                Review = 20,
        //                Rating = 5,
        //                QuantityTypeId=1,
        //                BarCode= "123123123123213123123132",
        //                Stock = 10
        //            },
        //               new Product
        //            {
        //                ProductName = "Women Sports Jacket",
        //                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit.",
        //                PriceBase = 68.40,
        //                Price = 68.40,
        //                UrlImage = "assets/img/shop/catalog/04.jpg",
        //                BrandId = 6,
        //                AvailabilityId = 2,
        //                CategoryId = 3,
        //                Warranty = "Garantia por 1 años",
        //                Review = 70,
        //                Rating = 4,
        //                QuantityTypeId=1,
        //                BarCode= "123123123123213123123132",
        //                Stock = 10
        //            },
        //        });

        //        await context.SaveChangesAsync();
        //    }
        //}

    }
}
