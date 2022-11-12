using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Settings;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Services;
using EmployeeAPI.Application;
using EmployeeAPI.Contexts;
using EmployeeAPI.Application.Common.Logging;
using EmployeeAPI.Application.Common.Exceptions;


var builder = WebApplication.CreateBuilder(args);

// Logger
LogConfiguration.ConfigurateLogger(builder);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(c =>
{
    c.AddPolicy(name: MyAllowSpecificOrigins, options =>
        options
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddApplication(builder.Configuration);

// Configure dbContext
string connection = builder.Configuration.GetConnectionString("EmployeeAPICon");
builder.Services.AddDbContext<CompanyContext>(options => options.UseSqlServer(connection));
// Configure repository
EmployeeAPI.Shared.DependencyInjection.ConfigureRepository(builder.Services);

// Configure authentification
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddScoped<IAuthManager, AuthManager>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<CustomExceptionMiddleware>();

app.MapControllers();

AppDbInitialize.Seed(app);

app.Run();

//var people = new List<Person>
// {
//    new Person("tom@gmail.com", "12345"),
//    new Person("bob@gmail.com", "55555")
//};

//builder.Services.AddAuthentication("Bearer").AddJwtBearer();
//builder.Services.AddAuthorization();
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidIssuer = AuthOptions.ISSUER,
//            ValidateAudience = true,
//            ValidAudience = AuthOptions.AUDIENCE,
//            ValidateLifetime = true,
//            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
//            ValidateIssuerSigningKey = true,
//        };
//    });


//app.MapPost("/login", (Person loginData) =>
//{
//    Person? person =people.FirstOrDefault(p=>p.Email==loginData.Email
//        &&p.Password==loginData.Password);
//    if (person is null) return Results.Unauthorized();
//    var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Email) };
//    // ñîçäàåì JWT-òîêåí
//    var jwt = new JwtSecurityToken(
//            issuer: AuthOptions.ISSUER,
//            audience: AuthOptions.AUDIENCE,
//            claims: claims,
//            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(15)),
//            signingCredentials: new SigningCredentials(AuthOptions
//            .GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
//    var encodedJwt=new JwtSecurityTokenHandler().WriteToken(jwt);
//    var response = new
//    {
//        access_token = encodedJwt,
//        username = person.Email
//    };
//    return Results.Json(response);
//});

//public class AuthOptions
//{
//    public const string ISSUER = "MyAuthServer"; // èçäàòåëü òîêåíà
//    public const string AUDIENCE = "MyAuthClient"; // ïîòðåáèòåëü òîêåíà
//    const string KEY = "mysupersecret_secretkey!123";   // êëþ÷ äëÿ øèôðàöèè
//    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
//new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
//}
//record class Person(string Email,string Password);