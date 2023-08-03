﻿using Bravi.Domain.Resources.Notification;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace Bravi.API.Configuration;

public static class MediatRConfiguration
{
    public static WebApplicationBuilder AddMediatRConfiguration(this WebApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));

        builder.Services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(Domain.Bootstrapper).Assembly);

        // Add FluentValidation classes into 
        var assembly = typeof(Domain.Bootstrapper).Assembly;
        AssemblyScanner
         .FindValidatorsInAssembly(assembly)
         .ForEach(result =>
         {
             builder.Services.AddScoped(result.InterfaceType, result.ValidatorType);
         });

        // Domain - Commands
        builder.Services.AddScoped<IDomainNotificationContext, DomainNotificationContext>();

        return builder;
    }
}
