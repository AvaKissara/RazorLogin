using RazorLogin.Models;
using System.Data;
using System.Data.SqlClient;

namespace RazorLogin.Repository
{
    public class RepMPersonne
    {
        private SqlConnection activeConnexion;
        public RepMPersonne()
        {
            this.dbConnecter();
        }

        private void dbConnecter()
        {
            Connexion con = new Connexion();
            this.activeConnexion = con.GetConnexion();
        }
        public List<MPersonne> GetPersonnes()
        {
            List<MPersonne> ListMPersonnes = new List<MPersonne>();

            SqlCommand RequestGetPersonnes = activeConnexion.CreateCommand();
            RequestGetPersonnes.CommandText = "Select * from personne";

            SqlDataReader personnes = RequestGetPersonnes.ExecuteReader();

            while (personnes.Read())
            {
                MPersonne unePersonne = new MPersonne();
                unePersonne.nomPersonne = $"{personnes[1]}";
                unePersonne.prenomPersonne = $"{personnes[2]}";
                unePersonne.mdp = $"{personnes[3]}";
                ListMPersonnes.Add(unePersonne);
            }

            // Fermeture de la connexion
            this.activeConnexion.Close();


            return ListMPersonnes;
        }



        public void addPersonne(MPersonne nouvellePersonne)
        {
            SqlCommand RequestAddPersonne = activeConnexion.CreateCommand();
            RequestAddPersonne.CommandText = "Insert into personne (nomPersonne, prenomPersonne, mdp) VALUES (@nomPersonne,@prenomPersonne,@mdp)";

            SqlParameter nom = RequestAddPersonne.Parameters.Add("@nomPersonne", SqlDbType.VarChar);
            SqlParameter pnom = RequestAddPersonne.Parameters.Add("@prenomPersonne", SqlDbType.VarChar);
            SqlParameter mdp = RequestAddPersonne.Parameters.Add("@mdp", SqlDbType.VarChar);

            nom.Value = nouvellePersonne.nomPersonne;
            pnom.Value = nouvellePersonne.prenomPersonne;
            mdp.Value = nouvellePersonne.mdp;

            int result = RequestAddPersonne.ExecuteNonQuery();

        }

        public void deletePersonne(MPersonne effacePersonne)
        {
            SqlCommand RequestDeletePersonne = activeConnexion.CreateCommand();
            RequestDeletePersonne.CommandText = "DELETE from personne WHERE idPersonne = @idPersonne";

            SqlParameter id = RequestDeletePersonne.Parameters.Add("@idPersonne", SqlDbType.VarChar);

            id.Value = effacePersonne.idPersonne;

            int result = RequestDeletePersonne.ExecuteNonQuery();
        }
    }
}
