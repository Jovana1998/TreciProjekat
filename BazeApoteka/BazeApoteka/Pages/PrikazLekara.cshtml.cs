using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using MongoDB.Bson;
using BazeApoteka.Entiteti;
using MongoDB.Driver.Linq;

namespace BazeApoteka.Pages
{
    public class PrikazLekaraModel : PageModel
    {
        [BindProperty]
        public String Prosledjeno { get; set; }
        public IMongoCollection<Lekar> collection { get; set; }
        [BindProperty]
        public List<Lekar> lekari { get; set; }
        public void OnGet([FromRoute] String id)
        {
            Prosledjeno = id;
            var connectionString = "mongodb://localhost/?safe=true";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Apoteka2");


            collection = database.GetCollection<Lekar>("lekari");

            ObjectId iid = ObjectId.Parse(Prosledjeno);
            lekari = collection.Find(x => x.Id == iid).ToList();
        }
        public IActionResult OnPost([FromRoute] String id)
        {
            Prosledjeno = id;
            var connectionString = "mongodb://localhost/?safe=true";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Apoteka2");


            collection = database.GetCollection<Lekar>("lekari");

            ObjectId iid = ObjectId.Parse(Prosledjeno);
            lekari = collection.Find(x => x.Id == iid).ToList();

            return Page();
        }
    }
}
