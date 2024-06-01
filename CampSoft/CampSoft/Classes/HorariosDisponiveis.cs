using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSoft.Classes
{
    internal class HorariosDisponiveis
    {
        public int IdHorario { get; set; }
        public DateOnly DiaSemana { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFinal { get; set; }
    }
}
