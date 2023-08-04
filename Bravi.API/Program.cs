using Bravi.API.Configuration;
using Bravi.Domain;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddCors(c =>
            c.AddPolicy("*", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));


        builder.Services.AddControllers();
        builder.Services.ConfigureDomain();

        builder.AddMediatRConfiguration();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddMvc();
        builder.Services.AddMvc().AddFluentValidation();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("pt-BR"),
            SupportedCultures = new[]{
                CultureInfo.CreateSpecificCulture("pt-BR")
            },
            FallBackToParentCultures = false
        });

        app.UseCors(x => x
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}