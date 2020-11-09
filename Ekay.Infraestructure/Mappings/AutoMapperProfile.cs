using AutoMapper;
using Ekay.Domain.DTOs;
using Ekay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSpawn.Application.Mappings
{

	class AutoMapperProfile : Profile
	{

		public AutoMapperProfile()
		{
			CreateMap<Documento, DocumentoRequestDto>();
			CreateMap<Documento, DocumentoResponseDto>();
			CreateMap<DocumentoRequestDto, Documento>().AfterMap(
			((source, destination) => {
				destination.CreateAt = DateTime.Now;
				destination.CreatedBy = 3;
				//destination.Status = true;
			}));
			CreateMap<DocumentoResponseDto, Documento>();



			CreateMap<Empresa, EmpresaRequestDto>();
			CreateMap<Empresa, EmpresaResponseDto>();
			CreateMap<EmpresaRequestDto, Empresa>().AfterMap(
			((source, destination) => {
				destination.CreateAt = DateTime.Now;
				destination.CreatedBy = 3;
				//destination.Status = true;
			}));
			CreateMap<EmpresaResponseDto, Empresa>();





		}


	}
}
