using System;
using System.Collections.Generic;
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
            return null;
        }

        #endregion
    }
}
