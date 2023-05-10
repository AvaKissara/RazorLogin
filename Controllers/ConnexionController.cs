using Microsoft.AspNetCore.Mvc;
using RazorLogin.Models;
using RazorLogin.Repository;
using RazorLogin.Metier;

namespace RazorLogin.Controllers
{
    public class ConnexionController : Controller
    {
        MtConnexion test = new MtConnexion();
        public IActionResult Connexion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logged(string nomPersonne, string prenomPersonne, string mdp)
        {
            MPersonne personneConnect = new MPersonne();    
            personneConnect.nomPersonne = nomPersonne;
            personneConnect.prenomPersonne = prenomPersonne;
            personneConnect.mdp = mdp;
            test.connecter(personneConnect);
            return View(personneConnect);
        }
    }
}
