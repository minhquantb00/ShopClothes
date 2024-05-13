
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ShopClothes.Application.Handle.HandleEmail;
using ShopClothes.Application.ImplementService;
using ShopClothes.Application.InterfaceService;
using ShopClothes.Application.UseCases;
using ShopClothes.Application.UseCases.Implements.Product_UseCase.AdminProduct_UseCase.CreateProduct;
using ShopClothes.Application.UseCases.Implements.User_UseCase.AuthenticateUser;
using ShopClothes.Application.UseCases.Implements.User_UseCase.ChangePasswordUser;
using ShopClothes.Application.UseCases.Implements.User_UseCase.ConfirmCreateNewPasswordUser;
using ShopClothes.Application.UseCases.Implements.User_UseCase.ForgotPasswordUser;
using ShopClothes.Application.UseCases.Implements.User_UseCase.GetUser;
using ShopClothes.Application.UseCases.Implements.User_UseCase.GetUserById;
using ShopClothes.Application.UseCases.Implements.User_UseCase.LoginUser;
using ShopClothes.Application.UseCases.Implements.User_UseCase.RegisterUser;
using ShopClothes.Domain.Entities;
using ShopClothes.Domain.InterfaceRepositories;
using ShopClothes.Infrastructure.DataContexts;
using ShopClothes.Infrastructure.ImplementRepositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


#region Register IUseCase
builder.Services.AddScoped<IUseCase<RegisterUserUseCaseInput, RegisterUserUseCaseOutput>, RegisterUserUseCase>();
builder.Services.AddScoped<IUseCase<LoginUserUseCaseInput, LoginUserUseCaseOutput>, LoginUserUseCase>();
builder.Services.AddScoped<IUseCase<AuthenticateUserUseCaseInput, AuthenticateUserUseCaseOutput>, AuthenticateUserUseCase>();
builder.Services.AddScoped<IUseCase<ChangePasswordUserUseCaseInput, ChangePasswordUserUseCaseOutput>, ChangePasswordUserUseCase>();
builder.Services.AddScoped<IUseCase<ForgotPasswordUserUseCaseInput, ForgotPasswordUserUseCaseOuput>, ForgotPasswordUserUseCase>();
builder.Services.AddScoped<IUseCase<ConfirmCreateNewPasswordUserUseCaseInput, ConfirmCreateNewPasswordUserUseCaseOutput>, ConfirmCreateNewPasswordUserUseCase>();
builder.Services.AddScoped<IUseCase<GetUserUseCaseInput, GetUserUseCaseOutput>, GetUserUseCase>();
builder.Services.AddScoped<IUseCaseGetById<int, GetUserByIdUseCaseOutput>, GetUserByIdUseCase>();
builder.Services.AddScoped<IUseCase<CreateProductUseCaseInput, CreateProductUseCaseOutput>, CreateProductUseCase>();
#endregion

#region Register Repository
builder.Services.AddScoped<IDbContext, AppDbContext>();
builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddScoped<IRepository<UserRole>, Repository<UserRole>>();
builder.Services.AddScoped<IRepository<Role>, Repository<Role>>();
builder.Services.AddScoped<IRepository<RefreshToken>, Repository<RefreshToken>>();
builder.Services.AddScoped<IRepository<ConfirmEmail>, Repository<ConfirmEmail>>();
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
builder.Services.AddScoped<IRepository<ProductType>, Repository<ProductType>>();
builder.Services.AddScoped<IRepository<ProductDetail>, Repository<ProductDetail>>();
builder.Services.AddScoped<IRepository<ProductImage>, Repository<ProductImage>>();

#endregion

#region Đăng ký service
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IEmailService, EmailService>();
#endregion

#region Register Mapper
builder.Services.AddScoped<GetUserUseCaseMapping>();
#endregion
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder
            .WithOrigins("http://localhost:8080", "http://localhost:4200", "http://localhost:5174", "http://localhost:5173")
            .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
    });
});


builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    // Set the expiration time for the OTP
    options.TokenLifespan = TimeSpan.FromMinutes(5); // Adjust the time span as needed
});

builder.Services.Configure<IdentityOptions>(
    opts => opts.SignIn.RequireConfirmedEmail = true
    );

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,

        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});
builder.Services.AddMemoryCache();
var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

//builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();