using CampSoft.Paginas;

namespace CampSoft
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BTNSorteioSimples_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new SorteioSimples());
            
           
        }

    }

}
