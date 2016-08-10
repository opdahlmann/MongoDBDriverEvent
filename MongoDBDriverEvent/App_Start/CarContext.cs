using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using MongoDBDriverEvent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDBDriverEvent.App_Start
{
    public class CarContext
    {
        public IMongoDatabase Database;

        public CarContext()
        {
            var mongoSettings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://user:password@localhost:27017/DemoEvents"));
            mongoSettings.ClusterConfigurator = builder => builder.Subscribe(new LogMongeEvents());
            var client = new MongoClient(mongoSettings);
            Database = client.GetDatabase("DemoEvents");
        }

        public IMongoCollection<Car> Cars => Database.GetCollection<Car>("Cars");
    }

    //public class LogMongeEvents : IEventSubscriber
    //{
    //    public bool TryGetEventHandler<TEvent>(out Action<TEvent> handler)
    //    {
    //        handler = e =>
    //        {
    //            // log any event
    //        };
    //        return true;
    //    }
    //}

    public class LogMongeEvents : IEventSubscriber
    {
        private ReflectionEventSubscriber eventSubscriber;

        public LogMongeEvents()
        {
            eventSubscriber = new ReflectionEventSubscriber(this);
        }

        public bool TryGetEventHandler<TEvent>(out Action<TEvent> handler)
        {
            return eventSubscriber.TryGetEventHandler(out handler);
        }

        public void Handle(CommandStartedEvent startedEvent)
        {
            // log for started Event
        }
    }
}