﻿using Application.Common.Interfaces;
using Domain.Common;
using Domain.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Checkout;
using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _datetime;
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        private readonly CurrentUser _user;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, 
            IDateTimeService datetime, 
            IDomainEventDispatcher domainEventDispatcher,
            ICurrentUserService currentUserService) : base(options)
        {
            //agregamos para poder seguir los cambios y que Entity se de cuenta cuando hace un SaveAsync
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this._datetime = datetime;
            _domainEventDispatcher = domainEventDispatcher;
            _user = currentUserService.User;
        }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<QuantityType> QuantityTypes { get; set; }
        public DbSet<ProductFile> ProductFiles { get; set; }
        public DbSet<Spec> Specs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Payment> PaymentMethods { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }


        //Sobrescribimos SaveAsync
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //Cada vez que guardamos o modificamos le decimos que guarde la fecha
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _user.Id;
                        entry.Entity.Created = _datetime.NowUtc; 
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = _user.Id;
                        entry.Entity.Modified = _datetime.NowUtc; 
                        break;
                }
            }
            //return base.SaveChangesAsync();

            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // Ignora lo eventos si el dispatcher no tiene nada.
            if (_domainEventDispatcher == null) return result;

            // Ejecuta los eventos solo si el Save fue exitoso.
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _domainEventDispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Aca le decimos que se ejecute la configuracion de cada entidad para la migracion
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
