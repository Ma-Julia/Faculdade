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

        public ConexaoSQL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlConnection ObterConexao()
        {
            return new SqlConnection(connectionString);
        }
    }
}
