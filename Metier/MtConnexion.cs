using RazorLogin.Models;
using RazorLogin.Repository;
using RazorLogin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Intrinsics.Arm;

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

        public static bool DecrypterMdp(byte[] mdpHashe, byte[] mdp)
        {
       
             return mdp.SequenceEqual(mdpHashe);
        }
        public bool Connecter(MPersonne personneConnect, HttpContext httpContext)
        {
            List<MPersonne> personnes = dataPersonnes.GetPersonnes();
            MPersonne personneTrouvee = personnes.FirstOrDefault(p => p.nomPersonne == personneConnect.nomPersonne && p.prenomPersonne == personneConnect.prenomPersonne);

            if (personneTrouvee != null && DecrypterMdp(personneTrouvee.mdp, personneConnect.mdp))
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
        public void Deconnecter(HttpContext httpContext)
        {
             httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
        }
    }
}
