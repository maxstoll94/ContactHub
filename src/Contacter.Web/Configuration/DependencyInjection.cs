using Contacter.Domain.Repositories;
using Contacter.Persistence;
using Contacter.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

namespace Contacter.Web.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ContacterContext>(o => o.UseSqlServer(configuration.GetConnectionString("Database")));
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
            services.AddServerSideBlazor().AddMicrosoftIdentityConsentHandler();

            services.AddControllersWithViews().AddMicrosoftIdentityUI();
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
