namespace HomeBook.Services.Data.Tests.ServicesTests
{
    using System;
    using System.IO;
    using System.Reflection;

    using HomeBook.Data;
    using HomeBook.Data.Common;
    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Data.Repositories;
    using HomeBook.Services.Data.Apartments;
    using HomeBook.Services.Data.BlogPosts;
    using HomeBook.Services.Data.Buildings;
    using HomeBook.Services.Data.Cities;
    using HomeBook.Services.Data.Countries;
    using HomeBook.Services.Data.Documents;
    using HomeBook.Services.Data.Entrances;
    using HomeBook.Services.Data.Payments;
    using HomeBook.Services.Data.Streets;
    using HomeBook.Services.Data.Users;
    using HomeBook.Services.Data.UsersApartments;
    using HomeBook.Services.Data.UsersDocuments;
    using HomeBook.Services.Mapping;
    using HomeBook.Web.ViewModels.Cities;
    using HomeBook.Web.ViewModels.Countries;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public abstract class BaseServiceTests : IDisposable
    {
        protected BaseServiceTests()
        {
            this.Configuration = this.SetConfiguration();
            var services = this.SetServices();
            this.RegisterMappings();
            this.ServiceProvider = services.BuildServiceProvider();
            this.DbContext = this.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            this.Seed();
        }

        protected IServiceProvider ServiceProvider { get; set; }

        protected ApplicationDbContext DbContext { get; set; }

        protected IConfigurationRoot Configuration { get; set; }

        public void Dispose()
        {
            this.DbContext.Database.EnsureDeleted();
            this.SetServices();
        }

        private ServiceCollection SetServices()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            services
                 .AddIdentity<ApplicationUser, ApplicationRole>(options =>
                 {
                     options.Password.RequireDigit = false;
                     options.Password.RequireLowercase = false;
                     options.Password.RequireUppercase = false;
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequiredLength = 6;
                 })
                 .AddEntityFrameworkStores<ApplicationDbContext>();

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddSingleton<IConfiguration>(this.Configuration);

            // Application services
            services.AddTransient<IApartmentsService, ApartmentsService>();
            services.AddTransient<IBuildingsService, BuildingsService>();
            services.AddTransient<ICitiesService, CitiesService>();
            services.AddTransient<ICountriesService, CountriesService>();
            services.AddTransient<IDocumentsService, DocumentsService>();
            services.AddTransient<IEntrancesService, EntrancesService>();
            services.AddTransient<IPaymentsService, PaymentsService>();
            services.AddTransient<IStreetsService, StreetsService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IUsersApartmentsService, UsersApartmentsService>();
            services.AddTransient<IUsersDocumentsService, UsersDocumentsService>();
            services.AddTransient<IBlogPostsService, BlogPostsService>();

            return services;
        }

        private void RegisterMappings()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(CountryViewModel).GetTypeInfo().Assembly,
                typeof(CityViewModel).GetTypeInfo().Assembly);
        }

        private IConfigurationRoot SetConfiguration()
        {
            return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(
                 path: "appsettings.json",
                 optional: false,
                 reloadOnChange: true)
           .Build();
        }

        private void Seed()
        {
            var country = new Country
            {
                Name = "testCountry",
            };

            this.DbContext.Countries.Add(country);

            var city = new City
            {
                CountryId = 1,
                Name = "testCity",
                IsDeleted = false,
            };

            this.DbContext.Cities.Add(city);

            var street = new Street
            {
                Name = "testStreet",
                CityId = 1,
            };

            this.DbContext.Streets.Add(street);

            var building = new Building
            {
                BuildingFullAddress = "Struga 31, 33",
                NumberOfEntrances = 2,
                NumberOfFloors = 10,
                NumberOfApartments = 20,
                StreetId = 1,
            };

            this.DbContext.Buildings.Add(building);

            var entrance = new Entrance
            {
                EntranceAddressSign = "10A",
                BuildingId = 1,
            };

            this.DbContext.Entrances.Add(entrance);

            var apartment = new Apartment
            {
                ApartmentNumber = "60",
                Floor = 7,
                NumberOfResidents = 3,
                Area = 80.25,
                EntranceId = 1,
            };

            this.DbContext.Apartments.Add(apartment);

            var payment = new Payment
            {
                ElevatorSubscription = 5.20M,
                ElevatorElectricity = 4.32M,
                StairElectricity = 1.11M,
                CleaningService = 2.21M,
                RunningCosts = 1.14M,
                RepairAndRestorationFund = 3.00M,
                HouseManagerFee = 1.28M,
                ApartmentId = 1,
            };

            this.DbContext.Payments.Add(payment);

            var document = new Document
            {
                DocumentType = HomeBook.Data.Models.Enums.DocumentType.Protocol,
                Description = "Test Document Test Document Test Document Test Document",
            };

            this.DbContext.Documents.Add(document);
        }
    }
}
