namespace CampSoft.Paginas;

public partial class SorteioSimples : ContentPage
{
	public SorteioSimples()
	{
		InitializeComponent();

	}

    private void BtnVoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void BtnReiniciar_Clicked(object sender, EventArgs e)
    {

    }

    private void BtnSortear_Clicked(object sender, EventArgs e)
    {

    }
    /*protected override void OnAppearing()
{
base.OnAppearing();

}*/
}