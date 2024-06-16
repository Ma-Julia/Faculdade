namespace CampSoft.Paginas;

public partial class EditarPerfil : ContentPage
{
	public EditarPerfil()
	{
        InitializeComponent();
	}

    private async void BtnVoltar_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }
}