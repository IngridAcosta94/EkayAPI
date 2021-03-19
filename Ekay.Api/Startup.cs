using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ekay.Application.Services;
using Ekay.Domain.Interfaces;
using Ekay.Infraestructure.Data;
using Ekay.Infraestructure.Filters;
using Ekay.Infraestructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Ekay.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors();

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddControllers();
			services.AddDbContext<EkayContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("EkayEF")));
			services.AddTransient<IDocumentoRepository, DocumentoRepository>();
			services.AddTransient<IDocumentoService, DocumentoService>();
			services.AddTransient<IEmpresaService, EmpresaService>();
			services.AddTransient<ICuentaService, CuentaService>();
			services.AddTransient<IRemitenteService, RemitenteService>();
			services.AddTransient<IAutorService, AutorService>();
			services.AddTransient<ICarpetaService, CarpetaService>();
			services.AddTransient<IFirmanteService, FirmanteService>();
			services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>));
			services.AddTransient<IUnitOfWork, UnitOfWork>();
			services.AddControllers(options =>options.Filters.Add<GlobalExceptionFilter>());

			services.AddMvc().AddFluentValidation(options =>
				options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseCors(options =>
			{
				options.WithOrigins("https://localhost:44348"); 
				options.AllowAnyMethod();
				options.AllowAnyHeader();
			});


			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
