using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSoft.Classes
{
    internal class Agenda
    {
        public int IdAgendamento { get; set; }
        public int IdHorario { get; set; }
        public int IdUsuario { get; set; }
        public DateOnly DataAgendamento { get; set; }

    }
}
