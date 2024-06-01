using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace CampSoft.componentes
{

    public class Conexao
    {
        private readonly string _sql;

        public Conexao(string sql)
        {
            _sql = sql;
        }

        public SqlConnection GetConnection()
        {
            var conexao = new SqlConnection(_sql);
            conexao.Open();
            return conexao;
        }
    }
}
