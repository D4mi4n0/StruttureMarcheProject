using FunzioneServiziMarche.WSSOAP;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // Aggiungi questa riga

//importanti ste 2 righe
builder.Services.AddSoapCore();
builder.Services.AddScoped<IFunzioneMarche, FunzionePerServizi>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
       name: "default",
       pattern: "{controller=Home}/{action=Index}/{id?}");

//importanti anche queste!
app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<IFunzioneMarche>("/FunctionMarche.wsdl", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});

app.Run();
