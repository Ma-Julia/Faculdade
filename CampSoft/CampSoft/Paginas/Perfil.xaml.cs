using CampSoft.Classes;
using CampSoft.componentes;
using CampSoft.DAO;

namespace CampSoft.Paginas;

public partial class Perfil : ContentPage
{
    private Jogador _jogador;
    private JogadorDAO _jogadorDAO;
	public Perfil()
	{
        InitializeComponent();
        ConexaoSQL conexao = new ConexaoSQL();
        _jogadorDAO = new JogadorDAO(conexao);

        _jogador = _jogadorDAO.BuscarJogador(2);

        BindingContext = _jogador;
         
        //lblNome.Text = "Nome: " + _jogador.Nome;
        //lblClasse.Text = "Classe: " + _jogador.classe;
        //lblEquipe.Text = "Equipe: " + _jogador.Equipe;
    }

    private async void BNTEditar_Clicked(object sender, EventArgs e)
    {
        _jogador = _jogadorDAO.BuscarJogador(2);
        await Navigation.PushModalAsync(new EditarPerfil(_jogador, _jogadorDAO));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        lblNome.Text = "Nome: " + _jogador.Nome;
        lblClasse.Text = "Classe: " + _jogador.classe;
        lblEquipe.Text = "Equipe: " + _jogador.Equipe;

        MessagingCenter.Subscribe(this, "AtualizarPerfil", (Jogador jogador) =>
        {
            BindingContext = jogador;
        });
        
    }

}