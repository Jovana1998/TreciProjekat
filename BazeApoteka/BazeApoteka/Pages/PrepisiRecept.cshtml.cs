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
using Microsoft.AspNetCore.Components.Server;

namespace BazeApoteka.Pages
{
    public class PrepisiReceptModel : PageModel
    {
        [BindProperty]
        public String Prosledjeno { get; set; }
        public IMongoCollection<Recept> collection { get; set; }
        public IMongoCollection<Korisnik> Korisnici { get; set; }
        [BindProperty]
        public Recept recept { get; set; }
        [BindProperty]
        public Korisnik pacijent { get; set; }
        [BindProperty]
        public Lek lek { get; set; }
       
        public IActionResult OnGet([FromRoute] String id)
        {
            Prosledjeno = id; //id recepta
            var connectionString = "mongodb://localhost/?safe=true";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Apoteka3");

            //ucitamo recepte i nadjemo prosledjen 
            collection = database.GetCollection<Recept>("recepti");
            ObjectId iid = ObjectId.Parse(Prosledjeno);
            recept = collection.Find(x => x.Id == iid).FirstOrDefault();

            Korisnici = database.GetCollection<Korisnik>("korisnici");
            pacijent = Korisnici.Find(x => x.Id == recept.Pacijent.Id).FirstOrDefault();

            return Page();
        }
        public IActionResult OnPost([FromRoute] String id)
        {
            Prosledjeno = id; //id recepta
            var connectionString = "mongodb://localhost/?safe=true";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Apoteka3");

            //ucitamo recepte i nadjemo prosledjen 
            collection = database.GetCollection<Recept>("recepti");
            ObjectId iid = ObjectId.Parse(Prosledjeno);
            recept = collection.Find(x => x.Id == iid).FirstOrDefault();

            Korisnici = database.GetCollection<Korisnik>("korisnici");
            pacijent = Korisnici.Find(x => x.Id == recept.Pacijent.Id).FirstOrDefault();

            return Page();
        }
    }
}