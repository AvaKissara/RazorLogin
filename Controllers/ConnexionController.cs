using Microsoft.AspNetCore.Mvc;
using RazorLogin.Models;
using RazorLogin.Repository;
using RazorLogin.Metier;

namespace RazorLogin.Controllers
{
    public class ConnexionController : Controller
    {

        MtConnexion progConnexion = new MtConnexion();
        public IActionResult Connexion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logged(string nomPersonne, string prenomPersonne, byte[] mdp)
        {
            var httpContext = ControllerContext.HttpContext;
            MPersonne personneConnect = new MPersonne();    
            personneConnect.nomPersonne = nomPersonne;
            personneConnect.prenomPersonne = prenomPersonne;
            personneConnect.mdp = mdp;

            bool connecte = progConnexion.Connecter(personneConnect, httpContext);

            if (connecte)
            {
                return View(personneConnect);
            }
            else
            {
                return RedirectToAction("Connexion");
            }
        }

        public IActionResult Deconnexion() 
        {
            progConnexion.Deconnecter(HttpContext);
            return RedirectToAction("Index", "Home");
        }
    }
}
