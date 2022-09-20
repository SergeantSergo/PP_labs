using Matveev_pp.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using NLog;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        //services.ConfigureCors();
        //services.ConfigureIISIntegration();
        //services.ConfigureLoggerService();
        services.ConfigureCors();
        services.ConfigureIISIntegration();
        services.AddControllers();


        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHsts();
        app.UseStaticFiles();
        app.UseCors("CorsPolicy");
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.All
        });

        app.UseRouting();
        //app.UseAuthentication();
        app.UseAuthorization();
        //
        app.UseHttpsRedirection();
        //app.UseStaticFiles();
        
        
        app.UseEndpoints(endpoints => 
        { 
            endpoints.MapControllers(); 
        });
    }

}

