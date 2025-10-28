using AutoMapper;
using GeekShopping.ProdutAPI.Data.ValueObejects;
using GeekShopping.ProdutAPI.Model;

namespace GeekShopping.ProdutAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(Config =>
            {
                Config.CreateMap<ProductVO, Productc>();
                Config.CreateMap<Productc, ProductVO>();
            });
            return mappingConfig;
        }
    }
}
