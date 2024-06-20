using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data;

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
