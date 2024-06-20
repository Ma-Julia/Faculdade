using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CampSoft.Classes
{
    public class Jogador : INotifyPropertyChanged
    {
        public int IdJogador { get; set; }
        public string? Nome { get; set;}
        public Classe classe { get; set; }
        public string? Equipe {  get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public enum Classe
        {
            Assault = 1,
            DMR = 2,
            Sniper = 3,
            Suporte = 4
        }

    }
}
