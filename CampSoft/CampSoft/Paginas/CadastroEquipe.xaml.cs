namespace CampSoft.Paginas;

public partial class CadastroEquipe : ContentPage
{
	public CadastroEquipe()
	{
		InitializeComponent();
	}

    private async void BNTEditar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new EditarEquipe());
    }
}