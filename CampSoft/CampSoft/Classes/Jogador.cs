using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CampSoft.Classes
{
    public class Jogador : INotifyPropertyChanged
    {
        public int IdJogador { get; set;}
        public string? Nome { get; set;}
        public Classe classe { get; set;}
        public string? Equipe {  get; set;}

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public enum Classe
        {
            Assault,
            DMR,
            Sniper,
            Suporte
        }

    }
}
