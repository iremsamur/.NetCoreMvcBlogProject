using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //Http hata sayfalarýndan sayfa bulunamadý 404 hatasý için kendimiz bu durumda kullanýcýnýn karþýsýna çýkacak sayfayý belirleyelim.
            //app.UseStatusCodePages();//Durum kodlarý sayfasý kullan anlamýna gelir.
            //Ama 404 hatasý durumunda ben kullanýcýyý bir web sayfasýna yönlendirmek istediðim için þu metodu kullanýrým
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1","?code={0}");//Bu iki parametre alýr. Biri path parametresi yani hata durumunda
            //hangi sayfaya yönlendireceðidir. Ýkinci parametre ise bir query alýr. Hata kodu için bir kod deðeri yazarýz.


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Blog}/{action=Index}/{id?}");
            });
        }
    }
}
