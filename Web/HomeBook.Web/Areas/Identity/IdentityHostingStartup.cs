using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(HomeBook.Web.Areas.Identity.IdentityHostingStartup))]

namespace HomeBook.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
