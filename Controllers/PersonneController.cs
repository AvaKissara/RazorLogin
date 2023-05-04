using Microsoft.AspNetCore.Mvc;
using RazorLogin.Models;
using RazorLogin.Repository;

namespace RazorLogin.Controllers
{
    public class PersonneController : Controller
    {
        private readonly ILogger<PersonneController> _logger;

        public PersonneController(ILogger<PersonneController> logger)
        {
            _logger = logger;
        }

        public IActionResult Personne()
        {
            IEnumerable<MPersonne> personnes = this.GetPersonnes();
            return View(personnes);
        }


        RepMPersonne dataPersonnes = new RepMPersonne();
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


    }
}
