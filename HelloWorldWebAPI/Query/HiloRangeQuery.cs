using HelloWorldWebAPI.Model;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldWebAPI.Query
{
    public class HiloRangeQuery:IQueryFor<string,HiloRangeResult>
    {
        public HiloRangeResult ExecuteWith(string input)
        {
            var Db = Database.Open();
            HiloRangeResult Result=Db.HiloGenerator.FindByTableName(input);
            Db.HiloGenerator.UpdateByTableName(TableName: input, High: Result.High + 1);
            return Result;
        }
    }
}