namespace CampSoft.Paginas;

public partial class SorteioCompleto : ContentPage
{
	public SorteioCompleto()
	{
		InitializeComponent();
	}

    private async void BtnVoltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private void BtnSortear_Clicked(object sender, EventArgs e)
    {

    }

    private void BtnReiniciar_Clicked(object sender, EventArgs e)
    {

    }
}