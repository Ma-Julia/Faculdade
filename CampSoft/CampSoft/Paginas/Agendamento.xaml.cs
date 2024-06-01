namespace CampSoft.Paginas;

public partial class Agendamento : ContentPage
{
	public Agendamento()
	{
        
        InitializeComponent();
	}

    private void BtnVoltar_Clicked(object sender, EventArgs e)
    {

    }

    private void BtnAgendar_Clicked(object sender, EventArgs e)
    {

    }

    private void DataAgendamento_DateSelected(object sender, DateChangedEventArgs e)
    {
        var dataSelecionada = e.NewDate;
        DisplayAlert( "teste", dataSelecionada.ToString("dd/MM/yyyy") , "ok");
    }
}