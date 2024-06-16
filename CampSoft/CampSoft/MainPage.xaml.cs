using CampSoft.componentes;
using CampSoft.Paginas;
using Microsoft.Data.SqlClient;

namespace CampSoft
{
    public partial class MainPage : TabbedPage
    {
        //private readonly Conexao conexao;
        public MainPage()
        {
            var paginaConquistas = new Conquistas()
            {
                Title = "",
                IconImageSource = "conquistas"
            };
            var paginaAgendamento = new Agendamento()
            {
                Title = "",
                IconImageSource = "Agenda"
            };

            var paginaPerfil = new Perfil()
            {
                Title = "",
                IconImageSource = "Perfil"
            };

            InitializeComponent();
            this.Children.Add(paginaConquistas);
            this.Children.Add(paginaAgendamento);
            this.Children.Add(paginaPerfil);


        }

        private async void BTNSorteioSimples_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new SorteioSimples());
            
           
        }

        private async void BTNSorteioCompleto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SorteioCompleto());
        }

        private void BTNAgendarCampo_Clicked(object sender, EventArgs e)
        {

        }

        private void BTNCadastroTime_Clicked(object sender, EventArgs e)
        {

        }
    }

}
