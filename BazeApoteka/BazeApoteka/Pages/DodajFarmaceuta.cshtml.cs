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
using System.Security.Policy;
using MongoDB.Thin;



namespace BazeApoteka.Pages
{
    public class DodajFarmaceutaModel : PageModel
    {
        //[BindProperty]
        //public ObjectId IdApoteke { get; set; }
        [BindProperty]
        public Farmaceut Farmaceut { get; set; }
        [BindProperty]
        public String Prosledjeno { get; set; }
        public IMongoCollection<Farmaceut> collection { get; set; }
        
        public IActionResult OnGet([FromRoute]String id)
        {
            string pom = id;
            //IdApoteke = ObjectId.Parse(id);
            return Page();
        }
        public IActionResult OnPost([FromRoute]String id)
        {
            string pom = id;
            //IdApoteke = ObjectId.Parse(id);
            return Page();
        }

        //public IActionResult OnPostDodaj()
        //{
        //    var connectionString = "mongodb://localhost/?safe=true";
        //    var client = new MongoClient(connectionString);
        //    var database = client.GetDatabase("Apoteka");


        //    collection = database.GetCollection<Farmaceut>("farmaceuti");

        //    collection.InsertOne(Farmaceut);
        //    var apoteke = database.GetCollection<Apoteka>("apoteke");
        //    var query1 = from apoteka in apoteke.AsQueryable<Apoteka>()
        //                 where apoteka.Id == IdApoteke
        //                 select apoteka;
        //    foreach(Apoteka a in query1)
        //    {
        //        a.Farmaceuti.Add(new MongoDBRef("farmaceuti", Farmaceut.Id));
        //        Farmaceut.MojaApoteka = new MongoDBRef("apoteke", IdApoteke);
        //        collection.ReplaceOne("farmaceuti", Farmaceut);
        //    }
           

           

           
        //    return Page();
        //}
    }
}