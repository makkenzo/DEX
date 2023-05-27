using MongoDB.Driver;
using System;
using System.Configuration;

namespace DEX
{
    public class DBManager
    {
        private static readonly Lazy<IMongoDatabase> lazyDatabase = new Lazy<IMongoDatabase>(() =>
        {
            var settings = MongoClientSettings.FromConnectionString($"mongodb+srv://root:{ConfigurationManager.AppSettings.Get("MyPass")}@dexcluster.mx0indr.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var client = new MongoClient(settings);

            return client.GetDatabase("DEXDB");
        });

        public static IMongoDatabase GetDatabase()
        {
            return lazyDatabase.Value;
        }
    }
}
