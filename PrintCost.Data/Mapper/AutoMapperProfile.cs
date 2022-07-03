using AutoMapper;
using PrintCost.Context;
using PrintCost.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Data.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Price, PcPrice>()
                .ForMember(a => a.PcJobTypeId, y => y.MapFrom(z => z.JobTypeId))
                .ForMember(a => a.PcPaperSizeId, y => y.MapFrom(z => z.PaperSizeId))
                .ReverseMap();
        }
    }
}
