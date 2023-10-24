using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RepoPattrenWithUnitOfWork.Core.Models;
using RepoPattrenWithUnitOfWork.EF.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.EF
{
    public static class DbContextExtensions
    {
        public static void ApplyGlobalFilters<TInterface>(this ModelBuilder modelBuilder,
            Expression<Func<TInterface, bool>> expression)
        {
            var entities = modelBuilder.Model
                .GetEntityTypes()
                .Where(e => e.ClrType.GetInterface(typeof(TInterface).Name) != null)
                .Select(e => e.ClrType);

            foreach (var entity in entities)
            {
                var newParam = Expression.Parameter(entity);
                var newbody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);
                modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newbody, newParam));
            }
        }
        }

        public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyGlobalFilters<ISoftDeletable>(e => !e.IsDeleted);


        }
    }
    public static class DbModelsExtensions
    {

        public static IQueryable<T> FilterSoftDeletedModels<T>(this IQueryable<T> set)
        {
            if (typeof(T).GetInterface(nameof(ISoftDeletable)) == null)
                return set;

            return set.Where(model => !((ISoftDeletable)model).IsDeleted);
        }
    }
}
