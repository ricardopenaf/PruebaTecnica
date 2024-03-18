using AutoMapper;
using PruebaTecnica.DTOs;
using PruebaTecnica.Models;

namespace PruebaTecnica.Helpers
{
    /// <summary>
    /// auto mapper para trabajar con las tbls de la bd como objetos en la aplicación
    /// </summary>
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Usuario, usuarioCreacionDTO>().ReverseMap();
        }
    }
}
