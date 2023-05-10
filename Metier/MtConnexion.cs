using RazorLogin.Models;
using RazorLogin.Repository;
using RazorLogin.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace RazorLogin.Metier
{
    public class MtConnexion
    {
        RepMPersonne dataPersonnes = new RepMPersonne();

        public void connecter(MPersonne personneConnect)
        {
            List<MPersonne> personnes = new List<MPersonne>();
            personnes = dataPersonnes.GetPersonnes();
            MPersonne unePersonne = new MPersonne();

            if (personnes.Any(personne => personne.nomPersonne == personneConnect.nomPersonne) && personnes.Any(personne => personne.prenomPersonne== personneConnect.prenomPersonne) && personnes.Any(personne => personne.mdp == personneConnect.mdp)) 
            {
                unePersonne = personnes.Find(personne => personne.nomPersonne == personneConnect.nomPersonne);
            }

        }
    }
}
