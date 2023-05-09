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

        public RepMPersonne GetDataPersonnes()
        {
            return dataPersonnes;
        }

        [HttpGet]
        public IActionResult Effacer(int id)
        {
            dataPersonnes.deletePersonne(id);
            return RedirectToAction("Personne");
        }

        public IActionResult Modifier(int id) 
        {
           
          return View();
        }

        [HttpPost]
        public IActionResult Enregistrer([Bind("nomPersonne,prenomPersonne,mdp")] MPersonne modifPersonne)
        {
            //MPersonne modifPersonne = new MPersonne();
            //modifPersonne.idPersonne = id;
            this.updatePersonne(modifPersonne);
            return View();
        }

        public void updatePersonne(MPersonne modifPersonne)
        {
            dataPersonnes.addPersonne(modifPersonne);
        }
    }
}
