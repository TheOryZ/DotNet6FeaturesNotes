var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

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

app.Run();




/* 
        Notes: 
    Artýk startup.cs adýnda bir dosyamýz bulunmamaktadýr öncelikle. Startup dosyasý, uygulamamýzýn temel konfigurasyonlarýný yaptýðýmýz bir dosyaydý.
.Net 6'da artýk bu konfigurasyonlarý program.cs altýnda yapmamýz gerekiyor. .Net 6 öncesinde startup.cs dosyasýnda yapýlan konfigurasyonlar zaten program.cs altýnda
CreateHostBuilder altýnda belirtiliyordu. .Net 6 artýk bunu luzümsuz görmektedir, tek bir dosyada çalýþýlmasý gerektiðini düþünmektedirler.
Kýsacasý, service ve middleware konfigurasyonlarýnýn sorumluluðu program.cs dosyasýna býrakýlmýþtýr.

    Top Level Statements özelliði .Net 6'da default olarak gelmektedir.
Top Level Statements nedir? : Sýradan bir iþlem için bile oluþturulan console uygulamasýnda basmakalýp(boilerplate) kodlarýn gelmesi gerekmektedir.
C# 9.0 ile bu durum deðiþmiþtir. Gelen özellik ile main fonksiyonun zoraki imzasý tanýmlamasý kaldýrýlmýþtýr. Bu iþlem sadece program.cs dosyasýnda geçerlidir.
(yazýlan kod main metodu içerisinde gibi düþünülebilir.)

    .Net 6 öncesinde builder nesnesi oluþturabilmek için Host sýnýfý ve IHost interface sýnýflarý vardý. .Net 6'da ise bunun yerini WebApplication almýþtýr.
    WebApplicatonBuilder : .Net 6 öncesindeki IHostBuilder muadilidir.

    WebApplication sýnýfý yardýmýyla oluþturulan, WebApplicatonBuilder tipindeki builder nesnesi üzerinden uygulamada kullanýlacak servislerin entegre edilme iþlemleri yapýlmaktadýr.
    
    Port : .Net 6 öncesinde uygulama direkt 5001 ve 5000 portlarýnda ayaða kalkýyordu. launchSettings.json altýnda görülebilir. Artýk her uygulamada deðiþiklik göstericek þekilde 
kurgulanmýþtýr.
 */
