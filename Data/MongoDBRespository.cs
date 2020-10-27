using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Commander.Data
{
    public class MongoDBRespository
    {
        public MongoClient client;

        public IMongoDatabase db;

        public MongoDBRespository()
        {
            //
            client = new MongoClient("mongodb+srv://<user>:<password>@<cluster>/<dbname>?retryWrites=true&w=majority");
            db = client.GetDatabase("dbname");
        }
    }
}
