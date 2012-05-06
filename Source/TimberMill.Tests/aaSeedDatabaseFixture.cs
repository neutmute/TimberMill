using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TimberMill.Data;

namespace TimberMill.Tests
{
    public class aaSeedDatabaseFixture : Fixture
    {
        public aaSeedDatabaseFixture()
        {
            EnableTransactionScope = false;
        }
        [Test]
        public void Seed()
        {
            TimberMillDbContext.ReseedDatabase();
        }
    }
}
