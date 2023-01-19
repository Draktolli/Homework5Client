using Homework5.DB;
using Homework5Client.DTO;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework5Client.Commands;
using Homework5Client.Validator;

namespace Homework5Client
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

			services.AddControllers();
			services.AddTransient<IUpdateDirectorRequestValidator, UpdateDirectorRequestValidator>();
			services.AddTransient<IGetDirectorRequestValidator, GetDirectorRequestValidator>();
			services.AddTransient<IDeleteDirectorRequestValidator, DeleteDirectorRequestValidator>();
			services.AddTransient<ICreateDirectorRequestValidator, CreateDirectorRequestValidator>();
			services.AddTransient<IUpdateDirectorCommand, UpdateDirectorCommand>();
			services.AddTransient<ICreateDirectorCommand, CreateDirectorCommand>();
			services.AddTransient<IDeleteDirectorCommand, DeleteDirectorCommand>();
			services.AddTransient<IGetDirectorCommand, GetDirectorCommand>();

			services.AddMassTransit(mt =>
			{
				mt.UsingRabbitMq((context, config) =>
				{
					config.Host("localhost", "/", host =>
					{
						host.Username("guest");
						host.Password("guest");
					});
				});
				mt.AddRequestClient<PostDirectorRequest>(new Uri("rabbitmq://localhost/post"));
				mt.AddRequestClient<GetDirectorRequest>(new Uri("rabbitmq://localhost/get"));
				mt.AddRequestClient<DeleteDirectorRequest>(new Uri("rabbitmq://localhost/delete"));
				mt.AddRequestClient<UpdateDirectorRequest>(new Uri("rabbitmq://localhost/update"));
			});
			services.AddMassTransitHostedService();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
