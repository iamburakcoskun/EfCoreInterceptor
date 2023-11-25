using EfCoreInterceptor.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorDemo.Interceptors
{
    public class AddAuditDataInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var changeTracker = eventData.Context.ChangeTracker;

            var addedList = changeTracker.Entries<IAuditable>().Where(x => x.State == EntityState.Added).ToList();

            foreach (var entityEntry in addedList)
            {
                entityEntry.Property(x => x.CreateDate).CurrentValue = DateTime.Now;
            }

            var modifiedList = changeTracker.Entries<IAuditable>().Where(x => x.State == EntityState.Modified).ToList();

            foreach (var entityEntry in modifiedList)
            {
                entityEntry.Property(x => x.UpdateDate).CurrentValue = DateTime.Now;
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
