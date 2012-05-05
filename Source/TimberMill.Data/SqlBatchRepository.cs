using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimberMill.Domain.Repositories;

namespace TimberMill.Data
{
    public class SqlBatchRepository : IBatchRepository
    {
        #region IBatchRepository Members

        public Domain.Objects.Batch Create(Domain.Objects.Source source)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
