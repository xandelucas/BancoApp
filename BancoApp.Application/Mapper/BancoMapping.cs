using AutoMapper;
using BancoApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Application.Mapper
{
    public class BancoMapping : Profile
    {
        public BancoMapping() 
        {
            CreateMap<BancoApp.Domain.Banco, BancoDTO>().ReverseMap(); 
        }
    }
}
