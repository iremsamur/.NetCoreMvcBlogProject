using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
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
            services.AddSession(); //Bu session y�ntemi ile login i�in gerekliydi.

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));//Bu metod ile projemi proje seviyesinde authorize i�lemi kullanabilece�im
            });
            //Authorize ile Return Login Url yap�m�

            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index";//return yap�lacak url'in yolunu yaz�yoruz. Logine Index'le birlikte gitsin dedik

                }
                );

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
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");//Bu iki parametre al�r. Biri path parametresi yani hata durumunda
            //hangi sayfaya y�nlendirece�idir. �kinci parametre ise bir query al�r. Hata kodu i�in bir kod de�eri yazar�z.


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //cookie ile login i�in �unu da eklemeliyiz.
            app.UseAuthentication();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Areas i�in ekliyorum
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Blog}/{action=Index}/{id?}");
            });
        }
    }
}
