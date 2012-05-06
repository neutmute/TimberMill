using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TimberMill.Domain.Objects;
using TimberMill.Domain.Repositories;

namespace TimberMill.Data
{
    public class SqlLogEventRepository : ILogEventRepository
    {
        #region ILogEventRepository Members

        public void Save(LogEvent logEvent)
        {
            using (var dbContext = new TimberMillDbContext())
            {
                dbContext.Batchs.Attach(logEvent.Batch);
                dbContext.Sources.Attach(logEvent.Batch.Source);

                dbContext.LogEvents.Add(logEvent);
                //dbContext.Entry(logEvent.Batch).State = EntityState.Unchanged;
                //dbContext.Entry(logEvent.Batch.Source).State = EntityState.Unchanged;   
                dbContext.SaveChanges();
            }
        }

        public List<LogEvent> GetAll(Source source)
        {
            var events = new List<LogEvent>();
            using (var dbContext = new TimberMillDbContext())
            {
                events = dbContext
                            .LogEvents
                            .Include("Batch")
                            .Include("Batch.Source")
                            .Where(e => e.Batch.Source.Id == source.Id).ToList();
            }
            return events;
        }
        #endregion
    }
}
