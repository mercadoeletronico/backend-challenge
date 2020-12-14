using AutoMapper;
using ME.Api.Models.DataModels;
using ME.Api.Models.View.Pedido;
using System;
using System.Collections.Generic;
using System.Text;

namespace ME.Api.Service.Mapper
{
    public class ClassMapper : Profile
    {

        public ClassMapper()
        {

            CreateMap<Pedido, PedidoUpdateRequest>().ReverseMap();
            CreateMap<Pedido, PedidoStatusRequest>().ReverseMap();
            CreateMap<Pedido, PedidoNewRequest>().ReverseMap();
            CreateMap<Pedido, PedidoGetRequest>().ReverseMap();
        }


    }
}
