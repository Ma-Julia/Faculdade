using CampSoft.componentes;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace CampSoft
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var connectionString = "Data Source=192.168.0.7,1435;Initial Catalog=dbCampSoft;User ID=sa;Password=root123;Trust Server Certificate=True;Encrypt=False";
            var conexao = new ConexaoSQL(connectionString);
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
