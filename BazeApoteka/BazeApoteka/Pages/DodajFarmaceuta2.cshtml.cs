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
using MongoDB.Driver.Builders;

namespace BazeApoteka.Pages
{
    public class DodajFarmaceuta2Model : PageModel
    {
        [BindProperty]
        public Farmaceut Farmaceut { get; set; }

        public IMongoCollection<Farmaceut> collection { get; set; }

        public IActionResult OnGet([FromRoute] String id)
        {
            
            return Page();
        }
        public IActionResult OnPost([FromRoute] String id)
        {
            
            return Page();
        }

        public IActionResult OnPostDodaj([FromRoute] String pom)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Apoteka2");


            collection = database.GetCollection<Farmaceut>("farmaceuti");

            collection.InsertOne(Farmaceut);
            return RedirectToPage();
        }
    }
}
