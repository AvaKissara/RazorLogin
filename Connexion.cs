using System.Data.SqlClient;

namespace RazorLogin
{
    public class Connexion
    {
        public SqlConnection GetConnexion()
        {
            SqlConnection connexion = new SqlConnection(@"Data Source=LEODAGAN;Initial Catalog=LoginRazor;Persist Security Info=True;User ID=sa;Password=It@chi8!");
            connexion.Open();
            return connexion;
        }
    }
}
