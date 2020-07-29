using Compositions.Backend.Application.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StockTracker.Api.Extensions;
using StockTracker.Api.Services;
using StockTracker.Infra.HttpConsumer.Messaging;
using StockTracker.Infra.Messaging.HubConfig;
using StockTracker.Infra.Messaging.Services;
using System;

namespace StockTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                );
            });

            services.ConfigureHttpConsumerServices(Configuration);
            services.ConfigureDALLayer(Configuration);
            services.ConfigureApiServices();
            services.ConfigureSwaggerGen();

            services.AddScoped<ISubscriberService, SubscriberService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddSignalR();

            if (Environment.GetEnvironmentVariable("MESSAGING") == "SIGNALR")
            {
                services.AddScoped<INewsHubServices, NewsHubServicesSignalR>();
            } 
            else if (Environment.GetEnvironmentVariable("MESSAGING") == "TELEGRAM")
            {
                services.AddScoped<IMessageService, TelegramService>();
                services.AddScoped<INewsHubServices, NewsHubServicesTelegram>();
            }

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddControllers();
        }

        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env,
            INewsHubServices newsService
        ){
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection()
                .UseRouting()
                .UseCors("CorsPolicy")
                .UseAuthorization()
                .ConfigureCustomExceptionMiddleware()
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stock Tracker API");
                });

            if (Environment.GetEnvironmentVariable("MESSAGING") == "SIGNALR")
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapHub<NewsHub>("/initialize-hub");
                });
            }
        }
    }
}
