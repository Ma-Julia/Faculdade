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
        ListaHorarioDisponivel.Children.Add(new Button { Text = dataSelecionada.ToString("dd/MM/yyyy") });
        DisplayAlert( "teste", dataSelecionada.ToString("dd/MM/yyyy") , "ok");
    }
}