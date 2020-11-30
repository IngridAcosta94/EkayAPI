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
				//destination.Status = true;
			}));
			CreateMap<CuentaResponseDto, Cuenta>();

			CreateMap<Cuenta, CuentaRequestDto>();
			CreateMap<Cuenta, CuentaResponseDto>();
			CreateMap<CuentaRequestDto, Cuenta>().AfterMap(
			((source, destination) => {
				destination.CreateAt = DateTime.Now;
				destination.CreatedBy = 3;
				//destination.Status = true;
			}));
			CreateMap<CuentaResponseDto, Cuenta>();

		}


	}
}
