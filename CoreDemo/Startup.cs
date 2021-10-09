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
            //Http hata sayfalar�ndan sayfa bulunamad� 404 hatas� i�in kendimiz bu durumda kullan�c�n�n kar��s�na ��kacak sayfay� belirleyelim.
            //app.UseStatusCodePages();//Durum kodlar� sayfas� kullan anlam�na gelir.
            //Ama 404 hatas� durumunda ben kullan�c�y� bir web sayfas�na y�nlendirmek istedi�im i�in �u metodu kullan�r�m
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1","?code={0}");//Bu iki parametre al�r. Biri path parametresi yani hata durumunda
            //hangi sayfaya y�nlendirece�idir. �kinci parametre ise bir query al�r. Hata kodu i�in bir kod de�eri yazar�z.


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
