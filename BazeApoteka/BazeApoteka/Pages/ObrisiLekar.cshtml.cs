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
using MongoDB.Driver.Builders;

namespace BazeApoteka.Pages
{
    public class ObrisiLekarModel : PageModel
    {

        [BindProperty]
        public String ProsledjenoIme { get; set; }
        [BindProperty]
        public String ProsledjenoPrezime { get; set; }
        public IMongoCollection<Lekar> collection { get; set; }
        [BindProperty]
        public List<Lekar> lekari { get; set; }
        [BindProperty]
        public Lekar Lekar { get; set; }
        public void OnGet()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Apoteka2");


            collection = database.GetCollection<Lekar>("lekari");

            lekari = collection.Find(FilterDefinition<Lekar>.Empty).ToList();
        }
        public IActionResult OnPost()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Apoteka2");


            collection = database.GetCollection<Lekar>("lekari");
            lekari = collection.Find(FilterDefinition<Lekar>.Empty).ToList();
            return Page();
        }
        public IActionResult OnPostObrisi()
        {
            if (ProsledjenoIme == null || ProsledjenoPrezime == null)
            {
                return RedirectToPage("./ObrisiLekar");
            }
            var connectionString = "mongodb://localhost/?safe=true";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Apoteka2");
            collection = database.GetCollection<Lekar>("lekari");
            lekari = collection.Find(x => x.Ime == ProsledjenoIme && x.Prezime == ProsledjenoPrezime).ToList();
            foreach (Lekar lekar in lekari)
            {
                String idobrisi = lekar.Id.ToString();
                ObjectId objectId = ObjectId.Parse(idobrisi);
                collection.DeleteOne(x => x.Id == objectId);
            }

            return RedirectToPage("./ObrisiLekar");
        }
    }
}
