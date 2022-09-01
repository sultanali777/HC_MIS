using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(HC_MIS.Areas.Identity.IdentityHostingStartup))]

namespace HC_MIS.Areas.Identity
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