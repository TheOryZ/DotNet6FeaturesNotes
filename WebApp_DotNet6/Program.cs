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
    Art�k startup.cs ad�nda bir dosyam�z bulunmamaktad�r �ncelikle. Startup dosyas�, uygulamam�z�n temel konfigurasyonlar�n� yapt���m�z bir dosyayd�.
.Net 6'da art�k bu konfigurasyonlar� program.cs alt�nda yapmam�z gerekiyor. .Net 6 �ncesinde startup.cs dosyas�nda yap�lan konfigurasyonlar zaten program.cs alt�nda
CreateHostBuilder alt�nda belirtiliyordu. .Net 6 art�k bunu luz�msuz g�rmektedir, tek bir dosyada �al���lmas� gerekti�ini d���nmektedirler.
K�sacas�, service ve middleware konfigurasyonlar�n�n sorumlulu�u program.cs dosyas�na b�rak�lm��t�r.

    Top Level Statements �zelli�i .Net 6'da default olarak gelmektedir.
Top Level Statements nedir? : S�radan bir i�lem i�in bile olu�turulan console uygulamas�nda basmakal�p(boilerplate) kodlar�n gelmesi gerekmektedir.
C# 9.0 ile bu durum de�i�mi�tir. Gelen �zellik ile main fonksiyonun zoraki imzas� tan�mlamas� kald�r�lm��t�r. Bu i�lem sadece program.cs dosyas�nda ge�erlidir.
(yaz�lan kod main metodu i�erisinde gibi d���n�lebilir.)

    .Net 6 �ncesinde builder nesnesi olu�turabilmek i�in Host s�n�f� ve IHost interface s�n�flar� vard�. .Net 6'da ise bunun yerini WebApplication alm��t�r.
    WebApplicatonBuilder : .Net 6 �ncesindeki IHostBuilder muadilidir.

    WebApplication s�n�f� yard�m�yla olu�turulan, WebApplicatonBuilder tipindeki builder nesnesi �zerinden uygulamada kullan�lacak servislerin entegre edilme i�lemleri yap�lmaktad�r.
    
    Port : .Net 6 �ncesinde uygulama direkt 5001 ve 5000 portlar�nda aya�a kalk�yordu. launchSettings.json alt�nda g�r�lebilir. Art�k her uygulamada de�i�iklik g�stericek �ekilde 
kurgulanm��t�r.
 */
