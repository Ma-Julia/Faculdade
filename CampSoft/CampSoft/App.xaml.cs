using CampSoft.componentes;

namespace CampSoft
{
    public partial class App : Application
    {
        //private readonly Conexao conexaoBanco;
        public App()
        {
            InitializeComponent();
            //conexaoBanco = new Conexao("Data Source=192.168.0.6,1433;Initial Catalog=dbCampSoft;User ID=sa;Password=root123;Trust Server Certificate=True;Encrypt=False");
            MainPage = new MainPage();
           
    }
        //public Conexao? Conexao => conexaoBanco;

    }
}
