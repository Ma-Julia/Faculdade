namespace CampSoft.Paginas;

public partial class EditarPerfil : ContentPage
{
	public EditarPerfil()
	{
        
	}

    private async void BtnVoltar_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }

    private void BtnOk_Clicked(object sender, EventArgs e)
    {

    }
}