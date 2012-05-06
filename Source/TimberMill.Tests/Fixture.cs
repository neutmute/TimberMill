using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kraken.Framework.Testing;

namespace TimberMill.Tests
{
    public abstract class Fixture : KrakenFixture
    {
        public Fixture()
        {
            EnableTransactionScope = true;
        }
        protected override void RegisterAutofacModules()
        {
            //throw new NotImplementedException();
        }
    }
}
