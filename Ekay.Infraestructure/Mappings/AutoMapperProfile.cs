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
			CreateMap<DocumentoRequestDto, Autor>();
			CreateMap<DocumentoRequestDto, Remitente>();
			CreateMap<DocumentoRequestDto, Documento>();
			CreateMap<Documento, DocumentoResponseDto>();

			CreateMap<DocumentoRequestDto, Documento>()
			 .ForMember(destination => destination.Autor, act => act.MapFrom(source => source))
			  .ForMember(destination => destination.Remitente, act => act.MapFrom(source => source))
			 .AfterMap(
			 ((source, destination) => {
				 destination.CreateAt = DateTime.Now;
				 destination.CreatedBy = 3;
				 // destination.Status = true;
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


			CreateMap<Autor, AutorRequestDto>();
			CreateMap<Autor, AutorResponseDto>();
			CreateMap<AutorRequestDto, Autor>().AfterMap(
			((source, destination) => {
				destination.CreateAt = DateTime.Now;
				destination.CreatedBy = 3;
				//destination.Status = true;
			}));
			CreateMap<AutorResponseDto, Autor>();

			CreateMap<Carpeta, CarpertaRequestDto>();
			CreateMap<Carpeta, CarpetaResponseDto>();
			CreateMap<CarpertaRequestDto, Carpeta>().AfterMap(
			((source, destination) => {
				destination.CreateAt = DateTime.Now;
				destination.CreatedBy = 3;
				//destination.Status = true;
			}));
			CreateMap<CarpetaResponseDto, Carpeta>();

			CreateMap<Firmante, FirmanteRequestDto>();
			CreateMap<Firmante, FirmanteResponseDto>();
			CreateMap<FirmanteRequestDto, Firmante>().AfterMap(
			((source, destination) => {
				destination.CreateAt = DateTime.Now;
				destination.CreatedBy = 3;
				//destination.Status = true;
			}));
			CreateMap<FirmanteResponseDto, Firmante>();

			CreateMap<Remitente, RemitenteRequestDto>();
			CreateMap<Remitente, RemitenteResponseDto>();
			CreateMap<RemitenteRequestDto, Remitente>().AfterMap(
			((source, destination) => {
				destination.CreateAt = DateTime.Now;
				destination.CreatedBy = 3;
				
			}));
			CreateMap<RemitenteResponseDto, Remitente>();


			/*CreateMap<CuentaRequestDto, Empresa>();
			//.ForMember(destination => destination.Tag, act => act.MapFrom(source => source.Empresa));
			CreateMap<Cuenta, CuentaRequestDto>().ForMember(destination => destination.Empresa, act => act.MapFrom(source => source));
			CreateMap<Cuenta, CuentaResponseDto>();
			CreateMap<CuentaRequestDto, Cuenta>().AfterMap(
			((source, destination) => {
				destination.CreateAt = DateTime.Now;
				destination.CreatedBy = 3;
				
			}));*/

			//CreateMap<CuentaResponseDto, Cuenta>();

			/*CreateMap<CuentaRequestDto, Cuenta>() .ForMember(destination => destination.Empresa, act => act.MapFrom(source => source))
				.AfterMap(
			 ((source, destination) => {
				 destination.CreateAt = DateTime.Now;
				 destination.CreatedBy = 3;
				
			 }));
			CreateMap<CuentaResponseDto, Cuenta>();*/





			CreateMap<CuentaRequestDto, Empresa>();
			//ForMember(destination => destination.Nombre, act => act.MapFrom(source =>source.Empresa));
			CreateMap<CuentaRequestDto, Cuenta>();
			CreateMap<Cuenta, CuentaResponseDto>();
			
			CreateMap<CuentaRequestDto, Cuenta>()
			 .ForMember(destination => destination.Empresa, act => act.MapFrom(source => source))
			 .AfterMap(
			 ((source, destination) => {
				 destination.CreateAt = DateTime.Now;
				 destination.CreatedBy = 3;
				// destination.Status = true;
			 }));
			CreateMap<CuentaResponseDto, Cuenta>();


		}


	}
}
