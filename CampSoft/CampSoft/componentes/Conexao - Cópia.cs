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

    public class Conexao
    {
        private readonly string _sql;
        private SqlConnection conexao;

        public Conexao(string sql)
        {
            _sql = sql;
        }

        public SqlConnection GetConnection()
        {
            conexao = new SqlConnection(_sql);
            conexao.Open();
            return conexao;
        }

        private void CloseConnection()
        {
            if (conexao != null && conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public void Executar(string sql) {
            using (var conexao = GetConnection())
            {
                using (var command = new SqlCommand(sql, conexao))
                {
                   command.ExecuteNonQuery();
                }

            }
         
        }

        public List<T> Consulta<T>(string sql, bool closeConnection = true)
        {
            using (var connection = GetConnection())
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    var results = new List<T>();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = ParseRowToObject<T>(reader);
                            results.Add(item);
                        }
                    }

                    if (closeConnection)
                    {
                        CloseConnection();
                    }

                    return results;
                }
            }
        }

        private T ParseRowToObject<T>(SqlDataReader reader)
        {
            return default;
        }
    }
}
