using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop2020.Models;

namespace Webshop2020.Data
{
    public class WebshopDbContext : DbContext
    {
        public WebshopDbContext(DbContextOptions<WebshopDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();
            //if(Categories.Count()<1)
            //{
            //    Seed();
            //}
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CategoryProduct>().HasKey(x => new { x.CategoryID, x.ProductID });
            modelBuilder.Entity<CategoryProduct>().HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryID);
            modelBuilder.Entity<CategoryProduct>().HasOne(x => x.Product).WithMany(x => x.Categories).HasForeignKey(x => x.ProductID);
            //modelBuilder.Entity<Cart>().HasMany(x => x.Items).WithOne(y => y.Cart);
            modelBuilder.Entity<CartItem>().HasOne(x => x.Cart).WithMany(x => x.Items).HasForeignKey(x => x.CartID);
            modelBuilder.Entity<CartItem>().HasOne(x => x.Product).WithMany(x => x.CartItems).HasForeignKey(x => x.ProductID);
        }
        public void Seed()
        {
            Category[] categories = {
                new Category("Élelmiszer", null),
                new Category("Tejtermékek", null),
                new Category("Fűszerek", null),
                new Category("Pékárú", null),
                new Category("Húsok", null),
                new Category("Alkoholmentes italok", null),
                new Category("Alkoholos italok", null),
                new Category("Zöldség", null),
                new Category("Gyümölcs", null),
                new Category("Édesség", null),
                new Category("Rágcsálnivalók", null),
                new Category("Ruházat", null),
                new Category("Elektronika", null),
                new Category("Játékok", null),
                new Category("Kertészet", null)
            };
            categories[1].Parent = categories[0];
            categories[2].Parent = categories[0];
            categories[3].Parent = categories[0];
            categories[4].Parent = categories[0];
            categories[5].Parent = categories[0];
            categories[6].Parent = categories[0];
            categories[7].Parent = categories[0];
            categories[8].Parent = categories[0];
            categories[9].Parent = categories[0];
            categories[10].Parent = categories[0];
            Product[] products =
            {
                new Product("Tejföl",100,100),
                new Product("Joghurt",80,100),
                new Product("Túró",120,100),
                new Product("Kefír",100,100),
                new Product("Tej",100,100),

                new Product("Só",100,100),
                new Product("Cukor",100,100),
                new Product("Bors",100,100),
                new Product("Fahéj",100,100),
                new Product("Bazsalikom",100,100),

                new Product("Kenyér",100,100),
                new Product("Zsemle",100,100),
                new Product("Kifli",100,100),
                new Product("Kalács",100,100),
                new Product("Bagett",100,100),

                new Product("Sonka",100,100),
                new Product("Virsli",100,100),
                new Product("Kolbász",100,100),
                new Product("Szalámi",100,100),
                new Product("Szalonna",100,100),

                new Product("Ásványvíz",100,100),
                new Product("Gyümölcslé",100,100),
                new Product("Icetea",100,100),
                new Product("Üditőital",100,100),
                new Product("Gyógyvíz",100,100),

                new Product("Sör",100,100),
                new Product("Bor",100,100),
                new Product("Pezsgő",100,100),
                new Product("Pálinka",100,100),
                new Product("Likőr",100,100),

                new Product("Répa",100,100),
                new Product("Saláta",100,100),
                new Product("Uborka",100,100),
                new Product("Paradicsom",100,100),
                new Product("Paprika",100,100),

                new Product("Alma",100,100),
                new Product("Körte",100,100),
                new Product("Dinnye",100,100),
                new Product("Cseresznye",100,100),
                new Product("Szilva",100,100),

                new Product("Gumicukor",100,100),
                new Product("Étcsokoládé",100,100),
                new Product("Tejcsokoládé",100,100),
                new Product("Rágó",100,100),
                new Product("Nyalóka",100,100),

                new Product("Keksz",100,100),
                new Product("Pörkölt mogyoró",100,100),
                new Product("Chips",100,100),
                new Product("Ostya",100,100),
                new Product("Pattogatott kukorica",100,100) //{Categories=new List<CategoryProduct>() }
            };

            CategoryProduct[] connections = {
                new CategoryProduct(categories[1], products[0]),
                new CategoryProduct(categories[1], products[1]),
                new CategoryProduct(categories[1], products[2]),
                new CategoryProduct(categories[1], products[3]),
                new CategoryProduct(categories[1], products[4]),
                new CategoryProduct(categories[2], products[5]),
                new CategoryProduct(categories[2], products[6]),
                new CategoryProduct(categories[2], products[7]),
                new CategoryProduct(categories[2], products[8]),
                new CategoryProduct(categories[2], products[9]),
                new CategoryProduct(categories[3], products[10]),
                new CategoryProduct(categories[3], products[11]),
                new CategoryProduct(categories[3], products[12]),
                new CategoryProduct(categories[3], products[13]),
                new CategoryProduct(categories[3], products[14]),
                new CategoryProduct(categories[4], products[15]),
                new CategoryProduct(categories[4], products[16]),
                new CategoryProduct(categories[4], products[17]),
                new CategoryProduct(categories[4], products[18]),
                new CategoryProduct(categories[4], products[19]),
                new CategoryProduct(categories[5], products[20]),
                new CategoryProduct(categories[5], products[21]),
                new CategoryProduct(categories[5], products[22]),
                new CategoryProduct(categories[5], products[23]),
                new CategoryProduct(categories[5], products[24]),
                new CategoryProduct(categories[6], products[25]),
                new CategoryProduct(categories[6], products[26]),
                new CategoryProduct(categories[6], products[27]),
                new CategoryProduct(categories[6], products[28]),
                new CategoryProduct(categories[6], products[29]),
                new CategoryProduct(categories[7], products[30]),
                new CategoryProduct(categories[7], products[31]),
                new CategoryProduct(categories[7], products[32]),
                new CategoryProduct(categories[7], products[33]),
                new CategoryProduct(categories[7], products[34]),
                new CategoryProduct(categories[8], products[35]),
                new CategoryProduct(categories[8], products[36]),
                new CategoryProduct(categories[8], products[37]),
                new CategoryProduct(categories[8], products[38]),
                new CategoryProduct(categories[8], products[39]),
                new CategoryProduct(categories[9], products[40]),
                new CategoryProduct(categories[9], products[41]),
                new CategoryProduct(categories[9], products[42]),
                new CategoryProduct(categories[9], products[43]),
                new CategoryProduct(categories[9], products[44]),
                new CategoryProduct(categories[10], products[45]),
                new CategoryProduct(categories[10], products[46]),
                new CategoryProduct(categories[10], products[47]),
                new CategoryProduct(categories[10], products[48]),
                new CategoryProduct(categories[10], products[49])
            };
            categories[1].Products.Add(connections[0]);
            categories[1].Products.Add(connections[1]);
            categories[1].Products.Add(connections[2]);
            categories[1].Products.Add(connections[3]);
            categories[1].Products.Add(connections[4]);

            categories[2].Products.Add(connections[5]);
            categories[2].Products.Add(connections[6]);
            categories[2].Products.Add(connections[7]);
            categories[2].Products.Add(connections[8]);
            categories[2].Products.Add(connections[9]);

            categories[3].Products.Add(connections[10]);
            categories[3].Products.Add(connections[11]);
            categories[3].Products.Add(connections[12]);
            categories[3].Products.Add(connections[13]);
            categories[3].Products.Add(connections[14]);

            categories[4].Products.Add(connections[15]);
            categories[4].Products.Add(connections[16]);
            categories[4].Products.Add(connections[17]);
            categories[4].Products.Add(connections[18]);
            categories[4].Products.Add(connections[19]);

            categories[5].Products.Add(connections[20]);
            categories[5].Products.Add(connections[21]);
            categories[5].Products.Add(connections[22]);
            categories[5].Products.Add(connections[23]);
            categories[5].Products.Add(connections[24]);

            categories[6].Products.Add(connections[25]);
            categories[6].Products.Add(connections[26]);
            categories[6].Products.Add(connections[27]);
            categories[6].Products.Add(connections[28]);
            categories[6].Products.Add(connections[29]);

            categories[7].Products.Add(connections[30]);
            categories[7].Products.Add(connections[31]);
            categories[7].Products.Add(connections[32]);
            categories[7].Products.Add(connections[33]);
            categories[7].Products.Add(connections[34]);
                       
            categories[8].Products.Add(connections[35]);
            categories[8].Products.Add(connections[36]);
            categories[8].Products.Add(connections[37]);
            categories[8].Products.Add(connections[38]);
            categories[8].Products.Add(connections[39]);

            categories[9].Products.Add(connections[40]);
            categories[9].Products.Add(connections[41]);
            categories[9].Products.Add(connections[42]);
            categories[9].Products.Add(connections[43]);
            categories[9].Products.Add(connections[44]);

            categories[10].Products.Add(connections[45]);
            categories[10].Products.Add(connections[46]);
            categories[10].Products.Add(connections[47]);
            categories[10].Products.Add(connections[48]);
            categories[10].Products.Add(connections[49]);
            /*
            products[0].Categories.Add(connections[0]);
            products[1].Categories.Add(connections[1]);
            products[2].Categories.Add(connections[2]);
            products[3].Categories.Add(connections[3]);
            products[4].Categories.Add(connections[4]);
            products[5].Categories.Add(connections[5]);
            products[6].Categories.Add(connections[6]);
            products[7].Categories.Add(connections[7]);
            products[8].Categories.Add(connections[8]);
            products[9].Categories.Add(connections[9]);

            products[10].Categories.Add(connections[10]);
            products[11].Categories.Add(connections[11]);
            products[12].Categories.Add(connections[12]);
            products[13].Categories.Add(connections[13]);
            products[14].Categories.Add(connections[14]);
            products[15].Categories.Add(connections[15]);
            products[16].Categories.Add(connections[16]);
            products[17].Categories.Add(connections[17]);
            products[18].Categories.Add(connections[18]);
            products[19].Categories.Add(connections[19]);

            products[20].Categories.Add(connections[20]);
            products[21].Categories.Add(connections[21]);
            products[22].Categories.Add(connections[22]);
            products[23].Categories.Add(connections[23]);
            products[24].Categories.Add(connections[24]);
            products[25].Categories.Add(connections[25]);
            products[26].Categories.Add(connections[26]);
            products[27].Categories.Add(connections[27]);
            products[28].Categories.Add(connections[28]);
            products[29].Categories.Add(connections[29]);

            products[30].Categories.Add(connections[30]);
            products[31].Categories.Add(connections[31]);
            products[32].Categories.Add(connections[32]);
            products[33].Categories.Add(connections[33]);
            products[34].Categories.Add(connections[34]);
            products[35].Categories.Add(connections[35]);
            products[36].Categories.Add(connections[36]);
            products[37].Categories.Add(connections[37]);
            products[38].Categories.Add(connections[38]);
            products[39].Categories.Add(connections[39]);

            products[40].Categories.Add(connections[40]);
            products[41].Categories.Add(connections[41]);
            products[42].Categories.Add(connections[42]);
            products[43].Categories.Add(connections[43]);
            products[44].Categories.Add(connections[44]);
            products[45].Categories.Add(connections[45]);
            products[46].Categories.Add(connections[46]);
            products[47].Categories.Add(connections[47]);
            products[48].Categories.Add(connections[48]);
            products[49].Categories.Add(connections[49]);
            */

            Categories.AddRange(categories);
            //Products.AddRange(products);

            int result = SaveChanges();
        }
    }
}
