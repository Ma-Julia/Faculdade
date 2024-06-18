using CampSoft.DAO;

namespace CampSoft.Paginas;

public partial class Perfil : ContentPage
{
    private readonly ConexaoService conexaoService;
	public Perfil(ConexaoService conexaoService)
	{
        this.conexaoService = conexaoService;
		InitializeComponent();
	}

    private async void BNTEditar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new EditarPerfil(conexaoService));
    }
}