using Microsoft.AspNetCore.Mvc;
using RazorLogin.Models;
using RazorLogin.Repository;

namespace RazorLogin.Controllers
{
    public class PersonneController : Controller
    {
        private readonly ILogger<PersonneController> _logger;
        RepMPersonne dataPersonnes = new RepMPersonne();

        public PersonneController(ILogger<PersonneController> logger)
        {
            _logger = logger;
        }

        public IActionResult Personne()
        {
            IEnumerable<MPersonne> personnes = this.GetPersonnes();
            return View(personnes);
        }

        public List<MPersonne> GetPersonnes()
        {
            List<MPersonne> personnes = new List<MPersonne>();
            personnes = dataPersonnes.GetPersonnes();

            return personnes;
        }  

        public IActionResult Creer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ajouter([Bind("nomPersonne,prenomPersonne,mdp")] MPersonne nouvellePersonne)
        {
            this.addPersonne(nouvellePersonne);
            return View();
        }

        public void addPersonne(MPersonne nouvellePersonne)
        {
            dataPersonnes.addPersonne(nouvellePersonne);
        }


        [HttpGet]
        public IActionResult Effacer(int id)
        {
            MPersonne personneEffacee = new MPersonne();
            dataPersonnes.deletePersonne(id);
            return RedirectToAction("Personne");
        }

        public IActionResult Modifier() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult Enregistrer(int id) 
        {
            return RedirectToAction("Personne");
        }
    }
}
