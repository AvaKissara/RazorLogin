using RazorLogin.Repository;
using RazorLogin.Models;

namespace RazorLogin.Metier
{
    public class MtPersonne
    {
        RepMPersonne dataPersonnes = new RepMPersonne();
        public Int32 hasherMdp(MPersonne personneAjoutee)
        {
            Int32 mdpHashe = personneAjoutee.mdp.GetHashCode();  
            return mdpHashe;
        }
    }
}
