using RazorLogin.Repository;
using RazorLogin.Models;

namespace RazorLogin.Metier
{
    public class MtPersonne
    {
        public string hasherMdp(MPersonne personneAjoutee)
        {
            Int32 mdpHashe = personneAjoutee.mdp.GetHashCode();  
            return mdpHashe.ToString();
        }
    }
}
