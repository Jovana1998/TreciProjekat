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
    public class KupiLekModel : PageModel
    {
        [BindProperty]
        public Korisnik Korisnik { get; set; }
        [BindProperty]
        public Lek Lek { get; set; }
        public IMongoCollection<Korisnik> collectionK { get; set; }
        [BindProperty]
        public List<Korisnik> korisnici { get; set; }
        public IMongoCollection<Lek> collectionL { get; set; }
        [BindProperty]
        public List<Lek> lekovi { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(String idL, String idK)
        {

            return Page();
        }
    }
}
