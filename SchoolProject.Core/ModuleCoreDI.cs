using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behaviours;
using System.Globalization;
using System.Reflection;

namespace SchoolProject.Core
{
    public static class ModuleCoreDI
    {
        public static IServiceCollection AddCoreDIS(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehaviour<,>));

            services.AddLocalization(opt => { opt.ResourcesPath = ""; });
            services.Configure<RequestLocalizationOptions>(opt =>
            {
                var cultures = new List<CultureInfo>()
                {
                    new CultureInfo("ar-EG"),
                    new CultureInfo("en-US")
                };

                opt.SupportedCultures = cultures;
                opt.SupportedUICultures = cultures;

                opt.RequestCultureProviders = new List<IRequestCultureProvider>()
        {
            new QueryStringRequestCultureProvider(),
            new CookieRequestCultureProvider(),
            new AcceptLanguageHeaderRequestCultureProvider()
        };
            });
            return services;
        }
    }
}
