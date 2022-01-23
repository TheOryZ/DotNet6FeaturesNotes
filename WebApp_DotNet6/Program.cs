var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

//Console.WriteLine(builder.Configuration["Conf:A"]);

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
    
    Services Entegrasyonu : Build edilmeden önce builder üzerinden services eklenmeleri yapýlmaktadýr. Örn: builder.Services. Dikkat edilmesi gereken nokta builder.Build();
komutundan önce eklenmesi gerekmektedir. Daha sonra build iþleminden sonra eklenen ilgili servies çaðýrýlýp, tanýmlanýr ve kullanmaya hazýr hale getirilir.
    Örn:
    builder.Services.AddHttpContextAccessor();
    var app = builder.Build();
    app.Services.GetService<IHttpContextAccessor>();
sýralamasý þeklinde kullanýlýr.

    IConfiguration : Middleware'ler üzerinde konfigurasyonel deðere eriþim ihtiyacý varsa kullanýlýr. app.Configuration
    ConfigurationManager : Service entegrasyonlarý sürecinde herhangi bir konfigurasyonel bir deðere ihtiyacýmýz varsa bu deðeri bizlere getiren türdür. builder.Configuration[...]

    ConfigurationManager .Net 6^da gelen yeni bir türdür ve .Net 6'dan önceki bir sorunu performanslý bir þekilde çözmemizi saðlar.

--> .Net 6'dan önceki sorun : appsettings.json dýþýnda farklý bir .json dosyasýndan verileri okumak istediðimizde zahmetli bir build iþlemi gerekiyordu. 
Örnek kod bloðu ;
    ConfigurationBuilder configurationBuilder = new();
    configurationBuilder. AddJsonFile("conf.json");
    IConfigurationRoot configurationRoot configurationBuilder.Build();
    var sonuC = configurationRoot["Key"];
.Net 6 bu build maaliyetini ortadan kaldýrmýþtýr. Harici bir .json dosyasý okunmasýnda tekrardan build edilmesinin önüne geçerek performans saðlanmýþtýr.

.Net 6'da örnek kod bloðu ;
    ConfigurationManager cm = new();
    cm.AddJsonFile("conf.json");
    Console.WriteLine(cm["Key"]);
 */
