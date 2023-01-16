using MediatR;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using ContactHub.Domain.Repositories;
using ContactHub.Persistence.Repositories;
using ContactHub.Persistence;

namespace ContactHub.Web.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ContactHubContext>(o => o.UseSqlServer(configuration.GetConnectionString("ContactHubContext")));
            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Application.AssemblyReference.Assembly);
            return services;
        }

        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddControllersWithViews();
            services.AddBlazorise(options =>
                {
                    options.Immediate = true;
                })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            return services;
        }
    }
}
