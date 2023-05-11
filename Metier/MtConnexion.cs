using RazorLogin.Models;
using RazorLogin.Repository;
using RazorLogin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


namespace RazorLogin.Metier
{
    public class MtConnexion
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly RepMPersonne dataPersonnes;

        public MtConnexion()
        {
            dataPersonnes = new RepMPersonne();
        }

        public MtConnexion(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            dataPersonnes = new RepMPersonne();
        }

        public bool Connecter(MPersonne personneConnect, HttpContext httpContext)
        {
            List<MPersonne> personnes = dataPersonnes.GetPersonnes();
            bool utilisateurExiste = personnes.Any(p => p.nomPersonne == personneConnect.nomPersonne && p.prenomPersonne == personneConnect.prenomPersonne && p.mdp== personneConnect.mdp);

            if (utilisateurExiste)
            {
                // Créer une instance de ClaimsIdentity (type d'objet associé à l'utilisateur authentifié, stocke les Claim (déclaration sur l'identité d'un utilisateur))
                var prerequis = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, personneConnect.nomPersonne + " " + personneConnect.prenomPersonne)
                };
                var claimsIdentity = new ClaimsIdentity(prerequis, CookieAuthenticationDefaults.AuthenticationScheme);

                // Créer une instance de AuthenticationProperties (définit les propriétés associées à une demande d'authentification) et y ajouter des propriétés
                var authProperties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                   // durée de validité d'une authentification
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60)
                };

                // Connexion de l'utilisateur
                httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties).Wait();

                return true;    
            }

            return false;
        }
    }
}
