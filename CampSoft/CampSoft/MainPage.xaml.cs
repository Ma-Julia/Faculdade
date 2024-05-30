namespace CampSoft
{
    public partial class MainPage : TabbedPage
    {
        String nome;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BTNSorteioSimples_Clicked(object sender, EventArgs e)
        {
            nome = await DisplayPromptAsync("Nome", "Digite seu nome:", "OK");
            await DisplayAlert("Nome", "Olá, " + nome + "!", "OK");
        }
    }

}
