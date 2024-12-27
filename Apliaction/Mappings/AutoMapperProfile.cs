using Aplication.Features.Products.Commands;
using AutoMapper;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mappings
{
	public class AutoMapperProfile : Profile 
	{
		public AutoMapperProfile() {
			CreateMap<CreateProductCommand, Product>();
			// cấu hình thuộc tính lại khi 2 model khác nhau 
			// .Formenber(i=> i.Description, source => source.MapFrom(src => src.Desc));
		}
	}
}
