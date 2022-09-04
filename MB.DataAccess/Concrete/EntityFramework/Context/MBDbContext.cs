using MB.Entity.Entities;
using MB.Entity.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.DataAccess.Concrete.EntityFramework.Context
{
    public class MBDbContext:DbContext
    {
        public MBDbContext()
        {

        }
        public MBDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                connectionString: @"Server=DESKTOP-2A4NBF1;Database=MBDb;Trusted_Connection=True;Connect Timeout=40;MultipleActiveResultSets=True;"
                );

            //optionsBuilder.UseNpgsql(
            //  connectionString: @"Server=localhost;Database=MBDb;Port=5432;User Id=postgres;Password=1234"
            //  );
            //optionsBuilder.UseMySQL(
            // connectionString: @"server=localhost;Database=MBDb;user=root;password=balbal0101+!;port=3306"
            // );

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseSerialColumns();

            modelBuilder.Entity<Product>()
                .HasOne(q => q.AppUser);
            modelBuilder.Entity<Product>()
                .HasOne(q => q.Category);

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = new Guid("eaac6de8-dfbb-485e-a94f-c126a38e0c0d"), Name = "TV", Status = true, CreateDate = DateTime.Now },
                new Category() { Id = new Guid("febe926b-36cd-4c3c-8e96-046d0b6da71d"), Name = "Phone", Status = true, CreateDate = DateTime.Now }
                );
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole() { Id = new Guid("e8f0130a-b4ac-46af-8ab8-825082ead915"), Name = "User",Description="User", Status = true, CreateDate = DateTime.Now },
                new AppRole() { Id = new Guid("f06310dd-0a27-4897-832d-2ebc7feb606e"), Name = "Admin",Description="Admin", Status = true, CreateDate = DateTime.Now }
                );
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser() { Id = new Guid("87cb48f4-4089-4ca8-817a-024dd432c319"), Name = "Ruslan", Surname = "Galandarli", Email = "ruslan.galandarli@gmail.com", PasswordHash= "+vm1hl0OyKZBtorJGZVZVc1awVcXBCFd+yJPRXwkYjQ=",AppRoleId= new Guid("e8f0130a-b4ac-46af-8ab8-825082ead915"), Status = true, CreateDate = DateTime.Now }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = new Guid("eba2135b-202b-4eeb-9af1-3364d55c5949"), Name = "Iphone",CategoryId=new Guid("febe926b-36cd-4c3c-8e96-046d0b6da71d"),Count=23,AppUserId=new Guid("87cb48f4-4089-4ca8-817a-024dd432c319"), Status = true, CreateDate = DateTime.Now },
                new Product() { Id = new Guid("a13a1fda-419f-4ece-a25c-0e084a52d080"), Name = "Sm222",CategoryId=new Guid("eaac6de8-dfbb-485e-a94f-c126a38e0c0d"),Count=23,AppUserId=new Guid("87cb48f4-4089-4ca8-817a-024dd432c319"), Status = true, CreateDate = DateTime.Now }
                );


        }
    }
}
