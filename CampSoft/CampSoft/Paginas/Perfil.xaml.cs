namespace CampSoft.Paginas;

public partial class Perfil : ContentPage
{
	public Perfil()
	{
		InitializeComponent();
	}

    private async void BNTEditar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new EditarPerfil());
    }
}