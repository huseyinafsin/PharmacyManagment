using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;


namespace PharmacyManagmentV2
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
            services.AddMvc();
            services.AddControllersWithViews();
            string connectionString = Configuration.GetConnectionString("default");
            services.AddDbContext<AppDBContext>(c => c.UseSqlServer(connectionString));
          
            services.AddIdentity<ApplicationUser, ApplicationRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDBContext>();


            services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
            opt =>
            {
                opt.Cookie.Name = "CookieSettings";
                opt.LoginPath = new PathString("/User/Login");
                opt.AccessDeniedPath = new PathString("/Admin/AccessDenied");
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            });

            //services.AddScoped<IAddressDal, IAddressDal>();
            //services.AddScoped<ICategoryDal, ICategoryDal>();
            //services.AddScoped<ICustomerDal, EFCustomerRepository>();
            //services.AddScoped<ILeafDal, EFLeafRepository>();
            //services.AddScoped<IManufacturerDal, IManufacturerDal>();
            //services.AddScoped<IMedicineDal, EFMedicineRepository>();
            //services.AddScoped<ITypeDal, EFTypeRepository>();
            //services.AddScoped<IPurchaseDal, EFPurchaseRepository>();
            //services.AddScoped<IInvoiceDal, EFInvoiceRepository>();
            //services.AddScoped<IPharmacyDal, EFPharmacyRepository>();
            //services.AddScoped<IBankAccountDal, EFBankAccountRepository>();
            //services.AddScoped(typeof(IGenericDal<>),typeof(GenericRepository <>));

            //services.AddScoped<IAddressService, AddressManager>();
            //services.AddScoped<ICategoryService, ICategoryService>();
            //services.AddScoped<ICustomerService, CustomerManager>();
            //services.AddScoped<ILeafService, LeafManager>();
            //services.AddScoped<IManufacturerService, ManufacturerManager>();
            //services.AddScoped<IMedicineService, MedicineManager>();
            //services.AddScoped<ITypeService, TypeManager>();
            //services.AddScoped<IPurchaseService, PurchaseManager>();
            //services.AddScoped<IInvoiceService, InvoiceManager>();
            //services.AddScoped<IPharmacyService, PharmcyManager>();
            //services.AddScoped<IBankAccountService, BankAccountManager>();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"Pharmacy",
                    pattern: "{controller=Pharmacy}/{action=SetBankAccount}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                
            });

            

        }
    }
}
