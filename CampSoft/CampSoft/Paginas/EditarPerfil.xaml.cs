using CampSoft.Classes;
using CampSoft.componentes;
using CampSoft.DAO;

namespace CampSoft.Paginas;

public partial class EditarPerfil : ContentPage
{
    private readonly ConexaoService conexaoService;
	public EditarPerfil(ConexaoService conexaoService)
	{
        this.conexaoService = conexaoService;
        InitializeComponent();
	}

    private async void BtnVoltar_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }

    private void BtnOk_Clicked(object sender, EventArgs e)
    {
        Jogador jogador = new Jogador();

        jogador.Nome = EntNome.Text;
        var selectedItem = (string)picker.SelectedItem;
        Jogador.Classe classeJogador = (Jogador.Classe) Enum.Parse(typeof(Jogador.Classe), selectedItem);
        jogador.classe = classeJogador;
        jogador.Equipe = EntEquipe.Text;

        var jogadorDAO = new JogadorDAO(conexaoService.ObterConexao());

        jogadorDAO.CriarJogador(jogador);
    }
}