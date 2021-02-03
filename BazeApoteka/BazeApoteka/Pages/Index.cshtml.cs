using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Bson;
using BazeApoteka.Entiteti;
using MongoDB.Driver.Linq;

namespace BazeApoteka.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IMongoCollection<Lek> collection { get; set; }
        public List<Lek> model { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Apoteka");

             collection = database.GetCollection<Lek>("lekovi");
            Lek lekic = new Lek { GenerickiNaziv = "Petar", KomercijaniNaziv = "Petrović", DaLiJeNaRecept = "Oblačića Rada 12", Dejstvo = "25000" };
            collection.InsertOne(lekic);

            model = collection.Find(FilterDefinition<Lek>.Empty).ToList();

            
        }
    }
}
