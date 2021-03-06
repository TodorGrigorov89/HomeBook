﻿namespace HomeBook.Web
{
    using System.Reflection;

    using HomeBook.Data;
    using HomeBook.Data.Common;
    using HomeBook.Data.Common.Repositories;
    using HomeBook.Data.Models;
    using HomeBook.Data.Repositories;
    using HomeBook.Data.Seeding;
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
    using HomeBook.Services.Messaging;
    using HomeBook.Web.ViewModels;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews(
                options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    }).AddRazorRuntimeCompilation();
            services.AddRazorPages();

            services.AddSingleton(this.configuration);
            services.AddApplicationInsightsTelemetry();

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
