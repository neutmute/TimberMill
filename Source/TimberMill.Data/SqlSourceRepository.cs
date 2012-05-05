using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimberMill.Domain.Repositories;

namespace TimberMill.Data
{
    public class SqlSourceRepository : ISourceRepository
    {
        #region ISourceRepository Members

        public Domain.Objects.Source GetOrCreate(string name)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
