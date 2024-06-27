using CampSoft.Classes;
using CampSoft.componentes;
using CampSoft.DAO;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific;
using Label = Microsoft.Maui.Controls.Label;
using ScrollView = Microsoft.Maui.Controls.ScrollView;
using StackLayout = Microsoft.Maui.Controls.StackLayout;

namespace CampSoft.Paginas;

public partial class Agendamento : ContentPage
{
    private HorariosDisponiveisDAO horariosDisponiveisDAO;
	public Agendamento()
	{
        InitializeComponent();
        ConexaoSQL conexao = new ConexaoSQL();
        horariosDisponiveisDAO = new HorariosDisponiveisDAO(conexao);
    }

    private void BtnVoltar_Clicked(object sender, EventArgs e)
    {

    }

    private void BtnAgendar_Clicked(object sender, EventArgs e)
    {

    }

    private void DataAgendamento_DateSelected(object sender, DateChangedEventArgs e)
    {
        List<HorariosDisponiveis> horariosDisponiveis = new List<HorariosDisponiveis>();
        horariosDisponiveis = horariosDisponiveisDAO.BuscarHorariosDisponiveisPorData(e.NewDate);
        ListaHorarioDisponivel.Children.Clear();
        if (!horariosDisponiveis.IsNullOrEmpty())
        {
            foreach (HorariosDisponiveis horario in horariosDisponiveis)
            {
                var button = CriarBotao(horario);
                button.Clicked += (sender, e) => ShowModal(horario, sender, e);
                ListaHorarioDisponivel.Children.Add(button);
            }
        }
    }

    private Button CriarBotao(HorariosDisponiveis horario)
    {
        var button = new Button
        {
            Text = $"{horario.DataHoraInicio:HH:mm}",
            FontAttributes = FontAttributes.Bold,
            TextColor = Color.FromArgb("#27341E")
        };
        return button;
    }

    private async void ShowModal(HorariosDisponiveis horarioDisponivel, object sender, EventArgs e)
    {
        // Get the button that was clicked
        var button = (Button)sender;

        var modal = new StackLayout
        {
            //BackgroundColor = Color.FromArgb("#"),
            Padding = 20,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
        };

        // Display date and time information
        var dateLabel = new Label
        {
            Text = $"Data: {horarioDisponivel.DataHoraInicio:dd/MM/yyyy}",
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
        };
        modal.Children.Add(dateLabel);

        var timeLabel = new Label
        {
            Text = $"Horário: {horarioDisponivel.DataHoraInicio:HH:mm}",
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
        };
        modal.Children.Add(timeLabel);

        var campoLabel = new Label
        {
            Text = $"Campo: Clube Albatroz",
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
        };
        modal.Children.Add(campoLabel);

        // Add scheduling and cancellation buttons
        var schedulingButton = new Button
        {
            Text = "Agendar",
            BackgroundColor = Color.FromArgb("#27341E")
           
        };
        schedulingButton.Clicked += (sender, e) => ScheduleAppointment(horarioDisponivel);
        modal.Children.Add(schedulingButton);

        var cancellationButton = new Button
        {
            Text = "Cancelar",
            BackgroundColor = Color.FromArgb("#27341E")
        };
        cancellationButton.Clicked += (sender, e) => CancelAppointment(horarioDisponivel);
        modal.Children.Add(cancellationButton);

        var btnVoltar = new Button
        {
            
            ImageSource = "voltar.png",
            HeightRequest = 50,
            HorizontalOptions = LayoutOptions.Start
        };
        btnVoltar.Clicked += (sender, e) => Navigation.PopModalAsync();

        var stackLayout = new StackLayout
        {
            Orientation = StackOrientation.Vertical
        };

        stackLayout.Children.Add(btnVoltar);

        var scrollView = new ScrollView();

        var verticalStackLayout = new VerticalStackLayout
        {
            BackgroundColor = Color.FromArgb("#CFBCA8"),
            Padding = new Thickness(40),
            Spacing = 25
        };

        verticalStackLayout.Children.Add(modal);
        verticalStackLayout.Children.Add(stackLayout);
        scrollView.Content = verticalStackLayout;
        var contentPage = new ContentPage
        {
            Content = scrollView
        };

        await Navigation.PushModalAsync(contentPage);
    }

    private void ScheduleAppointment(HorariosDisponiveis horarioDisponivel)
    {
        // Implement logic to schedule an appointment for the given time slot
        // This might involve updating a database or sending an appointment confirmation
        DisplayAlert("Agendamento", "Agendamento realizado com sucesso!", "OK");
    }

    private void CancelAppointment(HorariosDisponiveis horarioDisponivel)
    {
        // Implement logic to cancel an appointment for the given time slot
        // This might involve updating a database or sending a cancellation notification
        DisplayAlert("Agendamento", "Agendamento cancelado com sucesso!", "OK");
    }
}