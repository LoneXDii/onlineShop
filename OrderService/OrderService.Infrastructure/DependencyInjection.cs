﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using OrderService.Infrastructure.Configuration;
using OrderService.Infrastructure.Services;
using OrderService.Domain.Abstractions.Data;
using OrderService.Domain.Abstractions.Payments;
using Stripe;
using OrderService.Infrastructure.Repositories;
using OrderService.Infrastructure.Mapping;
using AutoMapper.Extensions.ExpressionMapping;
using OrderService.Infrastructure.Protos;
using OrderService.Infrastructure.Interceptors;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using OrderService.Infrastructure.Models;


namespace OrderService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDBSettings>(options => configuration.GetSection("MongoDB").Bind(options))
            .Configure<StripeSettings>(options => configuration.GetSection("Stripe").Bind(options));

        services.AddScoped<CustomerService>()
            .AddScoped<Stripe.ProductService>()
            .AddScoped<PriceService>();

        services.AddSingleton<IOrderRepository, OrderRepository>()
            .AddScoped<IProductService, GrpcProductService>()
            .AddScoped<IPaymentService, PaymentService>()
            .AddScoped<ITemporaryStorageService, RedisStorageService>();

        services.AddSingleton(serviceProvider =>
        {
            var settings = serviceProvider.GetRequiredService<IOptions<MongoDBSettings>>().Value;
            var client = new MongoClient(settings.ConnectionURI);
            var database = client.GetDatabase(settings.DatabaseName);

            return database.GetCollection<Order>(settings.CollectionName);
        });

        services.AddStackExchangeRedisCache(opt =>
        {
            opt.Configuration = configuration["Redis:Configuration"];
            opt.InstanceName = configuration["Redis:InstanceName"];
        });

        services.AddAutoMapper(cfg =>
        {
            cfg.AddExpressionMapping();
        },typeof(OrderMappingProfile));

        services.AddScoped<AuthInterceptor>()
            .AddGrpcClient<Products.ProductsClient>(opt =>
            {
                opt.Address = new Uri(configuration["gRPC:ServerUrl"]);
            })
            .AddInterceptor<AuthInterceptor>();

        return services;
    }
}