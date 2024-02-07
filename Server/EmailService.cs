using System.Net.Mail;

using Portfolio.Server;
using MailKit;
using System.ComponentModel;


namespace Portfolio.Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddCors(options =>
            // {
            //     options.AddPolicy("AllowSpecificOrigin",
            //         builder => builder.WithOrigins("http://localhost:5058") // Replace with your Blazor app's origin
            //                           .AllowAnyMethod()
            //                           .AllowAnyHeader()
            //                         //   .SetIsOriginAllowed(origin => true)
            //                           .AllowCredentials());
            // });

            // other service configurations
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // other configurations

            app.UseCors("AllowSpecificOrigin");

            // other configurations
        }

    }
}