using MB.Business.AutoMapper;
using MB.Business.Extensions;
using MB.DataAccess.Concrete.EntityFramework.Context;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;
using Serilog.Events;
using FluentValidation.AspNetCore;
using FluentValidation;
using MB.Business.Concrete.DTOs;
using MB.Business.Helpers.Validators.AppUserValidators;
using MB.Business.Concrete.DTOs.AppUserDtos;
using MB.Business.Concrete.DTOs.RoleDtos;
using MB.Business.Helpers.Validators.AppRoleValdators;
using MB.Business.Concrete.DTOs.CategoryDtos;
using MB.Business.Helpers.Validators.CategoryValidators;
using MB.Business.Concrete.DTOs.ProductDtos;
using MB.Business.Helpers.Validators.ProductValidators;
using MB.Business.Helpers.Validators.LoginValidators;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.File(
        System.IO.Path.Combine("C:\\Users\\Ruslan-PC\\source\\repos\\MB\\MB.Business\\Logs\\", "Application", "diagnostic.txt"),
        rollingInterval: RollingInterval.Day,
        fileSizeLimitBytes: 10 * 1024 * 1024,
        retainedFileCountLimit:30,
        rollOnFileSizeLimit:true,
        shared:true,
        flushToDiskInterval:TimeSpan.FromSeconds(1))
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);



builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.ImplicitlyValidateChildProperties = true;
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
builder.Services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateValidator>();
builder.Services.AddTransient<IValidator<RoleAddDto>, AppRoleAddValidator>();
builder.Services.AddTransient<IValidator<RoleUpdateDto>, AppRoleUpdateValidator>();
builder.Services.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();
builder.Services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();
builder.Services.AddTransient<IValidator<ProductAddDto>, ProductAddValidator>();
builder.Services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateValidator>();
builder.Services.AddTransient<IValidator<LoginDto>, LoginValidator>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigninKey"]))
        };
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MBDbContext>();
//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.ServiceCollectionMethod();
builder.Services.AddAutoMapper(typeof(ProgramProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
