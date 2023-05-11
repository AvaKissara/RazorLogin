using Microsoft.AspNetCore.Mvc;
using RazorLogin.Models;
using RazorLogin.Repository;
using RazorLogin.Metier;
using System.Text;

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
        public IActionResult Logged(string nomPersonne, string prenomPersonne, string mdp)
        {
            var httpContext = ControllerContext.HttpContext;
            MPersonne personneConnect = new MPersonne();    
            personneConnect.nomPersonne = nomPersonne;
            personneConnect.prenomPersonne = prenomPersonne;

            byte[] mdpBytes = Encoding.UTF8.GetBytes(mdp);
            personneConnect.mdp = MtPersonne.hasherMdp(mdpBytes);
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
