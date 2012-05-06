using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TimberMill.Domain.Objects;
using TimberMill.Domain.Repositories;

namespace TimberMill.Data
{
    public class SqlBatchRepository : IBatchRepository
    {
        #region IBatchRepository Members

        public Batch Create(Source source)
        {
            Batch batch;
            using (var dbContext = new TimberMillDbContext())
            {
                batch = new Batch {Source = source};
                dbContext.Batchs.Add(batch);
                dbContext.Entry(batch.Source).State = EntityState.Unchanged;
                dbContext.SaveChanges();
            }
            return batch;
        }

        #endregion
    }
}
