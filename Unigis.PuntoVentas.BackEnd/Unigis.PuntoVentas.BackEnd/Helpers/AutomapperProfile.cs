using AutoMapper;
using Unigis.PuntoVentas.BackEnd.Data.DTOs;
using Unigis.PuntoVentas.BackEnd.Data.Entidades;

namespace Unigis.PuntoVentas.BackEnd.Helpers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<PuntoDeVentasCreacionDTO, PuntoDeVentas>();   
        }
    }
}