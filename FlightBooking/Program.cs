using FlightBooking.AgentServices;
using FlightBooking.AgentServices.CityDedectors;
using FlightBooking.AgentServices.GooglePlacesServices;
using FlightBooking.AgentServices.IntentDetectors;
using FlightBooking.AgentServices.OpenAIServices;
using FlightBooking.AgentServices.PromptBuilder;
using FlightBooking.AgentSettings;
using FlightBooking.Services.BookingServices;
using FlightBooking.Services.CheckInServices;
using FlightBooking.Services.FilghtServices;
using FlightBooking.Services.MachineLearningServices;
using FlightBooking.Services.NoShowServices;
using FlightBooking.Services.OverBookingNoShowServices;
using FlightBooking.Settings;
using FlightBooking.Tools.WeatherTool;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddAutoMapper(cfg => cfg.AddMaps(typeof(Program).Assembly)); // AutoMapper'ın 14+ sürümü için güncellenen yapılandırma formatı.

builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ICheckInService, CheckInService>();
builder.Services.AddScoped<NoShowService>();
builder.Services.AddScoped<OverBookingRecommendationService>();
builder.Services.AddScoped<NoShowPredictionService>();

builder.Services.AddSingleton<FlightMLService>();
builder.Services.AddScoped<MongoFlightDataService>();
builder.Services.AddSingleton<FlightRegressionService>();

builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
builder.Services.AddHttpClient();
builder.Services.Configure<OpenAISettings>(builder.Configuration.GetSection("OpenAI"));
builder.Services.AddScoped<ITravelAgentService, TravelAgentService>();
builder.Services.AddScoped<IOpenAIService, OpenAIService>();
builder.Services.AddScoped<ITravelPromptBuilder, TravelPromptBuilder>();
builder.Services.AddScoped<IIntentDetector, TravelIntentDetector>();
builder.Services.AddScoped<IWeatherTool, WeatherTool>();
builder.Services.AddScoped<ICityExtractor, OpenAICityExtractor>();
builder.Services.AddScoped<IGooglePlacesService, GooglePlacesService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Agent}/{action=AskAgent}/{id?}")
    .WithStaticAssets();


app.Run();
