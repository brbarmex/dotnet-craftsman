using Craftsman.Infrastructure.DataBase.Mapping;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace Craftsman.Infrastructure.CrossCutting.Bootstraper
{
    public static class FluentMap
    {
        public static void LoadMapping()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new CustomerMapping());
                config.ForDommel();
            });
        }
    }
}