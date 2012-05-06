using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TimberMill.Data;
using TimberMill.Domain.Objects;

namespace TimberMill.Tests.Data
{
    public class SqlBatchRepositoryFixture : Fixture
    {
        [Test]
        public void Create_ReturnsId()
        {
            var sourceRepo = new SqlSourceRepository();
            var source = sourceRepo.GetOrCreate("BatchTest");
            SqlBatchRepository repo = new SqlBatchRepository();
            
            var batch = repo.Create(source);

            // AssertBuilder.Generate(batch, "batch"); // The following assertions were generated on 06-May-2012
            #region CodeGen Assertions
            Assert.That(batch.Id > 0);
            Assert.That(batch.Source.Id > 0);
            Assert.AreEqual(null, batch.Source.Category);
            Assert.AreEqual("BatchTest", batch.Source.Key);
            Assert.That(batch.DateReceived > DateTime.Now.AddMinutes(-1));
            #endregion
        }
    }
}
