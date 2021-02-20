using Craftsman.Domain.Constants;
using Craftsman.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace Craftsman.Infrastructure.CrossCutting.Bootstraper
{
    public static class GlobalSettingEnvironmentLoad
    {
        public static void LoadSetting(this IConfiguration configuration)
        {
            GlobalSettings.StringConnection = configuration.GetConnectionString(ConstantValue.StringConnectionKey);
            GlobalSettings.UrlViaCep = "https://viacep.com.br/";
        }
    }
}