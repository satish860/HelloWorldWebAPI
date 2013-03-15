using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace HelloWorldWebAPI
{
    public class TodoApiActivator:IHttpControllerActivator
    {
        private readonly IContainer container;
        public TodoApiActivator(IContainer structureMapContainer)
        {
            this.container = structureMapContainer;
        }
 

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var NestedContainer = container.GetNestedContainer();
            request.RegisterForDispose(NestedContainer);
            // Not used as Operator because it may return Null , Well You cant return a Null Controller
            // That will be a disaster
            return (IHttpController)container.GetInstance(controllerType);
        }
    }
}