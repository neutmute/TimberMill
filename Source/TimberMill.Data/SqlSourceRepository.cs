using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimberMill.Domain.Objects;
using TimberMill.Domain.Repositories;

namespace TimberMill.Data
{
    public class SqlSourceRepository : ISourceRepository
    {
        #region ISourceRepository Members

        public Source GetOrCreate(string name)
        {
            using (var dbContext = new TimberMillDbContext())
            {
                var source = Get(dbContext, name);

                if (source == null)
                {
                    source = new Source {Key = name};
                    dbContext.Sources.Add(source);
                    dbContext.SaveChanges();
                }
                return source;
            }
        }

        private Source Get(TimberMillDbContext dbContext, string name)
        {
            return dbContext.Sources.Where(s => s.Key == name).FirstOrDefault();
        }
        #endregion
    }
}
