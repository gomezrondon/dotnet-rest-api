using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Commander.Data
{
    public class CommanderRepository : ICommanderRepo
    {

        internal MongoDBRespository _repository = new MongoDBRespository();
        private IMongoCollection<Command> Collection; // es la tabla

        public CommanderRepository()
        {
            Collection = _repository.db.GetCollection<Command>("Command");
        }

        public async Task<List<Command>> GetAppCommands()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public Command GetCommandById(String id)
        {
            return Collection.FindSync(new BsonDocument { { "_id", new ObjectId(id) } }).First();

        }

        public void InsertCommand(Command command)
        {
             Collection.InsertOne(command);
        }

 
    }
}
