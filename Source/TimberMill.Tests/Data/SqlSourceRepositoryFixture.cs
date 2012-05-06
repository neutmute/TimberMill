using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TimberMill.Data;

namespace TimberMill.Tests.Data
{
    public class SqlSourceRepositoryFixture : Fixture
    {
        [Test]
        public void GetOrCreate()
        {
            SqlSourceRepository repo = new SqlSourceRepository();
            var source = repo.GetOrCreate("test1");

            // AssertBuilder.Generate(source, "source"); // The following assertions were generated on 06-May-2012
            #region CodeGen Assertions
           // Assert.AreEqual(1, source.Id);
            Assert.AreEqual(null, source.Category);
            Assert.AreEqual("test1", source.Key);
            #endregion
        }
    }
}
