
using Microsoft.IdentityModel.Tokens;

namespace CampSoft.Paginas;

public partial class SorteioSimples : ContentPage
{
    private int _quantidadejogadores, _numerosSorteados, _numerosAzuisSorteados, _numerosAmarelosSorteados;
    private List<int> _caixaSorteio;
    private bool _stProximoSorteio;
	public SorteioSimples()
	{
        _quantidadejogadores = 0;
        _numerosSorteados = 0;
        _numerosAzuisSorteados = 0;
        _numerosAmarelosSorteados = 0;
        _caixaSorteio = new List<int>();
        InitializeComponent();

	}

    private void BtnVoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void BtnReiniciar_Clicked(object sender, EventArgs e)
    {
        _numerosSorteados = 0;
        _numerosAzuisSorteados = 0;
        _numerosAmarelosSorteados = 0;
        lblNumerosSorteados.Text = "Numeros sorteados: 0";
        lblQuantidadeAzul.Text = "Azul: 0";
        lblQuantidadeAmarelo.Text = "Amarelo: 0";
        CorSorteio.BackgroundColor = Colors.White;
        prepararSorteio();
    }

    private void BtnSortear_Clicked(object sender, EventArgs e)
    {
        var numeroSorteado = new Random();
        _stProximoSorteio = false;

        while (!_stProximoSorteio && !_caixaSorteio.IsNullOrEmpty())
        {
            int numero = numeroSorteado.Next(_quantidadejogadores) + 1 ;
            if (_caixaSorteio.Contains(numero))
            {
                _numerosSorteados++;

                if (numero % 2 == 0){
                    _numerosAzuisSorteados++;
                    CorSorteio.BackgroundColor = Colors.Blue;
                }
                else {
                    _numerosAmarelosSorteados++;
                    CorSorteio.BackgroundColor = Colors.Yellow;
                }

                _caixaSorteio.Remove(numero);
                _stProximoSorteio = true;
            }
        }

        lblNumerosSorteados.Text = "Numeros sorteados: " + _numerosSorteados;
        lblQuantidadeAzul.Text = "Azul: " + _numerosAzuisSorteados;
        lblQuantidadeAmarelo.Text = "Amarelo: " + _numerosAmarelosSorteados;

    }

    private void EdtQuantidade_TextChanged(object sender, TextChangedEventArgs e)
    {
       
        if (!e.NewTextValue.IsNullOrEmpty()) {
            _quantidadejogadores = Convert.ToInt32(e.NewTextValue);
            prepararSorteio();
        }
        else
        {
            _quantidadejogadores = 0;
            lblNumerosSorteados.Text = "Numeros sorteados: 0";
            lblQuantidadeAzul.Text = "Azul: 0";
            lblQuantidadeAmarelo.Text = "Amarelo: 0";

        }
    }

    private void prepararSorteio()
    {
        _caixaSorteio.Clear();

        for (int i = 0; i < _quantidadejogadores; i++)
        {
            _caixaSorteio.Add(i + 1);
        }
    }
    /*protected override void OnAppearing()
{
base.OnAppearing();

}*/
}