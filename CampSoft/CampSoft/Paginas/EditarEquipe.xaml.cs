namespace CampSoft.Paginas;

public partial class EditarEquipe : ContentPage
{
	public EditarEquipe()
	{
	
	}

    private async void BTNVoltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private void BTNOk_Clicked(object sender, EventArgs e)
    {

    }
}