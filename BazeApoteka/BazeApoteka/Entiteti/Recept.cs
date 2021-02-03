using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BazeApoteka.Entiteti
{
    public class Recept
    {
        public ObjectId Id { get; set; }
        public MongoDBRef Pacijent { get; set; }
        public MongoDBRef Lekar { get; set; }
        public MongoDBRef Faramceut { get; set; }
        public MongoDBRef Lek { get; set; }
    }
}
