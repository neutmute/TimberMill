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
            return null;
        }

        #endregion
    }
}
