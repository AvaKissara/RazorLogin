using Microsoft.AspNetCore.Mvc;
using RazorLogin.Metier;
using RazorLogin.Models;
using RazorLogin.Repository;

namespace RazorLogin.Controllers
{
    public class PersonneController : Controller
    {
        private readonly ILogger<PersonneController> _logger;
        RepMPersonne dataPersonnes = new RepMPersonne();
        MtPersonne progPersonne= new MtPersonne();

        public PersonneController(ILogger<PersonneController> logger)
        {
            _logger = logger;
        }


        public List<MPersonne> GetPersonnes()
        {
            List<MPersonne> personnes = new List<MPersonne>();
            personnes = dataPersonnes.GetPersonnes();

            return personnes;
        }

        public IActionResult Personne()
        {
            IEnumerable<MPersonne> personnes = this.GetPersonnes();
            return View("Personne", personnes);
        }

        public IActionResult Creer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ajouter([Bind("nomPersonne,prenomPersonne,mdp")] MPersonne nouvellePersonne)
        {
            ViewBag.Message = "Ajouter";
            nouvellePersonne.mdp = progPersonne.hasherMdp(nouvellePersonne);
            this.addPersonne(nouvellePersonne);
            return RedirectToAction("Personne");
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

        [HttpGet]
        public IActionResult Modifier(int id) 
        {
          MPersonne modifPersonne = new MPersonne();
          modifPersonne.idPersonne = id;  
          return View(modifPersonne);
        }

        [HttpPost]
        public IActionResult Enregistrer([Bind("idPersonne,nomPersonne,prenomPersonne,mdp")] MPersonne modifPersonne)
        {
           modifPersonne.mdp = progPersonne.hasherMdp(modifPersonne);
           this.updatePersonne(modifPersonne);
           return View();
        }

        public void updatePersonne(MPersonne modifPersonne) 
        {
            dataPersonnes.updatePersonne(modifPersonne);
        }

        public IActionResult Connecter()
        {
            return View();
        }
    }
}
