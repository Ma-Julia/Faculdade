using CampSoft.Classes;
using CampSoft.componentes;
using CampSoft.DAO;

namespace CampSoft.Paginas;

public partial class EditarPerfil : ContentPage
{
    private Jogador _jogador;
    private JogadorDAO _jogadorDAO;
    public EditarPerfil(Jogador jogador, JogadorDAO jogadorDAO)
	{
        _jogador = jogador;
        _jogadorDAO = jogadorDAO;
        InitializeComponent();
        BindingContext = _jogador;
        picker.ItemsSource = Enum.GetValues(typeof(Jogador.Classe));
        picker.SelectedItem = _jogador.classe;
	}

    private async void BtnVoltar_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }

    private async void BtnOk_Clicked(object sender, EventArgs e)
    {
       try
        {
            _jogador = _jogadorDAO.BuscarJogador(2);

            _jogador.Nome = EntNome.Text;
            _jogador.classe = (Jogador.Classe)picker.SelectedItem;
            _jogador.Equipe = EntEquipe.Text;

            _jogadorDAO.AtualizarJogador(_jogador);
            await DisplayAlert("Alteração de Usuario", "Cadastro feito com sucesso", "OK"); 
            MessagingCenter.Send(this, "AtualizarPerfil", _jogador);
            await Navigation.PopModalAsync();
        }
        catch (Exception ex) {
            await DisplayAlert("Erro", "Não foi possivel cadastrar. \nMotivo: " + ex.Message, "OK");
        }


    }
}