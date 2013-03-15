using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Simple.Data.Mocking;
using StructureMap;
using HelloWorldWebAPI.Query;
using System.Web.Http.Dispatcher;
using System.Web.Http.Controllers;
using HelloWorldWebAPI.Controller;


namespace HelloWorldWebAPI
{
    public class TodoBootStrap
    {
        IContainer container = null;
        public TodoBootStrap ConfigureRoute(HttpConfiguration configuration)
        {
            configuration
                .Routes
                .MapHttpRoute("defaultapi"
                , "api/{controller}/{id}"
                , new { controller = "Hello", id = RouteParameter.Optional });
            configuration.Services.Replace(typeof(IHttpControllerActivator), new TodoApiActivator(container));
            return this;
        }


        public TodoBootStrap ConfigureContainer()
        {
            container = new Container();
            container.Configure(configure =>
            {
                configure.Scan(scanner =>
                {
                    scanner.TheCallingAssembly();
                    scanner.ConnectImplementationsToTypesClosing(typeof(IQueryFor<,>));
                    scanner.AddAllTypesOf<IHttpController>();
                });

            });
            return this;
        }

        public TodoBootStrap ConfigureDatabaseForTest()
        {
            var Adapter = new InMemoryAdapter();
            Adapter.SetKeyColumn("Todo", "TableName");
            Database.UseMockAdapter(Adapter);
            return this;
        }

        public TodoBootStrap SeedDatabase()
        {
            var Db = Database.Open();
            Db.HiloGenerator.DeleteAll();
            Db.HiloGenerator.Insert(TableName: "Todo", High: 1, Capacity: 10);
            return this;
        }
    }
}