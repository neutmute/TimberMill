using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimberMill.Domain.Objects;

namespace TimberMill.Domain.Repositories
{
    public interface IBatchRepository
    {
        Batch Create(Source source);
    }
}
