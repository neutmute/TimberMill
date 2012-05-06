using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TimberMill.Data;
using TimberMill.Domain.Objects;

namespace TimberMill.Tests.Data
{
    public class SqlLogEventRepositoryFixture : Fixture
    {
        [Test]
        public void Save_Persists()
        {
            var sourceRepo = new SqlSourceRepository();
            var batchRepository = new SqlBatchRepository();
            var logEventRepo = new SqlLogEventRepository();

            var source = sourceRepo.GetOrCreate("BatchTest", null);
            var batch = batchRepository.Create(source);
            var logEvent = new LogEvent();

            logEvent.Batch = batch;
            logEvent.ExceptionMessage = "woooah";
            logEvent.Message = "unit test";
            logEvent.TimeStamp = DateTime.Parse("2012-05-06 13:40");

            logEventRepo.Save(logEvent);

            var events = logEventRepo.GetAll(source);

            // AssertBuilder.Generate(events, "events"); // The following assertions were generated on 06-May-2012
            #region CodeGen Assertions
            Assert.AreEqual(1, events.Count);
            Assert.That(events[0].Id > 0);
            Assert.IsNotNull(events[0].Batch);
            Assert.AreEqual(Convert.ToDateTime("06-May-2012 13:40:00.000"), events[0].TimeStamp);
            Assert.AreEqual(null, events[0].Level);
            Assert.AreEqual("unit test", events[0].Message);
            Assert.AreEqual("woooah", events[0].ExceptionMessage);
            Assert.AreEqual(null, events[0].ExceptionStackTrace);
            #endregion
        }
    }
}
