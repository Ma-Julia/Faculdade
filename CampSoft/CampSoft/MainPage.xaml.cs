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
            var paginaAgendamento = new Agendamento()
            {
                Title = "",
                IconImageSource = "Agenda"
            };
        
           
            InitializeComponent();
            this.Children.Add(paginaAgendamento);

           
        }

        private async void BTNSorteioSimples_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new SorteioSimples());
            
           
        }

    }

}
