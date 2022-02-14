using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository.StaffRepo;
using ClinicManagementSystem.Repository.DoctorsNotes;
//using ClinicManagementSystem.Repository.MedicinesRepo;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Repository;
using ClinicManagementSystem.Repository.Appointments;
using ClinicManagementSystem.Repository.Bills;
using ClinicManagementSystem.Repository.Patients;
using ClinicManagementSystem.Repository.LabTests;
using Microsoft.OpenApi.Models;

namespace ClinicManagementSystem
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
            //add services
            services.AddControllers();

            //swagger documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DemoExperionFirstWebAPI", Version = "v1" });
            });

            //connection string for db
            services.AddDbContext<ClinicManagementSystemDBContext>(db => db.UseSqlServer(Configuration.GetConnectionString("CMSConnection")));


            //add public dependency injection
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IQualificationsRepository, QualificationsRepository>();
            services.AddScoped<IMedicineAdviceRepository, MedicineAdviceRepository>();
            services.AddScoped<IMedicinesRepository, MedicinesRepository>();
            services.AddScoped<IAppointment, AppointmentClass>();
            services.AddScoped<IBill, BillClass>();
            services.AddScoped<IMedicinesBill, MedicinesBillClass>();
            services.AddScoped<IConsultancyBill, ConsultancyBillClass>();
            services.AddScoped<ITestsBill, TestsBillClass>();
            services.AddScoped<IPatientsRepository, PatientsRepository>();



            services.AddScoped<ILabTestsRepository, LabTestsRepository>();



            services.AddScoped<ITestAdviceRepository, TestAdviceRepository>();





            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options => {
            //        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            //        {

            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidateLifetime = true,
            //            ValidIssuer = Configuration["Jwt:Issuer"],
            //            ValidAudience = Configuration["Jwt:Issuer"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            //        };
            //    });

            //adding services
            services.AddControllers().AddNewtonsoftJson(
                options => {
                    options.SerializerSettings
                    .ContractResolver = new DefaultContractResolver();
                }
                );

            services.AddControllers().AddNewtonsoftJson(
                options => {
                    options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
            services.AddCors();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/swagger.json", "cmsAPP v1"));
            }

         
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
