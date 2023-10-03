using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_LIVROS.Domain;
using API_LIVROS.Model;
using AutoMapper;

namespace API_LIVROS.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
             CreateMap<Livro, LivroModel>().ReverseMap();
        }
    }
}