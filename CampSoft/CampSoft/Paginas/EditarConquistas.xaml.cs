namespace CampSoft.Paginas;

public partial class EditarConquistas : ContentPage
{
	public EditarConquistas()
	{
		InitializeComponent();
	}

    private void DataEvento_DateSelected(object sender, DateChangedEventArgs e)
    {
        
    }

    private async void BTNVoltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private void BTNOK_Clicked(object sender, EventArgs e)
    {

    }
}