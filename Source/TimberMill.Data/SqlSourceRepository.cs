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

        public Source GetOrCreate(string name, string category)
        {
            using (var dbContext = new TimberMillDbContext())
            {
                var source = Get(dbContext, name, category);

                if (source == null)
                {
                    source = new Source {Name = name, Category = category};
                    dbContext.Sources.Add(source);
                    dbContext.SaveChanges();
                }
                return source;
            }
        }

        private Source Get(TimberMillDbContext dbContext, string name, string category)
        {
            return dbContext.Sources.Where(s => s.Name == name && s.Category == category).FirstOrDefault();
        }
        #endregion

    }
}
