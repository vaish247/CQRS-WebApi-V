using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using CQRS_WebApi_V1.Application.Handlers;
using CQRS_WebApi_V1.Application.Mapping;
using CQRS_WebApi_V1.Domain.Interfaces;
using CQRS_WebApi_V1.Repository.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS_WebApi_V1.Application
{
    public static class ServiceInjection
    {
        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            // Register DynamoDB client and context
            services.AddSingleton<IAmazonDynamoDB>(sp =>
            {
                return new AmazonDynamoDBClient();
            });

            services.AddSingleton<IDynamoDBContext>(sp =>
            {
                var client = sp.GetRequiredService<IAmazonDynamoDB>();
                return new DynamoDBContext(client);
            });

            // Register repositories
            services.AddSingleton<IContactItemRepository, ContactItemRepository>();

            // Register MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddContactItemHandler).Assembly));

            // Register AutoMapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
