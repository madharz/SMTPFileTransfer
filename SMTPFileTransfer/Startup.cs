using SMTPFileTransfer.Models;
using SMTPFileTransfer.Services;

namespace SMTPFileTransfer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Цей метод викликається під час реєстрації сервісів у контейнері залежностей.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            services.Configure<EmailConfiguration>(configuration.GetSection("EmailConfiguration"));
            

            services.AddTransient<IFormDataProcessingService, FormDataProcessingService>();
            services.AddTransient<IFileUploadService, FileUploadService>();
            services.AddTransient<IEmailService, EmailService>();

        }

        // Цей метод викликається під час налаштування HTTP-конвеєра.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
