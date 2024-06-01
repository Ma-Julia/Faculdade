using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSoft.Classes
{
    internal class Jogador
    {
        public int IdJogador { get; set; }
        public string? Nome { get; set;}
        public Classe.Tipo classe { get; set; }
        public int IdEquipe {  get; set; }
        public int IdUsuario {  get; set; }
        
    }
}
