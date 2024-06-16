namespace CampSoft.Paginas;

public partial class Conquistas : ContentPage
{
	public Conquistas()
	{
		InitializeComponent();
	}
    private void BTNVoltar_Clicked(object sender, EventArgs e)
    {

    }

    private void BTNIr_Clicked(object sender, EventArgs e)
    {

    }

    private async void BNTEditar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new EditarConquistas());
    }
}