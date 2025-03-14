﻿using Dachy.DataAccess.Data;
using Dachy.DataAccess.Repository.IRepository;

namespace Dachy.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get; private set; }

        public ICompanyRepository Company { get; private set; }

        public IShoppingCartRepository ShoppingCart {get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailsRepository OrderDetails { get; private set; }

        public IProductImageRepository ProductImage { get; private set; }

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            ProductImage = new ProductImageRepository(_db);
            Category = new CategoryRepository (_db);
            Product = new ProductRepository (_db);
            Company = new CompanyRepository (_db);
            ShoppingCart = new ShoppingCartRepository (_db);
            ApplicationUser = new ApplicationUserRepository (_db);
            OrderHeader = new OrderHeaderRepository (_db);
            OrderDetails = new OrderDetailsRepository (_db);    
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
