﻿using CampSoft.componentes;
using CampSoft.Paginas;
using Microsoft.Data.SqlClient;

namespace CampSoft
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            var paginaConquistas = new Conquistas()
            {         
                IconImageSource = "conquistas"
            };
            var paginaAgendamento = new Agendamento()
            {
                IconImageSource = "Agenda"
            };

            var paginaPerfil = new Perfil()
            {
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

        private async void BTNCadastroEquipe_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CadastroEquipe());
        }
    }

}
