using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesDatePrediction.Core;
using SalesDatePrediction.Core.Adapters;
using SalesDatePrediction.Core.Ports;
using SalesDatePrediction.Core.UseCases.Employees;
using SalesDatePrediction.Core.UseCases.Production;
using SalesDatePrediction.Core.UseCases.Sales;
using SalesDatePrediction.Domain.Repositories;
using SalesDatePrediction.Infrastructure.Database;
using SalesDatePrediction.Infrastructure.Database.Repositories;

namespace SalesDatePrediction.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensionsExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SalesDatesPredictionContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("StringConnection"),
                    sqlServerOptionsAction =>
                    {
                        sqlServerOptionsAction.MigrationsHistoryTable("__MicroMigrationHistory", configuration.GetConnectionString("SchemaName"));
                    });

                options.ConfigureWarnings(warnings =>
                {
                    warnings.Default(WarningBehavior.Log);
                });
            });

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IShipperRepository, ShipperRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();

            return services;
        }

        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<GetCustomerOrdersUseCase>();
            services.AddScoped<GetEmployeesUseCase>();
            services.AddScoped<GetShippersUseCase>();
            services.AddScoped<GetProductsUseCase>();
            services.AddScoped<GetCustomerByIdUseCase>();
            services.AddScoped<GetEmployeeByIdUseCase>();
            services.AddScoped<GetShipperByIdUseCase>();
            services.AddScoped<GetProductByIdUseCase>();
            services.AddScoped<CreateOrderUseCase>();
            services.AddScoped<CreateOrderDetailUseCase>();
            services.AddScoped<GetNextPredictedOrderDatesUseCase>();
            services.AddScoped<GetCustomersWithOrdersUseCase>();
            services.AddTransient<IOrderFacade, OrderFacade>();
            services.AddTransient<IEmployeeFacade, EmployeeFacade>();
            services.AddTransient<IShipperFacade, ShipperFacade>();
            services.AddTransient<IProductFacade, ProductFacade>();
            services.AddTransient<ICustomerFacade, CustomerFacade>();

            return services;
        }

        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile(new CoreMappingProfile());
            });

            services.AddSingleton(componentContext => mapperConfiguration.CreateMapper());
            return services;
        }
    }
}
