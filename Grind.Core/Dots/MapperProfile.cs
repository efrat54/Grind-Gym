using AutoMapper;
using Grind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Core.Dots
{
    public class MapperProfile:Profile
    {
        public MapperProfile() { 
            CreateMap<Trainer,TrainerDTO>().ReverseMap();
            CreateMap<Client,ClientDTO>().ReverseMap();
        }
    }
}
