using CampSoft.componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSoft.DAO
{
    public class ConexaoService
    {
        private string connectionString;
        private ConexaoSQL conexaoSQL;

        public ConexaoService(string connectionString) { 
            this.connectionString = connectionString;
            this.conexaoSQL = new ConexaoSQL(connectionString);
        }

        public ConexaoSQL ObterConexao()
        {
            return conexaoSQL;  
        }
    }
}
