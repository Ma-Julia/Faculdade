using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSoft.Classes
{
    public class Jogador
    {
        public int IdJogador { get; set; }
        public string? Nome { get; set;}
        public Classe classe { get; set; }
        public string? Equipe {  get; set; }

        public enum Classe
        {
            Assault = 1,
            DMR = 2,
            Sniper = 3,
            Suporte = 4
        }

    }
}
