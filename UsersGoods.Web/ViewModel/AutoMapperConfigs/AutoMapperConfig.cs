using AutoMapper;
using UsersGoods.Web.Services.DTO;
using UsersGoods.Web.ViewModel.Goods;
using UsersGoods.Web.ViewModel.Users;

namespace UsersGoods.Web.ViewModel.AutoMapperConfigs
{
    public class AutoMapperConfig
    {
        public static void CreateMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TopGoodDTO, TopGoodViewModel>();
            cfg.CreateMap<GoodDTO, GoodViewModel>();
            cfg.CreateMap<UserDTO, UserViewModel>();
        }
    }
}