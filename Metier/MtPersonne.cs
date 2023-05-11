using RazorLogin.Repository;
using RazorLogin.Models;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Intrinsics.Arm;

namespace RazorLogin.Metier
{
    public class MtPersonne
    {
        public static byte[] hasherMdp(byte[] mdp)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = mdp;
                return sha256.ComputeHash(passwordBytes);
            }
        }
    }
}
