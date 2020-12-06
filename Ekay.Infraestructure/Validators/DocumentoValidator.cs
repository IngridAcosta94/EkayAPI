using Ekay.Domain.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Infraestructure.Validators
{
	class DocumentoValidator : AbstractValidator<DocumentoRequestDto>
	{
		public DocumentoValidator()
		{
			// pendiente validar algunas cosas
			//RuleFor(documento => documento.Titulo).NotNull().Length(10, 50);
			RuleFor(documento => documento.FechaCreacion).LessThan(DateTime.Now);
			//RuleFor(animal => animal.Contenido).NotNull().Length(4, 200);


		}


	}
}
