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
            RequestGetPersonnes.CommandText = "SELECT * FROM personne";

            SqlDataReader personnes = RequestGetPersonnes.ExecuteReader();

            while (personnes.Read())
            {
                MPersonne unePersonne = new MPersonne();
                unePersonne.idPersonne = personnes.GetInt32(0);
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
            RequestAddPersonne.CommandText = "INSERT INTO personne (nomPersonne, prenomPersonne, mdp) VALUES (@nomPersonne,@prenomPersonne,@mdp)";

            SqlParameter nom = RequestAddPersonne.Parameters.Add("@nomPersonne", SqlDbType.VarChar);
            SqlParameter pnom = RequestAddPersonne.Parameters.Add("@prenomPersonne", SqlDbType.VarChar);
            SqlParameter mdp = RequestAddPersonne.Parameters.Add("@mdp", SqlDbType.VarChar);

            nom.Value = nouvellePersonne.nomPersonne;
            pnom.Value = nouvellePersonne.prenomPersonne;
            mdp.Value = nouvellePersonne.mdp;

            int result = RequestAddPersonne.ExecuteNonQuery();

        }

        public void deletePersonne(int idSuppr)
        {
            SqlCommand RequestDeletePersonne = activeConnexion.CreateCommand();
            RequestDeletePersonne.CommandText = "DELETE FROM personne WHERE idPersonne = @idPersonne";

            SqlParameter id = RequestDeletePersonne.Parameters.Add("@idPersonne", SqlDbType.VarChar);

            id.Value = idSuppr;

            int result = RequestDeletePersonne.ExecuteNonQuery();
        }

        public void updatePersonne(MPersonne modifPersonne)
        {
            SqlCommand RequestUpdatePersonne = activeConnexion.CreateCommand();
            RequestUpdatePersonne.CommandText = "UPDATE personne SET nomPersonne= @nomPersonne, prenomPersonne= @prenomPersonne, mdp = @mdp WHERE idPersonne == @idPersonne";


            SqlParameter id = RequestUpdatePersonne.Parameters.Add("@idPersonne", SqlDbType.VarChar);
            SqlParameter nom = RequestUpdatePersonne.Parameters.Add("@nomPersonne", SqlDbType.VarChar);
            SqlParameter pnom = RequestUpdatePersonne.Parameters.Add("@prenomPersonne", SqlDbType.VarChar);
            SqlParameter mdp = RequestUpdatePersonne.Parameters.Add("@mdp", SqlDbType.VarChar);

          

            id.Value = modifPersonne.idPersonne;
            nom.Value = modifPersonne.nomPersonne;
            pnom.Value = modifPersonne.prenomPersonne;
            mdp.Value = modifPersonne.mdp;

            int result = RequestUpdatePersonne.ExecuteNonQuery();
        }
    }
}
