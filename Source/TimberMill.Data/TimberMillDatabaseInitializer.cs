using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace TimberMill.Data
{
    public class TimberMillDatabaseInitializer : CreateDatabaseIfNotExists<TimberMillDbContext>
    {
        protected override void Seed(TimberMillDbContext context)
        {
            context.Database.ExecuteSqlCommand(@"
CREATE VIEW LogView
AS
	SELECT	S.Name			AS SourceKey
			,S.Category		AS SourceCategory
			--,B.DateReceived AS BatchReceived
			,L.TimeStamp
			,L.Level
			,L.Message
			,L.Exception
            ,S.Id           AS SourceId
            ,B.Id           AS BatchId
	FROM	Sources		    S
	JOIN	[Batches]		B ON S.Id = B.Source_Id
	JOIN	LogEvents	L ON B.Id = L.Batch_Id
            ");
        }
    }

}
