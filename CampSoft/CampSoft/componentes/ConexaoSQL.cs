using Microsoft.Data.SqlClient;

namespace CampSoft.componentes
{

    public class ConexaoSQL
    {
        private string connectionString;

        public SqlConnection ObterConexao()
        {
            connectionString = "Data Source=192.168.0.7,1435;Initial Catalog=dbCampSoft;User ID=sa;Password=root123;Trust Server Certificate=True;Encrypt=False";

            return new SqlConnection(connectionString);
        }
    }
}
