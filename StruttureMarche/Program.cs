using FunzioneServiziMarche.WSSOAP;
using SoapCore;

namespace StruttureRicettiveMarche
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllers(); // Aggiungi questa riga

            //importanti ste 2 righe
            builder.Services.AddSoapCore();
            builder.Services.AddScoped<IFunzioneMarche, FunzionePerServizi>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers(); // Aggiungi questa riga

            //importanti anche queste!
            app.UseEndpoints(endpoints =>
            {
                endpoints.UseSoapEndpoint<IFunzioneMarche>("/FunctionMarche.wsdl", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
            });

            app.Run();
        }
    }
}