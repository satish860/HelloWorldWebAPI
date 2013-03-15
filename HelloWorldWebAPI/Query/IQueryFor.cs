using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldWebAPI.Query
{
    public interface IQueryFor<TInput,TOutput>
    {
        TOutput ExecuteWith(TInput input);
    }
}