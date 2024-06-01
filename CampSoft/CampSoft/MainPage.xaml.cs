using CampSoft.Paginas;

namespace CampSoft
{
    public partial class MainPage : TabbedPage
    {
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
