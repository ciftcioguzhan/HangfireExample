# Hangfire Nedir
Hangfire, arkaplanda çalışacak olan bazı işleri yaratıp, yürütmeyi ve yönetmeyi sağlayan açık kaynaklı bir kütüphanedir.

## *Hangfire Job Türleri*
-Fire And Forget (Ücretsiz); Bir kere ve hemen çalışan job tipidir. İş tanımlanır ve ardından bir kere tetiklenir.
-Delayed (Ücretsiz); Oluşturulduktan belirli bir zaman sonra sadece bir kere çalışır.
-Recurring; Tekrarlanan işler ve belirtilen zaman dilimlerinde çalışan job tipidir.
-Continuations; Birbirleriyle ilişkili işlerin olduğu zaman çalışan job tipidir.

Biz örnekte sadece "Fire And Forget" baz aldık.
## *Konfigürasyon Ayarları*
Uygulama ilk ayağa kalktığında Hangfire yapılanması ilgili veritabanında kendisine ait tabloların var olup olmadığını check etmekte, eğer yoksa anında migrate etmektedir.
Bu işlemden sonra Hangfire kütüphanesini servis olarak uygulamaya dahil etmek ve nimetlerinden faydalanabilmek için “Startup.cs” dosyasında aşağıdaki kod parçasını eklememiz gerekiyor.

```csharp
   public void ConfigureServices(IServiceCollection services)
        {
           

            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection")));
            services.AddHangfireServer();
        } 
```

```csharp
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseHangfireDashboard();

        }
```



