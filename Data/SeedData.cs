using Microsoft.EntityFrameworkCore;
using MiniKFCStore.Models;
using MiniKFCStore.Repositories;

namespace MiniKFCStore.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                var admin = new User { Username = "admin", Password = "admin", Role = "Admin" };
                var user = new User { Username = "string", Password = "string", Role = "User" };
                await context.Users.AddAsync(admin);
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }

            if (!context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role { RoleName = "Admin" },
                    new Role { RoleName = "User" }
                };
                await context.Roles.AddRangeAsync(roles);
                await context.SaveChangesAsync();
            }

            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Mì" },
                    new Category { Name = "Cơm" },
                    new Category { Name = "Gà" },
                    new Category { Name = "Khoai tây chiên" },
                    new Category { Name = "Đồ uống" }
                };
                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }

            // Lấy danh sách category để sử dụng cho việc tạo sản phẩm
            var categoryIds = await context.Categories.Select(c => c.Id).ToListAsync();

            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product { Name = "Mì xào", Price = 20000, Img = "https://static.kfcvietnam.com.vn/images/items/lg/MI-Y-GA-VIEN.jpg?v=0.1", CategoryId = categoryIds[0] },
                    new Product { Name = "Cơm gà", Price = 30000, Img = "https://static.kfcvietnam.com.vn/images/items/lg/Rice-Teriyaki.jpg?v=4BB1K4", CategoryId = categoryIds[1] },
                    new Product { Name = "Gà rán", Price = 50000, Img = "https://static.kfcvietnam.com.vn/images/items/lg/6-Fried-Chicken-new.jpg?v=0.1", CategoryId = categoryIds[2] },
                    new Product { Name = "Khoai tây chiên lớn", Price = 15000, Img = "https://static.kfcvietnam.com.vn/images/items/lg/FF-L.jpg?v=0.1", CategoryId = categoryIds[3] },
                    new Product { Name = "Nước ngọt", Price = 10000, Img = "https://product.hstatic.net/1000166699/product/16568750047262_1__a06cae5281e14da68881f7c87b67116e_master.jpg", CategoryId = categoryIds[4] },
                    new Product { Name = "Mì tôm", Price = 12000, Img = "https://www.vinmec.com/static/uploads/small_20201228_032224_820684_mitoms_max_1800x1800_jpg_ca8c753cee.jpg", CategoryId = categoryIds[0] },
                    new Product { Name = "Cơm chiên", Price = 25000, Img = "https://i.ytimg.com/vi/FR4DH5sSysI/maxresdefault.jpg", CategoryId = categoryIds[1] },
                    new Product { Name = "Gà sốt tiêu", Price = 55000, Img = "https://media.loveitopcdn.com/30784/cach-lam-ga-quay-tieu-kfc-com-hop-thai-binh.jpg", CategoryId = categoryIds[2] },
                    new Product { Name = "Khoai tây chiên nhỏ", Price = 10000, Img = "https://png.pngtree.com/png-vector/20231115/ourlarge/pngtree-mcdonalds-french-fries-fast-food-studio-png-image_10465019.png", CategoryId = categoryIds[3] },
                    new Product { Name = "Trà sữa", Price = 20000, Img = "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjWSVRFx9gN492PTDR-GSUJJy4G6rIqtZJmBdqnWggJEJ0YfVLGODSgXEhL-XrKW6O87gNHe7DSF6KRPNyOVVEjw_P2PzsVSNXX8mwvcUT-2Yj404xWzwf9yvaOjdp2q3Idtsmh7RbAOuI/s16000-rw/Tra-sua-tran-chau-1.png", CategoryId = categoryIds[4] }
                };

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
